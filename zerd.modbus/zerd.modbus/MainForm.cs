using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zerd.modbus
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Scripts folder path
        /// </summary>
        string ScriptsPath;
        /// <summary>
        /// Transport Port (It should be replaced with DebuggedSerial)
        /// </summary>
        SerialPort Port;

        bool PlayNext = false;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On main form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            PortListBox.Items.AddRange(SerialPort.GetPortNames());
            if (PortListBox.Items.Count > 0)
            {
                PortListBox.SelectedItem = PortListBox.Items[0];
            }
        }

        /// <summary>
        /// On click 'Connect'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (!ScriptsBox.Enabled)
            {
                if (PortListBox.SelectedItem is string &&
                    SerialPort.GetPortNames().Any(p => p == (PortListBox.SelectedItem as string)))
                {
                    if (int.TryParse(BaudrateBox.Text, out int baudrate))
                    {
                        ScriptsBox.Enabled = true;
                        ConnectBtn.Text = "Disconnect";
                        Port = new SerialPort(PortListBox.SelectedItem as string, baudrate);
                    }
                }
            }
            else
            {
                ScriptsBox.Enabled = false;
                ConnectBtn.Text = "Connect";
                StopAll();
                ScriptDGV.Rows.Clear();
                Port.Dispose();
            }
        }


        /// <summary>
        /// Opens Folder dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CwdLnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using FolderBrowserDialog FolderDlg = new FolderBrowserDialog();
            if (FolderDlg.ShowDialog() == DialogResult.OK)
            {

                ScriptsPath = FolderDlg.SelectedPath;
                CwdLnk.Text = ScriptsPath;

                StopAll();
                ScriptDGV.Rows.Clear();

                foreach (string script in Directory.GetFiles(ScriptsPath).Where(name => Path.GetExtension(name).EndsWith("scr")))
                {
                    int idx = ScriptDGV.Rows.Add();

                    ScriptDGV.Rows[idx].Cells[0].Tag = new Player(Port, script, null);
                    Player filePlayer = ScriptDGV.Rows[idx].Cells[0].Tag as Player;

                    filePlayer.OnStart += ((pl, ee) =>
                    {
                        (pl as Player).Row.Cells[2].Value = "Stop";
                    });

                    filePlayer.OnDone += ((pl, canceled) =>
                    {
                        (pl as Player).Row.Cells[2].Value = "Play";

                        if (!canceled)
                        {
                            (pl as Player).Row.Cells[1].Value = Path.GetFileNameWithoutExtension((pl as Player).LogPath);

                            if (PlayNext && ((pl as Player).Row.Index + 1) < ScriptDGV.Rows.Count)
                            {
                                (ScriptDGV.Rows[((pl as Player).Row.Index + 1)].Cells[0].Tag as Player).Play();
                            }
                        }
                    });

                    filePlayer.OnException += (pl, ex) =>
                    {
                        (pl as Player).Row.Cells[2].Value = "Error";
                        (pl as Player).Row.Cells[1].Value = Path.GetFileNameWithoutExtension((pl as Player).LogPath);
                    };

                    filePlayer.Row = ScriptDGV.Rows[idx];

                    ScriptDGV.Rows[idx].Cells[0].Value = Path.GetFileNameWithoutExtension(script);
                    ScriptDGV.Rows[idx].Cells[1].Tag = idx;
                    ScriptDGV.Rows[idx].Cells[1].Value = " - ";
                    ScriptDGV.Rows[idx].Cells[2].Value = "Play";
                }
            }
        }

        /// <summary>
        /// Stops all tasks
        /// </summary>
        private void StopAll()
        {
            foreach (DataGridViewRow dr in ScriptDGV.Rows)
            {
                (dr.Cells[0].Tag as Player).Stop();
            }

        }

        /// <summary>
        /// On click to table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.ColumnIndex == 0) // open script in notepad
                {
                    Process.Start("notepad.exe", $"{ScriptsPath}{Path.DirectorySeparatorChar}{dgv.Rows[e.RowIndex].Cells[0].Value}.scr");
                }

                if (e.ColumnIndex == 1) // open log file in notepad
                {
                    string logfname = dgv.Rows[e.RowIndex].Cells[1].Value as string;
                    logfname = $"{ScriptsPath}{Path.DirectorySeparatorChar}{logfname}.log";

                    if (File.Exists(logfname))
                    {
                        Process.Start("notepad.exe", logfname);
                    }
                    else
                    {
                        MessageBox.Show("Log file for task is not created yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// On click table button 'play/stop'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && (sender is DataGridView dgv)) //buttons
            {
                Player filePlayer = (dgv.Rows[e.RowIndex].Cells[0].Tag as Player);
                StopAll();
                PlayNext = false;
                filePlayer.Play();
            }
        }

        /// <summary>
        /// On click play button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            StopAll();
            if (ScriptDGV.Rows.Count > 0)
            {
                int idx = ScriptDGV.Rows.GetFirstRow(DataGridViewElementStates.None);
                (ScriptDGV.Rows[idx].Cells[0].Tag as Player).Play();
                PlayNext = true;
            }
        }

        /// <summary>
        /// On click play button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopBtn_Click(object sender, EventArgs e)
        {
            PlayNext = false;
            StopAll();
        }

        /// <summary>
        /// On pause click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in ScriptDGV.Rows)
            {
                if((dr.Cells[0].Tag as Player).IsRunning)
                {
                    (dr.Cells[0].Tag as Player).Paused ^= true;
                }
                else
                {
                    (dr.Cells[0].Tag as Player).Paused = false;
                }
            }

        }
    }
}

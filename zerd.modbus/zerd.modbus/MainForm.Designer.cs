
namespace zerd.modbus
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PortCfgBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PortListBox = new System.Windows.Forms.ComboBox();
            this.BaudrateBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ScriptsBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ScriptDGV = new System.Windows.Forms.DataGridView();
            this.ScriptNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogFileCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CtrlCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.CwdLnk = new System.Windows.Forms.LinkLabel();
            this.CtrlBox = new System.Windows.Forms.TableLayoutPanel();
            this.StopBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.PortCfgBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ScriptsBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScriptDGV)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.CtrlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PortCfgBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ScriptsBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 601);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PortCfgBox
            // 
            this.PortCfgBox.Controls.Add(this.tableLayoutPanel2);
            this.PortCfgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortCfgBox.Location = new System.Drawing.Point(3, 3);
            this.PortCfgBox.Name = "PortCfgBox";
            this.PortCfgBox.Size = new System.Drawing.Size(458, 94);
            this.PortCfgBox.TabIndex = 0;
            this.PortCfgBox.TabStop = false;
            this.PortCfgBox.Text = "Connect";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PortListBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BaudrateBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.ConnectBtn, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.05556F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.94444F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(452, 72);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PortListBox
            // 
            this.PortListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortListBox.FormattingEnabled = true;
            this.PortListBox.Location = new System.Drawing.Point(67, 4);
            this.PortListBox.Margin = new System.Windows.Forms.Padding(4);
            this.PortListBox.Name = "PortListBox";
            this.PortListBox.Size = new System.Drawing.Size(155, 23);
            this.PortListBox.TabIndex = 1;
            // 
            // BaudrateBox
            // 
            this.BaudrateBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaudrateBox.FormattingEnabled = true;
            this.BaudrateBox.Items.AddRange(new object[] {
            "115200",
            "74880",
            "57600",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400",
            "1200",
            "600",
            "300",
            "110"});
            this.BaudrateBox.Location = new System.Drawing.Point(293, 4);
            this.BaudrateBox.Margin = new System.Windows.Forms.Padding(4);
            this.BaudrateBox.Name = "BaudrateBox";
            this.BaudrateBox.Size = new System.Drawing.Size(155, 23);
            this.BaudrateBox.TabIndex = 2;
            this.BaudrateBox.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(229, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baudrate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectBtn.Location = new System.Drawing.Point(371, 43);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // ScriptsBox
            // 
            this.ScriptsBox.Controls.Add(this.tableLayoutPanel3);
            this.ScriptsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptsBox.Enabled = false;
            this.ScriptsBox.Location = new System.Drawing.Point(3, 103);
            this.ScriptsBox.Name = "ScriptsBox";
            this.ScriptsBox.Size = new System.Drawing.Size(458, 495);
            this.ScriptsBox.TabIndex = 1;
            this.ScriptsBox.TabStop = false;
            this.ScriptsBox.Text = "Scripts";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ScriptDGV, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(452, 473);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ScriptDGV
            // 
            this.ScriptDGV.AllowUserToAddRows = false;
            this.ScriptDGV.AllowUserToDeleteRows = false;
            this.ScriptDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ScriptDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScriptDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScriptNameCol,
            this.LogFileCol,
            this.CtrlCol});
            this.ScriptDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptDGV.Location = new System.Drawing.Point(3, 51);
            this.ScriptDGV.MultiSelect = false;
            this.ScriptDGV.Name = "ScriptDGV";
            this.ScriptDGV.ReadOnly = true;
            this.ScriptDGV.RowHeadersVisible = false;
            this.ScriptDGV.RowTemplate.Height = 25;
            this.ScriptDGV.Size = new System.Drawing.Size(446, 419);
            this.ScriptDGV.TabIndex = 0;
            this.ScriptDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScriptDGV_CellContentClick);
            this.ScriptDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScriptDGV_CellContentDoubleClick);
            // 
            // ScriptNameCol
            // 
            this.ScriptNameCol.HeaderText = "Script";
            this.ScriptNameCol.Name = "ScriptNameCol";
            this.ScriptNameCol.ReadOnly = true;
            // 
            // LogFileCol
            // 
            this.LogFileCol.HeaderText = "Log";
            this.LogFileCol.Name = "LogFileCol";
            this.LogFileCol.ReadOnly = true;
            // 
            // CtrlCol
            // 
            this.CtrlCol.HeaderText = "Control";
            this.CtrlCol.Name = "CtrlCol";
            this.CtrlCol.ReadOnly = true;
            this.CtrlCol.Text = "Play";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.CwdLnk, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.CtrlBox, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(446, 42);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // CwdLnk
            // 
            this.CwdLnk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CwdLnk.AutoSize = true;
            this.CwdLnk.Location = new System.Drawing.Point(121, 13);
            this.CwdLnk.Name = "CwdLnk";
            this.CwdLnk.Size = new System.Drawing.Size(99, 15);
            this.CwdLnk.TabIndex = 0;
            this.CwdLnk.TabStop = true;
            this.CwdLnk.Text = "Open working dir";
            this.CwdLnk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CwdLnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CwdLnk_LinkClicked);
            // 
            // CtrlBox
            // 
            this.CtrlBox.ColumnCount = 3;
            this.CtrlBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.CtrlBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.CtrlBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.CtrlBox.Controls.Add(this.StopBtn, 2, 0);
            this.CtrlBox.Controls.Add(this.PauseBtn, 1, 0);
            this.CtrlBox.Controls.Add(this.PlayBtn, 0, 0);
            this.CtrlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlBox.Location = new System.Drawing.Point(226, 3);
            this.CtrlBox.Name = "CtrlBox";
            this.CtrlBox.RowCount = 1;
            this.CtrlBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CtrlBox.Size = new System.Drawing.Size(217, 36);
            this.CtrlBox.TabIndex = 1;
            // 
            // StopBtn
            // 
            this.StopBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopBtn.Image = global::zerd.modbus.Properties.Resources.stop26;
            this.StopBtn.Location = new System.Drawing.Point(143, 3);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(71, 30);
            this.StopBtn.TabIndex = 2;
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PauseBtn.Image = global::zerd.modbus.Properties.Resources.pause26;
            this.PauseBtn.Location = new System.Drawing.Point(73, 3);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(64, 30);
            this.PauseBtn.TabIndex = 1;
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayBtn.Image = global::zerd.modbus.Properties.Resources.play26;
            this.PlayBtn.Location = new System.Drawing.Point(3, 3);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(64, 30);
            this.PlayBtn.TabIndex = 0;
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Device tester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.PortCfgBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ScriptsBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScriptDGV)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.CtrlBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox PortCfgBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PortListBox;
        private System.Windows.Forms.ComboBox BaudrateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.GroupBox ScriptsBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView ScriptDGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.LinkLabel CwdLnk;
        private System.Windows.Forms.TableLayoutPanel CtrlBox;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScriptNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogFileCol;
        private System.Windows.Forms.DataGridViewButtonColumn CtrlCol;
    }
}


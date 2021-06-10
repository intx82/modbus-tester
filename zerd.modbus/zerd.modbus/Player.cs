using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zerd.modbus
{
    /// <summary>
    /// File player, plays only one file via serial port,  serial port should be configured before using class
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Transport
        /// </summary>
        readonly SerialPort Port;

        static readonly ManualResetEvent mtx = new ManualResetEvent(true);

        readonly NLog.Logger Logger;

        /// <summary>
        /// Script path
        /// </summary>
        readonly string _scriptPath;

        /// <summary>
        /// Log path
        /// </summary>
        string _logPath;


        /// <summary>
        /// Путь проигрываемого скрипта
        /// </summary>
        public string ScriptPath => _scriptPath;

        /// <summary>
        /// Путь логов
        /// </summary>
        public string LogPath
        {
            get => _logPath;
            set
            {
                _logPath = value;
            }
        }

        /// <summary>
        /// Отмена задачи
        /// </summary>
        CancellationTokenSource cancelSrc = null;


        /// <summary>
        /// Row to save position
        /// </summary>        
        public DataGridViewRow Row { get; set; }

        /// <summary>
        /// Calls event when file stops playing
        /// </summary>
        public event EventHandler<bool> OnDone;


        /// <summary>
        /// On exception
        /// </summary>
        public event EventHandler<Exception> OnException;

        /// <summary>
        /// calls event when file starts playing
        /// </summary>
        public event EventHandler OnStart;

        /// <summary>
        /// Convert hex string to byte array 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        ///  Compute the MODBUS RTU CRC
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="len"></param>
        /// <param name="start_pos"></param>
        /// <returns></returns>
        static byte[] CrcCalc(byte[] buf, int len = 0, int start_pos = 0)
        {
            UInt16 _crc = 0xFFFF;

            if (len == 0)
            {
                len = buf.Length;
            }

            for (int pos = start_pos; pos < len; pos++)
            {
                _crc ^= (UInt16)buf[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((_crc & 0x0001) != 0)
                    {      // If the LSB is set
                        _crc >>= 1;                    // Shift right and XOR 0xA001
                        _crc ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                        _crc >>= 1;                    // Just shift right
                }
            }
            // Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)
            return new byte[] { (byte)(_crc & 0xff), (byte)(_crc >> 8) };
        }

        private static readonly object _lock = new object();

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="Port">Used port</param>
        /// <param name="ScriptPath">Path to script file</param>
        /// <param name="LogPath">Path to log file, if not specified, new one will bre created</param>
        public Player(SerialPort Port, string ScriptPath, string LogPath)
        {
            this.Port = Port;
            this._scriptPath = ScriptPath ?? throw new NullReferenceException();
            this._logPath = LogPath ?? $"{Path.GetDirectoryName(ScriptPath)}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(_scriptPath)}.{DateTime.Now.Year:00}{DateTime.Now.Month:00}{DateTime.Now.Day:00}.{DateTime.Now.Hour:00}{DateTime.Now.Minute:00}{DateTime.Now.Second:00}.log";

            // Targets where to log to: File and Console
            lock (_lock)
            {
                string logName = Path.GetFileNameWithoutExtension(_logPath);

                if (LogManager.Configuration == null || LogManager.Configuration.FindTargetByName(logName) == null)
                {
                    var fileTarget = new FileTarget(logName)
                    {
                        FileName = _logPath,
                        Layout = "${longdate} ${level:uppercase=true} ${message}",
                    };

                    if (LogManager.Configuration == null)
                    {
                        LogManager.Configuration = new LoggingConfiguration();
                    }

                    LogManager.Configuration.AddTarget(fileTarget);
                    var rule = new LoggingRule(logName, LogLevel.Debug, fileTarget) { Final = true };
                    LogManager.Configuration.LoggingRules.Add(rule);
                    LogManager.ReconfigExistingLoggers();
                }

                Logger = LogManager.GetLogger(logName);
            }
        }


        /// <summary>
        /// Sends 
        /// </summary>
        /// <param name="inData"></param>
        /// <returns></returns>
        public byte[] Send(byte[] inData, int timeout = 50)
        {
            byte[] buffer = Array.Empty<byte>();

            try
            {
                List<byte> full_cmd = new List<byte>(inData);
                Port.DiscardInBuffer();
                Port.DiscardOutBuffer();
                Port.ReadTimeout = 1000;

                Stopwatch s = new Stopwatch();

                Port.DataReceived += ((o, e) =>
                {
                    s.Restart();
                });

                Port.ErrorReceived += ((o, e) =>
                {
                    Logger.Error("Serial port error found: " + e.EventType.ToString());
                });

                Port.Write(full_cmd.ToArray(), 0, full_cmd.ToArray().Length);
                s.Start();
                while (true)
                {
                    if ((Port.BytesToRead > 0) && (s.ElapsedMilliseconds > timeout))
                    {
                        break;
                    }

                    if (s.ElapsedMilliseconds >= Port.ReadTimeout - 10)
                    {
                        break;
                    }
                }

                Thread.Sleep(50);
                buffer = new byte[Port.BytesToRead];
                Port.Read(buffer, 0, Port.BytesToRead);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Array.Empty<byte>();
            }

            return buffer;
        }

        /// <summary>
        /// Start playing provided in constructor file (into port)
        /// </summary>
        public void Play()
        {
            cancelSrc = new CancellationTokenSource();
            OnStart?.Invoke(this, new EventArgs());
            Task.Run(() =>
            {
                Logger.Info($"Open: {ScriptPath}. Port: {Port.PortName} : {Port.BaudRate}");
                mtx.WaitOne();
                mtx.Reset();
                try
                {
                    Port.Open();

                    string[] fileContent = File.ReadAllLines(ScriptPath);
                    foreach (string line in fileContent)
                    {
                        if (line.ToLowerInvariant().StartsWith("delay"))
                        {
                            string[] opts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            if (opts.Length >= 2)
                            {
                                int del = int.Parse(opts[1]);
                                Logger.Info($"Delay {del} ms");
                                Thread.Sleep(del);
                            }
                        }
                        else
                        {
                            var rgx = new Regex("[^a-fA-F0-9]");
                            byte[] sndData = StringToByteArray(rgx.Replace(line,string.Empty));
                            List<byte> sndList = new List<byte>();
                            sndList.AddRange(sndData);
                            sndList.AddRange(CrcCalc(sndData));

                            if (sndData.Length > 0)
                            {
                                Logger.Info($"TX: {BitConverter.ToString(sndList.ToArray())}");
                                byte[] respData = Send(sndList.ToArray());
                                Logger.Info($"RX: {BitConverter.ToString(respData)}");
                            }
                            else
                            {
                                Logger.Warn("TX: Empty");
                            }
                        }

                        if (cancelSrc.IsCancellationRequested)
                        {
                            OnDone?.Invoke(this, true);
                            Logger.Info($"Cancel {ScriptPath}");
                            return;
                        }
                    }

                    OnDone?.Invoke(this, false);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    OnException?.Invoke(this, ex);
                }
                finally
                {
                    Port.Close();
                    mtx.Set();
                }

                Logger.Info($"Close {ScriptPath}");
            });
        }

        /// <summary>
        /// Stops running task
        /// </summary>
        public void Stop()
        {
            if (cancelSrc is CancellationTokenSource)
            {
                cancelSrc.Cancel();
            }
        }
    }
}

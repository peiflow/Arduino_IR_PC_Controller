using System.IO.Ports;
using System.IO;
using System;
using NLog;

namespace IrPcController
{
    internal class Controller
    {
        const string PORT = "COM3";

        private MediaController _mediaController;
        private SerialPort _serialPort;

        private Logger _logger;

        public Controller()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _mediaController = new MediaController();
            _serialPort = new SerialPort(PORT);
            _serialPort.BaudRate = 9600;
        }

        public void ReadData()
        {
            _logger.Debug("Starting " + nameof(ReadData));
            try
            {
                _serialPort.Open();

                if (_serialPort.IsOpen)
                    Console.WriteLine($"Port {PORT} open");

                while (_serialPort.IsOpen)
                {
                    var s = _serialPort.ReadLine();
                    s = s.Replace("\r", string.Empty).Replace("\n", string.Empty);
                    Console.WriteLine(s);
                    switch (s)
                    {
                        case "+":
                            _mediaController.VolumeUp();
                            break;
                        case "-":
                            _mediaController.VolumeDown();
                            break;
                        case "EQ":
                            _mediaController.VolumeMute();
                            break;
                        case ">|":
                            _mediaController.PlayPauseTrack();
                            break;
                        case ">>|":
                            _mediaController.NextTrack();
                            break;
                        case "|<<":
                            _mediaController.PreviousTrack();
                            break;
                        case "CH":
                            _mediaController.PauseWeb();
                            break;
                        case "CH+":
                            _mediaController.NextVideoWeb();
                            break;
                        case "CH-":
                            _mediaController.PreviousVideoWeb();
                            break;
                        case "200+":
                            _mediaController.FullscreenVideoWeb();
                            break;
                        case "0":
                            // ProcessStartInfo ProcessInfo;
                            // Process Process;
                            // ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + "shutdown -h");
                            // ProcessInfo.CreateNoWindow = true;
                            // ProcessInfo.UseShellExecute = false;
                            // Process = Process.Start(ProcessInfo);
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                _serialPort.Close();
                Console.WriteLine(ex);
                _logger.Error(nameof(ReadData) + " ended with: " + ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                _serialPort.Close();
                Console.WriteLine(ex);
                _logger.Error(nameof(ReadData) + " ended with: " + ex);
            }
            catch (Exception ex)
            {
                _serialPort.Close();
                Console.WriteLine(ex);
                _logger.Error(nameof(ReadData) + " ended with: " + ex);
            }
            finally
            {
                _serialPort.Close();
                if (!_serialPort.IsOpen)
                    Console.WriteLine($"Port {PORT} closed");
            }
        }
    }
}


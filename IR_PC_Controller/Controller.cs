using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System;
using NLog;

namespace Arduino_IR_Controller
{
    public class Controller
    {
        private SerialPort _arduinoPort;
        private MediaController _mediaController;
        private Logger _logger;

        public Controller()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _arduinoPort = new SerialPort();
            _arduinoPort.PortName = "COM3";
            _arduinoPort.BaudRate = 9600;
            _mediaController = new MediaController();
        }

        public void ReadData()
        {
            try
            {
                _logger.Debug("Starting " + nameof(ReadData));
                _arduinoPort.Open();
                while (_arduinoPort.IsOpen)
                {
                    _arduinoPort.ReadLine();
                    var cmd = _arduinoPort.ReadLine();
                    cmd = cmd.Replace("\r", string.Empty).Replace("\n", string.Empty);
                    switch (cmd)
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
                            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + "shutdown -h");
                            processInfo.CreateNoWindow = true;
                            processInfo.UseShellExecute = false;
                            Process.Start(processInfo);
                            _logger.Debug("End of " + nameof(ReadData) + ": Shutting down pc");
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                _logger.Error(nameof(ReadData) + " ended with: " + ex);
            }
            finally
            {
                _arduinoPort.Close();
                _logger.Error(nameof(ReadData) + " close COM port");
            }
        }
    }
}

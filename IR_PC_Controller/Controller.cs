using System.IO.Ports;
using System.IO;
using System;
using NLog;
using System.Diagnostics;
using System.Globalization;

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
                    Console.WriteLine($"Port {PORT} open", Console.ForegroundColor = ConsoleColor.Blue);

                while (_serialPort.IsOpen)
                {
                    var inline = _serialPort.ReadLine();
                    inline = inline.Replace("\r", string.Empty).Replace("\n", string.Empty);

                    int intInline;
                    _ = int.TryParse(inline, out intInline);
                    var hexVal = intInline.ToString("X", CultureInfo.InvariantCulture);

                    Console.WriteLine(hexVal, Console.ForegroundColor = ConsoleColor.Yellow);

                    switch (hexVal)
                    {
                        case "FFA857": // +
                            _mediaController.VolumeUp();
                            break;
                        case "FFE01F": // -
                            _mediaController.VolumeDown();
                            break;
                        case "FF906F": // EQ
                            _mediaController.VolumeMute();
                            break;
                        case "FFC23D": // >|
                            _mediaController.PlayPauseTrack();
                            break;
                        case "FF02FD": // >>|
                            _mediaController.NextTrack();
                            break;
                        case "FF22DD": // |<<
                            _mediaController.PreviousTrack();
                            break;
                        case "FFE21D": // CH+
                            _mediaController.NextVideoWeb();
                            break;
                        case "FFA25D": // CH-
                            _mediaController.PreviousVideoWeb();
                            break;
                        case "FFB04F": //200+
                            _mediaController.FullscreenVideoWeb();
                            break;
                        case "FF6897":
                            _serialPort.Close();
                            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + "shutdown -h");
                            processInfo.CreateNoWindow = true;
                            processInfo.UseShellExecute = false;
                            Process.Start(processInfo);
                            _logger.Debug("Shutting down PC");
                            break;
                        case "0xFF9867": // 100+
                        case "FF629D": // CH
                        case "FF30CF": // 1
                        case "FF18E7": // 2
                        case "FF7A85": // 3
                        case "FF10EF": // 4
                        case "FF38C7": // 5
                        case "FF5AA5": // 6
                        case "FF42BD": // 7
                        case "FF4AB5": // 8
                        case "FF52AD": // 9
                            Console.WriteLine("Not assinged");
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                _serialPort.Close();
                Console.WriteLine(ex.ToString(), Console.ForegroundColor = ConsoleColor.Red);
                _logger.Error(nameof(ReadData) + " ended with: " + ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                _serialPort.Close();
                Console.WriteLine(ex.ToString(), Console.ForegroundColor = ConsoleColor.Red);
                _logger.Error(nameof(ReadData) + " ended with: " + ex);
            }
            catch (Exception ex)
            {
                _serialPort.Close();
                Console.WriteLine(ex.ToString(), Console.ForegroundColor = ConsoleColor.Red);
                _logger.Error(nameof(ReadData) + " ended with: " + ex);
            }
            finally
            {
                _serialPort.Close();
                if (!_serialPort.IsOpen)
                    Console.WriteLine($"Port {PORT} closed");
                Console.ReadKey();
            }
        }
    }
}


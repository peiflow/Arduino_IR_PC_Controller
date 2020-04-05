using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System;

namespace Arduino_IR_Controller
{
    public class Controller
    {
        private SerialPort arduinoPort;
        private MediaController mediaController;

        public Controller()
        {
            arduinoPort = new SerialPort();
            arduinoPort.PortName = "COM3";
            arduinoPort.BaudRate = 9600;
            mediaController = new MediaController();
        }

        public void ReadData()
        {
            try
            {
                arduinoPort.Open();
                while (arduinoPort.IsOpen)
                {
                    arduinoPort.ReadLine();
                    var cmd = arduinoPort.ReadLine();
                    cmd = cmd.Replace("\r", string.Empty).Replace("\n", string.Empty);
                    switch (cmd)
                    {
                        case "+":
                            mediaController.VolumeUp();
                            break;
                        case "-":
                            mediaController.VolumeDown();
                            break;
                        case "EQ":
                            mediaController.VolumeMute();
                            break;
                        case ">|":
                            mediaController.PlayPauseTrack();
                            break;
                        case ">>|":
                            mediaController.NextTrack();
                            break;
                        case "|<<":
                            mediaController.PreviousTrack();
                            break;
                        case "CH":
                            mediaController.PauseWeb();
                            break;
                        case "CH+":
                            mediaController.NextVideoWeb();
                            break;
                        case "CH-":
                            mediaController.PreviousVideoWeb();
                            break;
                        case "200+":
                            mediaController.FullscreenVideoWeb();
                            break;
                        case "0":
                            ProcessStartInfo ProcessInfo;
                            Process Process;
                            ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + "shutdown -h");
                            ProcessInfo.CreateNoWindow = true;
                            ProcessInfo.UseShellExecute = false;
                            Process = Process.Start(ProcessInfo);
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

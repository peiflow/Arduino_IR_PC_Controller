
using System.IO.Ports;
using System.Diagnostics;

namespace Arduino_IR_Controller
{
    public class Controller
    {
        SerialPort arduinoPort;
        MediaController mediaController;
        public Controller()
        {
            arduinoPort = new SerialPort();
            arduinoPort.PortName = "COM3";
            arduinoPort.BaudRate = 9600;

            mediaController = new MediaController();
        }

        public void ReadData()
        {
            arduinoPort.Open();
            string s;
            while (arduinoPort.IsOpen)
            {
                arduinoPort.ReadLine();
                Debug.WriteLine(": "+arduinoPort.ReadLine());
                s =  arduinoPort.ReadLine();
                s = s.Replace("\r", string.Empty).Replace("\n", string.Empty);
                switch (s)
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
                        int ExitCode;
                        ProcessStartInfo ProcessInfo;
                        Process Process;
                        ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + "shutdown -h");
                        ProcessInfo.CreateNoWindow = true;
                        ProcessInfo.UseShellExecute = false;
                        Process = Process.Start(ProcessInfo);
                        //Process.WaitForExit(10);
                        //ExitCode = Process.ExitCode;
                        //Process.Close();
                        break;
                }
            }
        }
    }
}
/*
 
This is to hide the cmd window.

System.Diagnostics.Process process = new System.Diagnostics.Process();
System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
startInfo.FileName = "cmd.exe";
startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
process.StartInfo = startInfo;
process.Start();
     */

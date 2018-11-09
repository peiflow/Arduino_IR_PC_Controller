using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_IR_Controller
{
    class ProcessManagement
    {
        Process[] processes;

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        public void ActivateProcess()
        {
            processes = Process.GetProcessesByName("Firefox");

            foreach (var proc in processes)
            {

                if (proc == null)
                    return;

                Debug.WriteLine(proc.Id.ToString());

                if (proc.MainWindowHandle == IntPtr.Zero)
                {
                    ShowWindow(proc.Handle, ShowWindowEnum.ShowMaximized);
                }

                SetForegroundWindow(proc.MainWindowHandle);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/**
* Virtual keys code
* https://docs.microsoft.com/es-es/windows/desktop/inputdev/virtual-key-codes
 **/
namespace Arduino_IR_Controller
{
    class MediaController
    {
        const int VK_SPACE = 0x20;
        const int VK_LWIN = 0x5B;
        const int VK_SHIFT = 0x10;
        const int VK_P_KEY = 0x50;
        const int VK_N_KEY = 0x4E;
        const int VK_F_KEY = 0x46;
        const int VK_MEDIA_NEXT_TRACK = 0xB0;
        const int VK_MEDIA_PREV_TRACK = 0xB1;
        const int VK_MEDIA_STOP = 0xB2;
        const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        const int VK_VOLUME_MUTE = 0xAD;
        const int VK_VOLUME_DOWN = 0xAE;
        const int VK_VOLUME_UP = 0xAF;

        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        

        ProcessManagement processManagement;

        public MediaController()
        {
            processManagement = new ProcessManagement();
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        #region Media
        public void VolumeUp()
        {
            keybd_event((byte)VK_VOLUME_UP, 0, KEYEVENTF_EXTENDEDKEY | 0,0);
            keybd_event((byte)VK_VOLUME_UP, 0, KEYEVENTF_KEYUP | 0,0);
        }
        public void VolumeDown()
        {
            keybd_event((byte)VK_VOLUME_DOWN, 0, KEYEVENTF_EXTENDEDKEY | 0,0);
            keybd_event((byte)VK_VOLUME_DOWN, 0, KEYEVENTF_KEYUP | 0,0);
        }
        public void VolumeMute()
        {
            keybd_event((byte)VK_VOLUME_MUTE, 0, KEYEVENTF_EXTENDEDKEY | 0,0);
            keybd_event((byte)VK_VOLUME_MUTE, 0, KEYEVENTF_KEYUP | 0,0);
        }
        public void PreviousTrack()
        {
            keybd_event((byte)VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void NextTrack()
        {
            keybd_event((byte)VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void PlayPauseTrack()
        {
            keybd_event((byte)VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void StopTrack()
        {
            keybd_event((byte)VK_MEDIA_STOP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_STOP, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        #endregion

        #region Web
        public void PauseWeb()
        {
            //processManagement.ActivateProcess();
            keybd_event((byte)VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_SPACE, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void NextVideoWeb()
        {
            //processManagement.ActivateProcess();
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_N_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_N_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void PreviousVideoWeb()
        {
            //processManagement.ActivateProcess();
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_P_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_P_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void FullscreenVideoWeb()
        {
            //processManagement.ActivateProcess();
            keybd_event((byte)VK_F_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_F_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        /*
            Space is pause/play
            Shift-N is next track (or backspace)
            Shift-P is previous track
            F is fullcreen/resize
         */
        #endregion
    }
}

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
        private readonly int VK_SPACE = 0x20;
        private readonly int VK_LWIN = 0x5B;
        private readonly int VK_SHIFT = 0x10;
        private readonly int VK_P_KEY = 0x50;
        private readonly int VK_N_KEY = 0x4E;
        private readonly int VK_F_KEY = 0x46;
        private readonly int VK_MEDIA_NEXT_TRACK = 0xB0;
        private readonly int VK_MEDIA_PREV_TRACK = 0xB1;
        private readonly int VK_MEDIA_STOP = 0xB2;
        private readonly int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private readonly int VK_VOLUME_MUTE = 0xAD;
        private readonly int VK_VOLUME_DOWN = 0xAE;
        private readonly int VK_VOLUME_UP = 0xAF;
        private readonly uint KEYEVENTF_KEYUP = 0x0002;
        private readonly uint KEYEVENTF_EXTENDEDKEY = 0x0001;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        #region Media
        public void VolumeUp()
        {
            keybd_event((byte)VK_VOLUME_UP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_VOLUME_UP, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void VolumeDown()
        {
            keybd_event((byte)VK_VOLUME_DOWN, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_VOLUME_DOWN, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void VolumeMute()
        {
            keybd_event((byte)VK_VOLUME_MUTE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_VOLUME_MUTE, 0, KEYEVENTF_KEYUP | 0, 0);
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
            keybd_event((byte)VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_SPACE, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void NextVideoWeb()
        {
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_N_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_N_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void PreviousVideoWeb()
        {
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_P_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_P_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_KEYUP | 0, 0);
        }
        public void FullscreenVideoWeb()
        {
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

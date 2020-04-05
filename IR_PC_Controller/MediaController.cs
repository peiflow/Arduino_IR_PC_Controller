using NLog;
using System.Runtime.InteropServices;

/**
 * Virtual keys code
 * https://docs.microsoft.com/es-es/windows/desktop/inputdev/virtual-key-codes
 **/
namespace Arduino_IR_Controller
{
    class MediaController
    {

        private Logger logger;

        private readonly int VK_SPACE = 0x20;
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

        public MediaController()
        {
            logger = LogManager.GetCurrentClassLogger();
        }
        
        #region Media
        public void VolumeUp()
        {
            logger.Debug(nameof(VolumeUp) + " start");
            keybd_event((byte)VK_VOLUME_UP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_VOLUME_UP, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(VolumeUp) + " end");
        }
        public void VolumeDown()
        {
            logger.Debug(nameof(VolumeDown) + " start");
            keybd_event((byte)VK_VOLUME_DOWN, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_VOLUME_DOWN, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(VolumeDown) + " end");
        }
        public void VolumeMute()
        {
            logger.Debug(nameof(VolumeMute) + " start");
            keybd_event((byte)VK_VOLUME_MUTE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_VOLUME_MUTE, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(VolumeMute) + " end");
        }
        public void PreviousTrack()
        {
            logger.Debug(nameof(PreviousTrack) + " start");
            keybd_event((byte)VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(PreviousTrack) + " end");
        }
        public void NextTrack()
        {
            logger.Debug(nameof(NextTrack) + " start");
            keybd_event((byte)VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(NextTrack) + " end");
        }
        public void PlayPauseTrack()
        {
            logger.Debug(nameof(PlayPauseTrack) + " start");
            keybd_event((byte)VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(PlayPauseTrack) + " end");
        }
        public void StopTrack()
        {
            logger.Debug(nameof(StopTrack) + " start");
            keybd_event((byte)VK_MEDIA_STOP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_MEDIA_STOP, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(StopTrack) + " end");
        }
        #endregion

        #region Web
        public void PauseWeb()
        {
            logger.Debug(nameof(PauseWeb) + " start");
            keybd_event((byte)VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_SPACE, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(PauseWeb) + " end");
        }
        public void NextVideoWeb()
        {
            logger.Debug(nameof(NextVideoWeb) + " start");
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_N_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_N_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(NextVideoWeb) + " end");
        }
        public void PreviousVideoWeb()
        {
            logger.Debug(nameof(PreviousVideoWeb) + " start");
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_P_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_P_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
            keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(PreviousVideoWeb) + " end");
        }
        public void FullscreenVideoWeb()
        {
            logger.Debug(nameof(FullscreenVideoWeb) + " start");
            keybd_event((byte)VK_F_KEY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            keybd_event((byte)VK_F_KEY, 0, KEYEVENTF_KEYUP | 0, 0);
            logger.Debug(nameof(FullscreenVideoWeb) + " end");
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

using System.IO;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using Autoclicker.clicker;
using Autoclicker.hooks;
using Autoclicker.mouse_control;

namespace Autoclicker.sound;

public class SoundData
{
    private readonly MouseControl _mouseControl;
    private readonly ShuffleSounds _shuffleSounds;
    public Thread MakeSoundsThread;
        
    public bool RightClickerThreadStarted;
    public bool LeftClickerThreadStarted;
    public  bool RightClickerCanStartNewSound = true;
    public bool LeftClickerCanStartNewSound = true;

    private const int NumberGodBridgeSounds = 5;
    private const int NumberTellyBridgeSounds = 8;
    private const int NumberDragClickSounds = 9;
    private const int NumberNormalRightClickSounds = 6;
    private const int NumberBreezilySounds = 3;
    private const int NumberMoonwalkSounds = 3;
    private const int NumberLeftNormalClicksSounds = 4;
    private const int NumberJitterClickSounds = 6;
    private const int NumberButterflyClickSounds = 9;
        
    private Stream[] _godBridgeSounds;
    private int[] _godBridgeSoundsLength;
    private readonly Stream[] _tellyBridgeSounds = new Stream[NumberTellyBridgeSounds];
    private readonly int[] _tellyBridgeSoundsLength = new int[NumberTellyBridgeSounds];
    private readonly Stream[] _dragClickSounds = new Stream[NumberDragClickSounds];
    private readonly int[] _dragClickSoundsLength = new int[NumberDragClickSounds];
    private readonly Stream[] _normalRightClickSounds = new Stream[NumberNormalRightClickSounds];
    private readonly int[] _normalRightClickSoundsLength = new int[NumberNormalRightClickSounds];
    private readonly Stream[] _breezilySounds = new Stream[NumberBreezilySounds];
    private readonly int[] _breezilySoundsLength = new int[NumberBreezilySounds];
    private readonly Stream[] _moonwalkSounds = new Stream[NumberMoonwalkSounds];
    private readonly int[] _moonwalkSoundsLength = new int[NumberMoonwalkSounds];
    private readonly Stream[] _leftNormalClickSounds = new Stream[NumberLeftNormalClicksSounds];
    private readonly int[] _leftNormalClickSoundsLength = new int[NumberLeftNormalClicksSounds];
    private readonly Stream[] _jitterClickSounds = new Stream[NumberJitterClickSounds];
    private readonly int[] _jitterClickSoundsLength = new int[NumberJitterClickSounds];
        
    private readonly Stream[] _butterflyClickSounds = new Stream[NumberButterflyClickSounds];
    private readonly int[] _butterflyClickSoundsLength = new int[NumberButterflyClickSounds];
    public SoundData(MouseControl mouseControl)
    {
        _mouseControl = mouseControl;
        _shuffleSounds = new ShuffleSounds(mouseControl, this);
        LoadSoundsFromResources();
    }

    private void LoadSoundsFromResources()
    {
        _godBridgeSounds = new Stream[NumberGodBridgeSounds];

        _godBridgeSounds[0] = Properties.Resources.first_godbridge;
        _godBridgeSounds[1] = Properties.Resources.second_godbridge;
        _godBridgeSounds[2] = Properties.Resources.third_godbridge;
        _godBridgeSounds[3] = Properties.Resources.fourth_godbridge;
        _godBridgeSounds[4] = Properties.Resources.fifth_godbridge;

        _godBridgeSoundsLength = new int[NumberGodBridgeSounds];

        _godBridgeSoundsLength[0] = 8087;
        _godBridgeSoundsLength[1] = 8920;
        _godBridgeSoundsLength[2] = 11371;
        _godBridgeSoundsLength[3] = 12827;
        _godBridgeSoundsLength[4] = 2678;

        _tellyBridgeSounds[0] = Properties.Resources.first_telly;
        _tellyBridgeSounds[1] = Properties.Resources.second_telly;
        _tellyBridgeSounds[2] = Properties.Resources.third_telly;
        _tellyBridgeSounds[3] = Properties.Resources.fourth_telly;
        _tellyBridgeSounds[4] = Properties.Resources.fifth_telly;
        _tellyBridgeSounds[5] = Properties.Resources.sixth_telly;
        _tellyBridgeSounds[6] = Properties.Resources.seventh_telly;
        _tellyBridgeSounds[7] = Properties.Resources.eight_telly;

        _tellyBridgeSoundsLength[0] = 5095;
        _tellyBridgeSoundsLength[1] = 4172;
        _tellyBridgeSoundsLength[2] = 13669;
        _tellyBridgeSoundsLength[3] = 5004;
        _tellyBridgeSoundsLength[4] = 6295;
        _tellyBridgeSoundsLength[5] = 5668;
        _tellyBridgeSoundsLength[6] = 7513;
        _tellyBridgeSoundsLength[7] = 4293;

        _dragClickSounds[0] = Properties.Resources.first_dragclick;
        _dragClickSounds[1] = Properties.Resources.second_dragclick;
        _dragClickSounds[2] = Properties.Resources.third_dragclick;
        _dragClickSounds[3] = Properties.Resources.fourth_dragclick;
        _dragClickSounds[4] = Properties.Resources.fifth_dragclick;
        _dragClickSounds[5] = Properties.Resources.sixth_dragclick;
        _dragClickSounds[6] = Properties.Resources.seventh_dragclick;
        _dragClickSounds[7] = Properties.Resources.eight_dragclick;
        _dragClickSounds[8] = Properties.Resources.ninth_dragclick;

        _dragClickSoundsLength[0] = 996;
        _dragClickSoundsLength[1] = 4843;
        _dragClickSoundsLength[2] = 4443;
        _dragClickSoundsLength[3] = 2784;
        _dragClickSoundsLength[4] = 3608;
        _dragClickSoundsLength[5] = 2575;
        _dragClickSoundsLength[6] = 1528;
        _dragClickSoundsLength[7] = 3193;
        _dragClickSoundsLength[8] = 1263;

        _normalRightClickSounds[0] = Properties.Resources.first_normal_click;
        _normalRightClickSounds[1] = Properties.Resources.second_normal_click;
        _normalRightClickSounds[2] = Properties.Resources.third_normal_click;
        _normalRightClickSounds[3] = Properties.Resources.fourth_normal_click;
        _normalRightClickSounds[4] = Properties.Resources.fifth_normal_click;
        _normalRightClickSounds[5] = Properties.Resources.sixth_normal_click;

        _normalRightClickSoundsLength[0] = 500;
        _normalRightClickSoundsLength[1] = 371;
        _normalRightClickSoundsLength[2] = 579;
        _normalRightClickSoundsLength[3] = 492;
        _normalRightClickSoundsLength[4] = 424;
        _normalRightClickSoundsLength[5] = 653;

        _breezilySounds[0] = Properties.Resources.first_breezily;
        _breezilySounds[1] = Properties.Resources.second_breezily;
        _breezilySounds[2] = Properties.Resources.third_breezily;

        _breezilySoundsLength[0] = 2489;
        _breezilySoundsLength[1] = 11504;
        _breezilySoundsLength[2] = 1876;

        _moonwalkSounds[0] = Properties.Resources.first_moonwalk;
        _moonwalkSounds[1] = Properties.Resources.second_moonwalk;
        _moonwalkSounds[2] = Properties.Resources.third_moonwalk;

        _moonwalkSoundsLength[0] = 7931;
        _moonwalkSoundsLength[1] = 3044;
        _moonwalkSoundsLength[2] = 3913;

        _leftNormalClickSounds[0] = Properties.Resources.first_left_normal_click;
        _leftNormalClickSounds[1] = Properties.Resources.second_left_normal_click;
        _leftNormalClickSounds[2] = Properties.Resources.third_left_normal_click;
        _leftNormalClickSounds[3] = Properties.Resources.fourth_left_normal_click;

        _leftNormalClickSoundsLength[0] = 523;
        _leftNormalClickSoundsLength[1] = 584;
        _leftNormalClickSoundsLength[2] = 853;
        _leftNormalClickSoundsLength[3] = 1099;

        _jitterClickSounds[0] = Properties.Resources.first_jitter;
        _jitterClickSounds[1] = Properties.Resources.second_jitter;
        _jitterClickSounds[2] = Properties.Resources.third_jitter;
        _jitterClickSounds[3] = Properties.Resources.fourth_jitter;
        _jitterClickSounds[4] = Properties.Resources.fifth_jitter;
        _jitterClickSounds[5] = Properties.Resources.sixth_jitter;

        _jitterClickSoundsLength[0] = 456;
        _jitterClickSoundsLength[1] = 276;
        _jitterClickSoundsLength[2] = 223;
        _jitterClickSoundsLength[3] = 264;
        _jitterClickSoundsLength[4] = 739;
        _jitterClickSoundsLength[5] = 1360;

        _butterflyClickSounds[0] = Properties.Resources.first_butterfly;
        _butterflyClickSounds[1] = Properties.Resources.second_butterfly;
        _butterflyClickSounds[2] = Properties.Resources.third_butterfly;
        _butterflyClickSounds[3] = Properties.Resources.fourth_butterfly;
        _butterflyClickSounds[4] = Properties.Resources.fifth_butterfly;
        _butterflyClickSounds[5] = Properties.Resources.sixth_butterfly;
        _butterflyClickSounds[6] = Properties.Resources.seventh_butterfly;
        _butterflyClickSounds[7] = Properties.Resources.eigth_butterfly;
        _butterflyClickSounds[8] = Properties.Resources.ninth_butterfly;

        _butterflyClickSoundsLength[0] = 2939;
        _butterflyClickSoundsLength[1] = 1111;
        _butterflyClickSoundsLength[2] = 733;
        _butterflyClickSoundsLength[3] = 1184;
        _butterflyClickSoundsLength[4] = 1083;
        _butterflyClickSoundsLength[5] = 1119;
        _butterflyClickSoundsLength[6] = 3090;
        _butterflyClickSoundsLength[7] = 2774;
        _butterflyClickSoundsLength[8] = 7478;
    }

    public static class SongsData
    {
        public static int NumberSounds;
        public static Stream[] Streams;
        public static int[] StreamsPlayed;
        public static int[] SoundsLength;
        public static Constants.ClickerType ClickerType;
    }

    private void LoadSoundData(int numberSounds, Stream[] streams, int[] soundsLength, Constants.ClickerType clickerType)
    {
        SongsData.StreamsPlayed = new int[numberSounds];
                        
        // Initialize streams played array to -1 (
        for (int i = 0; i < numberSounds; i++)
        {
            SongsData.StreamsPlayed[i] = -1;
        }

        SongsData.NumberSounds = numberSounds;
        SongsData.Streams = streams;
        SongsData.SoundsLength = soundsLength;
        SongsData.ClickerType = clickerType;
    }

    public async Task LeftClickSounds(bool isLeftClickerEnabled)
    {
        bool isSoundEnabled = Clicker.MainWindow.IsLeftNormalClickEnabled ||
                              Clicker.MainWindow.IsLeftJitterClickEnabled ||
                              Clicker.MainWindow.IsLeftButterflyClickEnabled;

        bool virtualClicks = MouseHook.Flag == 1;

        if (isSoundEnabled && LeftClickerCanStartNewSound && virtualClicks && isLeftClickerEnabled)
        {
            bool isRKain100Selected = Clicker.MainWindow.LeftClickerSoundPickerComboBox.SelectedIndex == 1;
            bool isNormalClickEnabled = Clicker.MainWindow.IsLeftNormalClickEnabled;
            bool isJitterClickEnabled = Clicker.MainWindow.IsLeftJitterClickEnabled;
            bool isButterflyClickEnabled = Clicker.MainWindow.IsLeftButterflyClickEnabled;

            if (isRKain100Selected)
            {
                if (isNormalClickEnabled)
                    LoadSoundData(NumberLeftNormalClicksSounds, _leftNormalClickSounds, _leftNormalClickSoundsLength, Constants.ClickerType.LeftClicker);
                else if (isJitterClickEnabled)
                    LoadSoundData(NumberJitterClickSounds, _jitterClickSounds, _jitterClickSoundsLength, Constants.ClickerType.LeftClicker);
                else if (isButterflyClickEnabled) 
                    LoadSoundData(NumberButterflyClickSounds, _butterflyClickSounds, _butterflyClickSoundsLength, Constants.ClickerType.LeftClicker);

                await Task.Run(() =>
                {
                    MakeSoundsThread = new Thread(_shuffleSounds.LeftClickerShuffleThread);
                    MakeSoundsThread.Priority = ThreadPriority.Normal;
                    MakeSoundsThread.Start();
                    LeftClickerThreadStarted = true;
                });
            }
        }
        else if (!isSoundEnabled)
        {
            /*
             * Starting with Windows 11, if a window-owning process becomes fully occluded,
             * minimized, or otherwise invisible or inaudible to the end user, Windows does
             * not guarantee a higher resolution than the default system resolution.
             */
             
            PlaySilenceSound();
        }
    }

    public async Task RightClickSounds(bool isRightClickerEnabled)
    {
        bool isSoundEnabled = Clicker.MainWindow.IsGodBridgeEnabled ||
                              Clicker.MainWindow.IsTellyBridgeEnabled ||
                              Clicker.MainWindow.IsDragClickEnabled ||
                              Clicker.MainWindow.IsRightNormalClickEnabled ||
                              Clicker.MainWindow.IsBreezilyEnabled ||
                              Clicker.MainWindow.IsMoonwalkEnabled;

        bool virtualClicks = MouseHook.Flag == 1;

        if (isSoundEnabled && RightClickerCanStartNewSound && virtualClicks && isRightClickerEnabled)
        {
            bool isRKain100Selected = Clicker.MainWindow.RightClickerSoundPickerComboBox.SelectedIndex == 1;
            bool isGodbridgeEnabled = Clicker.MainWindow.IsGodBridgeEnabled;
            bool isTellyEnabled = Clicker.MainWindow.IsTellyBridgeEnabled;
            bool isDragClickEnabled = Clicker.MainWindow.IsDragClickEnabled;
            bool isNormalClickEnabled = Clicker.MainWindow.IsRightNormalClickEnabled;
            bool isBreezilyEnabled = Clicker.MainWindow.IsBreezilyEnabled;
            bool isMoonwalkEnabled = Clicker.MainWindow.IsMoonwalkEnabled;

            if (isRKain100Selected)
            {
                if (isGodbridgeEnabled)
                    LoadSoundData(NumberGodBridgeSounds, _godBridgeSounds, _godBridgeSoundsLength, Constants.ClickerType.RightClicker);
                else if (isDragClickEnabled)
                    LoadSoundData(NumberDragClickSounds, _dragClickSounds, _dragClickSoundsLength, Constants.ClickerType.RightClicker);
                else if (isTellyEnabled)
                    LoadSoundData(NumberTellyBridgeSounds, _tellyBridgeSounds, _tellyBridgeSoundsLength, Constants.ClickerType.RightClicker);
                else if (isNormalClickEnabled)
                    LoadSoundData(NumberNormalRightClickSounds, _normalRightClickSounds, _normalRightClickSoundsLength, Constants.ClickerType.RightClicker);
                else if (isBreezilyEnabled)
                    LoadSoundData(NumberBreezilySounds, _breezilySounds, _breezilySoundsLength, Constants.ClickerType.RightClicker);
                else if (isMoonwalkEnabled) LoadSoundData(NumberMoonwalkSounds, _moonwalkSounds, _moonwalkSoundsLength, Constants.ClickerType.RightClicker);

                await Task.Run(() =>
                {
                    MakeSoundsThread = new Thread(_shuffleSounds.RightClickerShuffleThread)
                    {
                        Priority = ThreadPriority.Normal
                    };
                    MakeSoundsThread.Start();
                    RightClickerThreadStarted = true;
                });
            }
        }
        else if (!isSoundEnabled)
        {
            /*
             * Starting with Windows 11, if a window-owning process becomes fully occluded,
             * minimized, or otherwise invisible or inaudible to the end user, Windows does
             * not guarantee a higher resolution than the default system resolution.
             */
            PlaySilenceSound();
        }
    }

    private void PlaySilenceSound()
    {
        _mouseControl.SoundPlayer = new SoundPlayer(Properties.Resources.silence_sound); // sound length: 0.010s
        _mouseControl.SoundPlayer.Play();
    }

}
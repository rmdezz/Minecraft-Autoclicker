using System;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Threading;
using Autoclicker.clicker;
using Autoclicker.clicker.extra;
using Autoclicker.clicker.right_clicker;
using Autoclicker.hooks;
using Autoclicker.sound;

namespace Autoclicker.mouse_control;

public class MouseControl
{
    public readonly Clicker Clicker;
    private readonly JitterUtil _jitterUtil;
    private readonly BlockhitUtil _blockhitUtil;
    private readonly RefillUtil _refillUtil;
    private readonly MouseControlUtil _mouseControlUtil;
    public readonly SoundData SoundData;
    private readonly BreakBlocksUtil _breakBlocksUtil;
        
    public SoundPlayer SoundPlayer = new();

    /* Retrieves the position of the mouse cursor, in screen coordinates. */
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point lpPoint);

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int x, int y);


    public readonly DispatcherTimer FadeOutTimer = new();


    public MouseControl(Clicker clicker, MainWindow mainWindow)
    {
        Clicker = clicker;
        _jitterUtil = new JitterUtil();
        _blockhitUtil = new BlockhitUtil(mainWindow, this);
        _refillUtil = new RefillUtil(mainWindow);
        _mouseControlUtil = new MouseControlUtil();
        SoundData = new SoundData(this);
        FadeOutSound fadeOutSound = new FadeOutSound(this, SoundData);


        FadeOutTimer.Interval = TimeSpan.FromMilliseconds(100);
        FadeOutTimer.Tick += fadeOutSound.SoundFadeOut_Tick;
        _breakBlocksUtil = new BreakBlocksUtil(this);
    }
        
    public async void LeftMouseDown(Point pointLocator)
    {
        Clicker.LeftDown = true;


        bool isLeftClickerEnabled = MouseControlUtil.IsLeftClickerEnabled();
        Task task1 = SoundData.LeftClickSounds(isLeftClickerEnabled);
        Task task2 = _jitterUtil.LeftJitterToggle(isLeftClickerEnabled);
        Task task3 = _refillUtil.RefillToggle(isLeftClickerEnabled);
        await Task.WhenAll(task1, task2, task3);
    }
        
    public async void LeftMouseUp(Point pointLocator)
    {
        _breakBlocksUtil.BreakBlocksToggle();
        StopLeftSounds();
        await _blockhitUtil.BlockhitToggle();
    }

    private void StopLeftSounds()
    {   
        if (MouseHook.Flag == 0 && SoundData.LeftClickerThreadStarted) // real key up && thread started
        {
            FadeOutTimer.Start();
        }
    }

    public async void RightMouseDown(Point pointLocator)
    {
        Clicker.RightDown = true;

        bool isRightClickerEnabled = _mouseControlUtil.IsRightClickerEnabled();
        Task task1 = SoundData.RightClickSounds(isRightClickerEnabled);
        Task task2 =  _jitterUtil.RightClickerToggle(isRightClickerEnabled);
        await Task.WhenAll(task1, task2);
    }
        
    public void RightMouseUp(Point pointLocator)
    {
        if (MouseHook.Flag == 0 && SoundData.RightClickerThreadStarted) // real key up && thread started
        {
            FadeOutTimer.Start();
        }

        if (!RightClicker.IgnoreNextRelease) Clicker.RightDown = false;
        RightClicker.IgnoreNextRelease = false;
    }
}
using System.Threading;

namespace Autoclicker.clicker.left_clicker;

public class LeftClicker
{
    private readonly Clicker _clicker;
    public static bool IgnoreNextRelease;
        
    public LeftClicker(Clicker clicker)
    {
        _clicker = clicker;
    }
    
    

    public async void left_clicker()
    {
        /* Declaration of variables */
        ClickerData.LeftClicker.OldCps = 0;
        ClickerData.LeftClicker.OldCpsMs = 0;
        ClickerData.LeftClicker.OldLowerCpsMs = 0;
        ClickerData.LeftClicker.OldUpperCpsMs = 0;
            
        while (MainWindow.IsRunning && !MainWindow.LeftClickerThreadAborted)
        {
            if (Clicker.MainWindow.Dispatcher == null) return;
            
            await LeftClickerUtil.DisableWhenInventoryOpen();
             
            LeftClickerValues.SetMaxCPS();
                
            double cps = LeftClickerValues.GetLeftClickerCps();
            LeftClickerValues.SetMaxBoundValues(cps);
            
            double lowerBound = LeftClickerValues.GetLeftClickerLowerBound();
            LeftClickerValues.SetCpsDropMaxValue(cps, lowerBound);
                
            string caption = ClickerUtil.GetCaption();
            bool isMinecraftFocused = ClickerUtil.IsMinecraftFocused(caption);
            bool onlyInMinecraft = ClickerUtil.IsOnlyInMinecraftChecked();
            bool isClickerEnabled = Clicker.MainWindow.IsLeftClickerEnabled;

            /* Taking advantage of the LeftClicker thread instead of generating another thread to validate that Minecraft is open. */
            //bool isMinecraftRunning = IsMinecraftRunning(false);
            //DisplayMinecraftStatus(isMinecraftRunning);
            
            if (!onlyInMinecraft) isMinecraftFocused = true;
                
            bool canStart = _clicker.LeftDown && isClickerEnabled && isMinecraftFocused;

            if (canStart)
            {
                WinApi.TimeBeginPeriod(1); // Set Sleep resolution to 1ms
                uint currentRes = 0;
                WinApi.NtSetTimerResolution(5000, true, ref currentRes); // It sets the timer resolution to 0.5ms when combined with TimeBeginPeriod.
                await LeftClickerUtil.MakeLeftClicks(cps, lowerBound);
                WinApi.TimeEndPeriod(1); // Clears previously set minimum timer resolution.
            }
            else
            {
                Clicker.MainWindow.FirstLeftClick = true;
                Thread.Sleep(100);
            }
        }
    }
}
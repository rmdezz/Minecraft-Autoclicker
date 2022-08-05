using System.Threading;

namespace Autoclicker.clicker.right_clicker;

public class RightClicker
{
    private static Clicker _clicker;
    public static bool IgnoreNextRelease;
        
    public RightClicker(Clicker clicker)
    {
        _clicker = clicker;
    }

    public static async void right_clicker()
    {
        ClickerData.RightClicker.OldCps = 0;
        ClickerData.RightClicker.OldCpsMs = 0;
        ClickerData.RightClicker.OldLowerCpsMs = 0;
        ClickerData.RightClicker.OldUpperCpsMs = 0;

        while (MainWindow.IsRunning && !MainWindow.RightClickerThreadAborted)
        {
            if (Clicker.MainWindow.Dispatcher == null) return;
                
            string caption = ClickerUtil.GetCaption();
            bool isMinecraftFocused = ClickerUtil.IsMinecraftFocused(caption);
            bool onlyInMinecraft = ClickerUtil.IsOnlyInMinecraftChecked();
                
            if (!onlyInMinecraft) isMinecraftFocused = true;
            
            /* Set max value of bounds slider */
            double cps = RightClickerValues.GetCps();
            RightClickerValues.SetMaxBoundsValues(cps);
            /* Set Cps Drop Max value */
            double lowerBound = RightClickerValues.GetLowerBound();
            RightClickerValues.SetCpsDropMaxValue(cps, lowerBound);

            bool canStart = _clicker.RightDown && Clicker.MainWindow.IsRightClickerEnabled && isMinecraftFocused;

            if (canStart)
            {
                WinApi.TimeBeginPeriod(1); // Set Sleep resolution to 1ms
                uint currentRes = 0;
                WinApi.NtSetTimerResolution(5000, true, ref currentRes); // It sets the timer resolution to 0.5ms when combined with TimeBeginPeriod.
                await RightClickerUtil.MakeRightClicks(cps, lowerBound);
                WinApi.TimeEndPeriod(1); // Clears previously set minimum timer resolution.
            }
            else
            {
                Clicker.MainWindow.FirstRightClick = true;
                Thread.Sleep(100);
            }
        }
    }
}
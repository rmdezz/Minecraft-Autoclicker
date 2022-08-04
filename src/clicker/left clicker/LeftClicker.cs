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
                
            /* Set max value of bounds slider */
            double cps = LeftClickerValues.GetLeftClickerCps();
            LeftClickerValues.SetMaxBoundValues(cps);

            double lowerBound = LeftClickerValues.GetLeftClickerLowerBound();
            double upperBound = LeftClickerValues.GetLeftClickerUpperBound();
            
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
                
            if (canStart) await LeftClickerUtil.MakeLeftClicks(cps, lowerBound, upperBound);
            else
            {
                Clicker.MainWindow.FirstLeftClick = true;
                Thread.Sleep(100);
            }
        }
    }
}
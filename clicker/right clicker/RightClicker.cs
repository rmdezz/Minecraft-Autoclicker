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

        while (MainWindow.IsRunning)
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
                
            if (canStart) await RightClickerUtil.MakeRightClicks(cps, lowerBound);
            else
            {
                Clicker.MainWindow.FirstRightClick = true;
                Thread.Sleep(100);
            }
        }
    }
}
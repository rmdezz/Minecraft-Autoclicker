using System;
using System.Threading.Tasks;

namespace Autoclicker.clicker.left_clicker;

public static class LeftClickerPauseDelay
{
    public static async Task Wait()
    {
        double seconds = GetWaitSeconds();
        int firstDecimal = LeftClickerUtil.GetFirstDecimal(seconds);
        int delayValue;
        if (firstDecimal >= 5) delayValue = (int) Math.Round(seconds, MidpointRounding.AwayFromZero);
        else delayValue = (int) Math.Truncate(seconds);

        await Task.Delay(delayValue * Constants.Second); // ms
    }

    private static double GetWaitSeconds()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.InventoryDelaySlider.Value);
    }
}
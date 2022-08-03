using System.Windows.Forms;
using Autoclicker.clicker;

namespace Autoclicker.mouse_control;

public class MouseControlUtil
{
    public static bool IsRefillKeysDown()
    {
        return MainWindow.GetAsyncKeyState(Clicker.MainWindow.GetInventoryKey) && MainWindow.GetAsyncKeyState((int)Keys.LShiftKey);
    }

    public static bool IsRefillSpeedEnabled()
    {
        return Clicker.MainWindow.RefillSpeedCheckbox.IsChecked != null && Clicker.MainWindow.RefillSpeedCheckbox.IsChecked.Value;
    }

    public static bool IsLeftJitterValid()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftJitterXAxis.Value > 0 && Clicker.MainWindow.LeftJitterYAxis.Value > 0);
    }

    public static bool IsLeftJitterEnabled()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.JitterCheckbox.IsChecked != null && Clicker.MainWindow.JitterCheckbox.IsChecked.Value);
    }

    public static bool IsLeftClickerEnabled()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.IsLeftClickerEnabled);
    }

    public static bool IsBlockhitValid()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftBlockhitProbabilitySlider.Value > 0);
    }

    public static bool IsBlockHitEnabled()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.BlockhitCheckbox.IsChecked != null && Clicker.MainWindow.BlockhitCheckbox.IsChecked.Value);
    }

    public static bool IsBreakBlocksEnabled()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.BreakBlocksCheckbox.IsChecked != null && Clicker.MainWindow.BreakBlocksCheckbox.IsChecked.Value);
    }

    public static bool IsRightJitterValid()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightClickerJitterXAxis.Value > 0 && Clicker.MainWindow.RightClickerJitterYAxis.Value > 0);
    }

    public static bool IsRightJitterEnabled()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightJitterCheckbox.IsChecked != null && Clicker.MainWindow.RightJitterCheckbox.IsChecked.Value);
    }

    public bool IsRightClickerEnabled()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.IsRightClickerEnabled);
    }
}
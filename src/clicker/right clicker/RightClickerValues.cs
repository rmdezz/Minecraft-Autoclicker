using System;

namespace Autoclicker.clicker.right_clicker;

public static class RightClickerValues
{
    public static double GetDropCps()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightCpsDropAmountSlider.Value);
    }

    public static double GetDropProbability()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightCpsDropAmountSlider.Value);
    }

    public static bool NewValues(double cps, double lowerBound, double upperBound)
    {
        bool cpsHasChanged = Math.Abs(ClickerData.RightClicker.OldCps - cps) > Constants.Tolerance;
        bool lowerBoundHasChanged = Math.Abs(ClickerData.RightClicker.LowerBound - lowerBound) > Constants.Tolerance;
        bool upperBoundHasChanged = Math.Abs(ClickerData.RightClicker.UpperBound - upperBound) > Constants.Tolerance;
        bool newValues = cpsHasChanged || lowerBoundHasChanged || upperBoundHasChanged;
        return newValues;
    }

    public static double GetUpperBound()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightUpperCpsSlider.Value);
    }

    public static void SetCpsDropMaxValue(double cps, double lowerBound)
    {
        Clicker.MainWindow.Dispatcher.Invoke(() =>
            Clicker.MainWindow.RightCpsDropAmountSlider.Maximum = cps - lowerBound - 1);
    }

    public static double GetLowerBound()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightLowerCpsSlider.Value);
    }

    public static void SetMaxBoundsValues(double cps)
    {
        double maxLowerCps = cps - 1;
        Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightLowerCpsSlider.Maximum = maxLowerCps);
            
        double maxUpperCps = Constants.CpsLimit - cps;
        Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightUpperCpsSlider.Maximum = maxUpperCps);
    }

    public static double GetCps()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightCpsSlider.Value);
    }
}
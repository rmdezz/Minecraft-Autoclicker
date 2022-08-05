using System;

namespace Autoclicker.clicker.left_clicker;

public static class LeftClickerValues
{
    public static bool NewValues(double cps, double lowerBound, double upperBound)
    {
        bool cpsHasChanged = Math.Abs(ClickerData.LeftClicker.OldCps - cps) > Constants.Tolerance;
        bool lowerBoundHasChanged = Math.Abs(ClickerData.LeftClicker.LowerBound - lowerBound) > Constants.Tolerance;
        bool upperBoundHasChanged = Math.Abs(ClickerData.LeftClicker.UpperBound - upperBound) > Constants.Tolerance;
        bool newValues = cpsHasChanged || lowerBoundHasChanged || upperBoundHasChanged;
        return newValues;
    }
    
    public static double GetDropCps()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftCpsDropAmountSlider.Value);
    }

    public static double GetDropProbability()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftCpsDropProbabilitySlider.Value);
    }

    public static bool IsBreakBlocksChecked()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.BreakBlocksCheckbox.IsChecked != null && Clicker.MainWindow.BreakBlocksCheckbox.IsChecked.Value);
    }

    public static double GetLeftClickerUpperBound()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftUpperCpsSlider.Value);
    }

    public static double GetLeftClickerLowerBound()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftLowerCpsSlider.Value);
    }

    public static void SetMaxBoundValues(double cps)
    {
        double maxLowerCps = cps - 1;
        Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftLowerCpsSlider.Maximum = maxLowerCps);
        double cpsLimit = Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.CpsDelimiterSlider.Value);
        double maxUpperCps = cpsLimit - cps;
        Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftUpperCpsSlider.Maximum = maxUpperCps);
    }

    public static double GetLeftClickerCps()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftCpsSlider.Value);
    }

    public static void SetCpsDropMaxValue(double cps, double lowerBound)
    {
        Clicker.MainWindow.Dispatcher.Invoke(() =>
            Clicker.MainWindow.LeftCpsDropAmountSlider.Maximum = cps - lowerBound - 1);
    }

    public static void SetMaxCPS()
    {
        Clicker.MainWindow.Dispatcher.Invoke(() =>
        {
            double cpsLimit = Clicker.MainWindow.CpsDelimiterSlider.Value;
            Clicker.MainWindow.LeftCpsSlider.Maximum = cpsLimit;
        });
    }
}
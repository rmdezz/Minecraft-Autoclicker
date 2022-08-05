using System;
using System.Windows;

namespace Autoclicker.display;

public class DisplayRightClickerValues
{
    private readonly DisplayValues _displayValues;

    public DisplayRightClickerValues(DisplayValues displayValues)
    {
        _displayValues = displayValues;
    }

    public void RightCpsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightCpsText.Content = Math.Round(_displayValues.MainWindow.RightCpsSlider.Value, 2) + " CPS";
    }

    public void RightLowerCpsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightLowerCpsText.Content = Math.Round(_displayValues.MainWindow.RightLowerCpsSlider.Value, 2) + " LESS CPS";
    }

    public void RightUpperCpsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightUpperCpsText.Content = Math.Round(_displayValues.MainWindow.RightUpperCpsSlider.Value, 2) + " MORE CPS";
    }

    public void RightCpsDropAmountSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightCpsDropAmountText.Content = Math.Round(_displayValues.MainWindow.RightCpsDropAmountSlider.Value, 2) + " CPS";
    }

    public void RightCpsDropProbabilitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightCpsDropProbabilityText.Content = Math.Round(_displayValues.MainWindow.RightCpsDropProbabilitySlider.Value, 2) + " %";
    }

    public void RightClicker_JitterXAxis_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightXAxisText.Content = Math.Round(_displayValues.MainWindow.RightClickerJitterXAxis.Value, 2) + " SHIFT";
    }

    public void RightClicker_JitterYAxis_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightYAxisText.Content = Math.Round(_displayValues.MainWindow.RightClickerJitterYAxis.Value, 2) + " SHIFT";
    }

    public void RainbowDelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RainbowDelayLabel.Content = Math.Round(_displayValues.MainWindow.RainbowDelaySlider.Value, 2) + " MS";
    }

    public void RightCpsDelimiterValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RightCpsDelimiterText.Content = Math.Round(_displayValues.MainWindow.RightCpsDelimiterSlider.Value, 2) + " MAX CPS";
        _displayValues.MainWindow.RightCpsSlider.Maximum = _displayValues.MainWindow.RightCpsDelimiterSlider.Value;
    }
}
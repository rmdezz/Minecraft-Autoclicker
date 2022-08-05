using System;
using System.Windows;

namespace Autoclicker.display;

public class DisplayLeftClickerValues
{
    private readonly DisplayValues _displayValues;

    public DisplayLeftClickerValues(DisplayValues displayValues)
    {
        _displayValues = displayValues;
    }

    public void LeftCpsDropAmountSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.CpsDropAmountText.Content = Math.Round(_displayValues.MainWindow.LeftCpsDropAmountSlider.Value, 2) + " CPS";
    }

    public void LeftCpsDropProbabilitySliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.CpsDropProbabilityText.Content = Math.Round(_displayValues.MainWindow.LeftCpsDropProbabilitySlider.Value, 2) + " %";
    }

    public void RefillSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RefillText.Content = Math.Round(_displayValues.MainWindow.RefillSpeedSlider.Value, 2) + " VELOCITY";
    }

    public void LeftBlockhitProbabilitySliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.BlockhitText.Content = Math.Round(_displayValues.MainWindow.LeftBlockhitProbabilitySlider.Value, 2) + " %";
    }

    public void inventory_delay_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.InventoryDelayText.Content = Math.Round(_displayValues.MainWindow.InventoryDelaySlider.Value, 2) + " SECS";
    }

    public void LeftJitterYAxisValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.YAxisText.Content = Math.Round(_displayValues.MainWindow.LeftJitterYAxis.Value, 2) + " SHIFT";
    }

    public void LeftJitterXAxisValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.XAxisText.Content = Math.Round(_displayValues.MainWindow.LeftJitterXAxis.Value, 2) + " SHIFT";
    }

    public void LeftCpsSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.CpsText.Content = Math.Round(_displayValues.MainWindow.LeftCpsSlider.Value, 2) + " CPS";
    }

    public void RefillXAxisRandomSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RefillXAxisText.Content = Math.Round(_displayValues.MainWindow.RefillXAxisRandomSlider.Value, 2) + " SHIFT";
    }

    public void RefillYAxisRandomSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RefillYAxisText.Content = Math.Round(_displayValues.MainWindow.RefillYAxisRandomSlider.Value, 2) + " SHIFT";
    }

    public void RefillStepsRandomSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.RefillStepsText.Content = Math.Round(_displayValues.MainWindow.RefillStepsRandomSlider.Value, 2) + " STEPS";
    }

    public void LeftLowerCpsSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.LowerCpsText.Content = Math.Round(_displayValues.MainWindow.LeftLowerCpsSlider.Value, 2) + " LESS CPS";
    }

    public void LeftUpperCpsSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.UpperCpsText.Content = Math.Round(_displayValues.MainWindow.LeftUpperCpsSlider.Value, 2) + " MORE CPS";
    }

    public void BlockhitDelaySliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.BlockhitDelayText.Content = Math.Round(_displayValues.MainWindow.BlockhitDelaySlider.Value, 2) + " MS";
    }
    
    public void LeftCpsDelimiterValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _displayValues.MainWindow.CpsDelimiterText.Content = Math.Round(_displayValues.MainWindow.CpsDelimiterSlider.Value, 2) + " MAX CPS";
        _displayValues.MainWindow.LeftCpsSlider.Maximum = _displayValues.MainWindow.CpsDelimiterSlider.Value;
    }
}
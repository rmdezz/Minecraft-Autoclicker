using System.Threading;
using System.Windows;

namespace Autoclicker.components.events.color;

public class RainbowColorEvents
{
    private ComponentsEvents _componentsEvents;

    public RainbowColorEvents(ComponentsEvents componentsEvents)
    {
        _componentsEvents = componentsEvents;
    }

    public void rainbow_checkbox_Checked(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.RainbowThread = new Thread(_componentsEvents.MainWindow.ColorPicker.CustomRainbow)
        {
            Priority = ThreadPriority.BelowNormal
        };
        MainWindow.RainbowThreadAborted = false;
        _componentsEvents.MainWindow.RainbowThread.Start();
    }

    public void rainbow_checkbox_Unchecked(object sender, RoutedEventArgs e)
    {
        MainWindow.RainbowThreadAborted = true;
        if (_componentsEvents.MainWindow.RainbowThread.IsAlive) _componentsEvents.MainWindow.RainbowThread.Abort();
    }

    public void ResetToDefaultCheckbox_Checked(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.ColorPicker.SetDefaultColors();
    }
}
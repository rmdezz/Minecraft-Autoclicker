using System.Threading;
using System.Windows;
using System.Windows.Input;
using Autoclicker.clicker.right_clicker;

namespace Autoclicker.components.events.right_Clicker;

public class RightClickerEvents
{
    private ComponentsEvents _componentsEvents;

    public RightClickerEvents(ComponentsEvents componentsEvents)
    {
        _componentsEvents = componentsEvents;
    }

    public void right_clicker_Click(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.RightClickerButton.KeyDown += right_clicker_KeyDown;
    }

    public void right_clicker_KeyDown(object sender, KeyEventArgs e)
    {
        _componentsEvents.MainWindow.RightClickerButton.Content = e.Key;
        _componentsEvents.MainWindow.RightClickerKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _componentsEvents.MainWindow.RightClickerButton.KeyDown -= right_clicker_KeyDown; // remove KeyDown event
        e.Handled = true;
    }

    public void RightClickerCheckbox_Checked(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.RightClickerThread = new Thread(RightClicker.right_clicker)
        {
            Priority = ThreadPriority.Highest
        };
        MainWindow.RightClickerThreadAborted = false;
        _componentsEvents.MainWindow.RightClickerThread.Start();
        
    }

    public void RightClickerCheckbox_Unchecked(object sender, RoutedEventArgs e)
    {
        MainWindow.RightClickerThreadAborted = true;
        if (_componentsEvents.MainWindow.RightClickerThread.IsAlive) _componentsEvents.MainWindow.RightClickerThread?.Abort();
    }
}
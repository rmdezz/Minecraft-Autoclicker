using System.Threading;
using System.Windows;
using System.Windows.Input;
using Autoclicker.clicker;

namespace Autoclicker.components.events.left_clicker;

public class LeftClickerEvents
{
    private ComponentsEvents _componentsEvents;
    private MainWindow _mainWindow;

    public LeftClickerEvents(ComponentsEvents componentsEvents, MainWindow mainWindow)
    {
        _componentsEvents = componentsEvents;
        _mainWindow = mainWindow;
    }

    public void LeftClickerKeyBindButton_KeyDown(object sender, KeyEventArgs e)
    {
        _componentsEvents.MainWindow.LeftClickerKeyBindButton.Content = e.Key;
        _componentsEvents.MainWindow.LeftClickerKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _componentsEvents.MainWindow.LeftClickerKeyBindButton.KeyDown -= LeftClickerKeyBindButton_KeyDown;
        e.Handled = true;
    }

    public void LeftClickerKeyBindButton_Click(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.LeftClickerKeyBindButton.KeyDown += LeftClickerKeyBindButton_KeyDown; // Add KeyDown event
    }

    public void inventory_button_Click(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.InventoryKeyBindButton.KeyDown += inventory_button_KeyDown; // Add KeyDown event
    }

    public void inventory_button_KeyDown(object sender, KeyEventArgs e)
    {
        _componentsEvents.MainWindow.InventoryKeyBindButton.Content = e.Key;
        _componentsEvents.MainWindow.GetInventoryKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _componentsEvents.MainWindow.InventoryKeyBindButton.KeyDown -= inventory_button_KeyDown; // remove KeyDown event
        e.Handled = true;
    }

    public void LeftClickerCheckbox_Checked(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.LeftClickerThread = new Thread(Clicker.LeftClicker.left_clicker)
        {
            Priority = ThreadPriority.Highest
        };
        MainWindow.LeftClickerThreadAborted = false;

        _componentsEvents.MainWindow.LeftClickerThread.Start();
    }

    public void LeftClickerCheckbox_Unchecked(object sender, RoutedEventArgs e)
    {
        MainWindow.LeftClickerThreadAborted = true;
        if (_componentsEvents.MainWindow.LeftClickerThread.IsAlive) _componentsEvents.MainWindow.LeftClickerThread?.Abort();
    }
}

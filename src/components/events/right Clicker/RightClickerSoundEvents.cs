using System.Windows;
using System.Windows.Input;

namespace Autoclicker.components.events.right_Clicker;

public class RightClickerSoundEvents
{
    private readonly ComponentsEvents _componentsEvents;
    private readonly MainWindow _mainWindow;

    public RightClickerSoundEvents(ComponentsEvents componentsEvents, MainWindow mainWindow)
    {
        _componentsEvents = componentsEvents;
        _mainWindow = mainWindow;
    }

    public void NormalLeftClick_KeyDown(object sender, KeyEventArgs e)
    {
        _componentsEvents.MainWindow.LeftNormalClickButton.Content = e.Key;
        _componentsEvents.MainWindow.LeftNormalClickKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _componentsEvents.MainWindow.LeftNormalClickButton.KeyDown -= NormalLeftClick_KeyDown;
    }

    public void NormalLeftClick_Click(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.LeftNormalClickButton.KeyDown += NormalLeftClick_KeyDown; // Add KeyDown event
    }

    public void JitterLeftClick_KeyDown(object sender, KeyEventArgs e)
    {
        _componentsEvents.MainWindow.JitterButton.Content = e.Key;
        _componentsEvents.MainWindow.JitterKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _componentsEvents.MainWindow.JitterButton.KeyDown -= JitterLeftClick_KeyDown;
    }

    public void JitterLeftClick_Click(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.LeftNormalClickButton.KeyDown += NormalLeftClick_KeyDown; // Add KeyDown event
    }

    public void ButterflyClick_KeyDown(object sender, KeyEventArgs e)
    {
        _componentsEvents.MainWindow.ButterflyButton.Content = e.Key;
        _componentsEvents.MainWindow.ButterflyKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _componentsEvents.MainWindow.ButterflyButton.KeyDown -= ButterflyClick_KeyDown;
    }

    public void ButterflyClick_Click(object sender, RoutedEventArgs e)
    {
        _componentsEvents.MainWindow.ButterflyButton.KeyDown += ButterflyClick_KeyDown; // Add KeyDown event
    }

    public void RightClickingMethodSoundComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (_mainWindow.RightClickingMethodSoundComboBox.SelectedIndex == 0) // normal click
        {
            ShowRightSoundButton(_mainWindow.RightNormalClickingButton);
        }
        else if (_mainWindow.RightClickingMethodSoundComboBox.SelectedIndex == 1) // drag click
        {
            ShowRightSoundButton(_mainWindow.DragClickButton);
        }
        else if (_mainWindow.RightClickingMethodSoundComboBox.SelectedIndex == 2) // breezily
        {
            ShowRightSoundButton(_mainWindow.BreezilyButton);
        }
        else if (_mainWindow.RightClickingMethodSoundComboBox.SelectedIndex == 3) // god bridge
        {
            ShowRightSoundButton(_mainWindow.GodBridgeButton);
        }
        else if (_mainWindow.RightClickingMethodSoundComboBox.SelectedIndex == 4) // telly bridge
        {
            ShowRightSoundButton(_mainWindow.TellyBridgeButton);
        }
        else if (_mainWindow.RightClickingMethodSoundComboBox.SelectedIndex == 5) // moonwalk
        {
            ShowRightSoundButton(_mainWindow.MoonwalkButton);
        }
    }

    private void ShowRightSoundButton(UIElement button)
    {
        CollapseRightSoundsButton();
        button.Visibility = Visibility.Visible;
    }

    private void CollapseRightSoundsButton()
    {
        _mainWindow.RightNormalClickingButton.Visibility = Visibility.Collapsed;
        _mainWindow.DragClickButton.Visibility = Visibility.Collapsed;
        _mainWindow.BreezilyButton.Visibility = Visibility.Collapsed;
        _mainWindow.GodBridgeButton.Visibility = Visibility.Collapsed;
        _mainWindow.TellyBridgeButton.Visibility = Visibility.Collapsed;
        _mainWindow.MoonwalkButton.Visibility = Visibility.Collapsed;
    }
    
    public void GodBridgeKeyDown(object sender, KeyEventArgs e)
    {
        _mainWindow.GodBridgeButton.Content = e.Key;
        _mainWindow.GodBridgeKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _mainWindow.GodBridgeButton.KeyDown -= GodBridgeKeyDown;
    }
    
    public void GodBridgeClick(object sender, RoutedEventArgs e)
    {
        _mainWindow.GodBridgeButton.KeyDown += GodBridgeKeyDown; // Add KeyDown event
    }
    
    public void right_normal_clicking_KeyDown(object sender, KeyEventArgs e)
    {
        _mainWindow.RightNormalClickingButton.Content = e.Key;
        _mainWindow.RightNormalClickKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _mainWindow.RightNormalClickingButton.KeyDown -= right_normal_clicking_KeyDown;
    }
    
    public void right_normal_clicking_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.RightNormalClickingButton.KeyDown += right_normal_clicking_KeyDown; // Add KeyDown event
    }
    
    public void breezily_keyDown(object sender, KeyEventArgs e)
    {
        _mainWindow.BreezilyButton.Content = e.Key;
        _mainWindow.BreezilyKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _mainWindow.BreezilyButton.KeyDown -= breezily_keyDown;
    }
    
    public void breezily_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.BreezilyButton.KeyDown += breezily_keyDown; // Add KeyDown event
    }
    
    public void moonwalk_KeyDown(object sender, KeyEventArgs e)
    {
        _mainWindow.MoonwalkButton.Content = e.Key;
        _mainWindow.MoonwalkKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _mainWindow.MoonwalkButton.KeyDown -= moonwalk_KeyDown;
    }
    
    public void moonwalk_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.MoonwalkButton.KeyDown += moonwalk_KeyDown; // Add KeyDown event
    }
    
    public void DragClick_KeyDown(object sender, KeyEventArgs e)
    {
        _mainWindow.DragClickButton.Content = e.Key;
        _mainWindow.DragClickKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _mainWindow.DragClickButton.KeyDown -= DragClick_KeyDown;
    }
    
    public void DragClick_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.DragClickButton.KeyDown += DragClick_KeyDown; // Add KeyDown event
    }

    public void TellyBridge_KeyDown(object sender, KeyEventArgs e)
    {
        _mainWindow.TellyBridgeButton.Content = e.Key;
        _mainWindow.TellyBridgeKey = KeyInterop.VirtualKeyFromKey(e.Key);
        _mainWindow.TellyBridgeButton.KeyDown -= TellyBridge_KeyDown;
    }
    
    public void TellyBridge_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.TellyBridgeButton.KeyDown += TellyBridge_KeyDown; // Add KeyDown event
    }
}
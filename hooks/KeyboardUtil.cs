using System.Runtime.InteropServices;
using System.Windows.Input;
using Autoclicker.clicker;

namespace Autoclicker.hooks;

public class Worker
{
    private readonly MainWindow _mainWindow;
    public readonly KeyboardHook KeyHook = new();
    public Worker(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        KeyHook.KeyUp += KeyUp;
        KeyHook.Install();
    }
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetAsyncKeyState(int vKey);
    
    
    private void KeyUp(Key key)
    {
        ClickerToggle(key, _mainWindow.LeftClickerKey, ref _mainWindow.IsLeftClickerEnabled, _mainWindow.LeftClickerStatusText, "ENABLED", "DISABLED");
        ClickerToggle(key, _mainWindow.RightClickerKey, ref _mainWindow.IsRightClickerEnabled, _mainWindow.RightClickerStatusText, "ENABLED", "DISABLED");
        SoundToggle(key, _mainWindow.GodBridgeKey, ref _mainWindow.IsGodBridgeEnabled, _mainWindow.RightClickSoundType, Constants.ClickerType.RightClicker, "God Bridge Clicking","NULL");
        SoundToggle(key, _mainWindow.DragClickKey, ref _mainWindow.IsDragClickEnabled, _mainWindow.RightClickSoundType, Constants.ClickerType.RightClicker, "Drag Clicking", "NULL");
        SoundToggle(key, _mainWindow.TellyBridgeKey, ref _mainWindow.IsTellyBridgeEnabled, _mainWindow.RightClickSoundType, Constants.ClickerType.RightClicker, "Butterfly Clicking","NULL");
        SoundToggle(key, _mainWindow.RightNormalClickKey, ref _mainWindow.IsRightNormalClickEnabled, _mainWindow.RightClickSoundType, Constants.ClickerType.RightClicker, "Normal Clicking","NULL");
        SoundToggle(key, _mainWindow.BreezilyKey, ref _mainWindow.IsBreezilyEnabled, _mainWindow.RightClickSoundType, Constants.ClickerType.RightClicker, "Breezily Clicking","NULL");
        SoundToggle(key, _mainWindow.MoonwalkKey, ref _mainWindow.IsMoonwalkEnabled, _mainWindow.RightClickSoundType, Constants.ClickerType.RightClicker, "Moonwalk Clicking","NULL");
       
        SoundToggle(key, _mainWindow.LeftNormalClickKey, ref _mainWindow.IsLeftNormalClickEnabled, _mainWindow.LeftClickSoundType, Constants.ClickerType.RightClicker, "Normal Clicking","NULL");
        SoundToggle(key, _mainWindow.JitterKey, ref _mainWindow.IsLeftJitterClickEnabled, _mainWindow.LeftClickSoundType, Constants.ClickerType.RightClicker, "Jitter Clicking","NULL");
        SoundToggle(key, _mainWindow.ButterflyKey, ref _mainWindow.IsLeftButterflyClickEnabled, _mainWindow.LeftClickSoundType, Constants.ClickerType.RightClicker, "Butterfly Clicking","NULL");
        
    }

    private void SoundToggle(Key key, int soundKey, ref bool toggle, System.Windows.Controls.Label label, Constants.ClickerType clickerType, string enabledMessage, string disabledMessage)
    {
        if (key == (Key) soundKey)
        {
            toggle = !toggle;

            if (toggle)
            {
                DisableOtherClickingMethods(clickerType);
                toggle = true;
                DisplaySoundStatus(label, enabledMessage);
            }
            else DisplaySoundStatus(label, disabledMessage);
        }
    }

    //Constants.RightClickingMethods rightClickingMethod, Constants.LeftClickingMethods, string clickerType
    private void DisableOtherClickingMethods(Constants.ClickerType clickerType)
    {
        if (clickerType == Constants.ClickerType.RightClicker)
        {
            DisableAllRightClickingMethods();
        }
        else if (clickerType == Constants.ClickerType.LeftClicker)
        {
            DisableAllLeftClickingMethods();
        }
    }

    private void DisableAllRightClickingMethods()
    {
        _mainWindow.IsGodBridgeEnabled = false;
        _mainWindow.IsDragClickEnabled = false;
        _mainWindow.IsRightNormalClickEnabled = false;
        _mainWindow.IsBreezilyEnabled = false;
        _mainWindow.IsLeftButterflyClickEnabled = false;
    }

    private void DisableAllLeftClickingMethods()
    {
        _mainWindow.IsLeftNormalClickEnabled = false;
        _mainWindow.IsLeftJitterClickEnabled = false;
        _mainWindow.IsLeftButterflyClickEnabled = false;
    }

    private void DisplaySoundStatus(System.Windows.Controls.Label label, string message)
    {
        _mainWindow.Dispatcher.Invoke(() => label.Content = message);
    }

    private void ClickerToggle(Key key, int clickerKey, ref bool toggle, System.Windows.Controls.Label label, string enabledMessage, string disabledMessage)
    {
        if (key == (Key) clickerKey)
        {
            toggle = !toggle;

            if (toggle) DisplayClickerStatus(label, enabledMessage);
            else DisplayClickerStatus(label, disabledMessage);
        }
    }
    
    private void DisplayClickerStatus(System.Windows.Controls.Label label, string message)
    {
        _mainWindow.Dispatcher.Invoke(() => label.Content = message);
    }
}
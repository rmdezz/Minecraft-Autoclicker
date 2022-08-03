using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Autoclicker.clicker;

public static class ClickerUtil
{
    [DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int cch);
    
    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

    public static string GetCaption()
    {
        StringBuilder stringBuilder = new StringBuilder(256);
        GetWindowText(GetForegroundWindow(), stringBuilder, stringBuilder.Capacity);
        return stringBuilder.ToString();
    }
    
    public static bool IsMinecraftFocused(string caption)
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => caption.Contains("Lunar") || caption.Contains("Minecraft") || caption.Contains(Clicker.MainWindow.MinecraftClientTextBox.Text));
    }
    
    public static bool IsOnlyInMinecraftChecked()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.OnlyInMinecraftCheckbox.IsChecked != null && Clicker.MainWindow.OnlyInMinecraftCheckbox.IsChecked.Value);
    }
    
    public static void SimulateRightButtonDown()
    {
        mouse_event((int)Constants.MouseEventFlags.RightDown, 0, 0, 0, 0);
    }

    public static void SimulateRightButtonUp()
    {
        mouse_event((int)Constants.MouseEventFlags.RightUp, 0, 0, 0, 0);
    }
    
    public static void SimulateLeftButtonUp()
    {
        mouse_event((int) Constants.MouseEventFlags.LeftUp, 0, 0, 0, 0);
    }

    public static void SimulateLeftButtonDown()
    {
        mouse_event((int)Constants.MouseEventFlags.LeftDown, 0, 0, 0 ,0);
    }
}
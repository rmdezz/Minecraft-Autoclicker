using System.Diagnostics;
using System.Threading;
using Autoclicker.clicker;

namespace Autoclicker.display;

public class MinecraftUtil
{
    private bool _isMinecraftRunning;
    private MainWindow _mainWindow;
    public MinecraftUtil(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        _mainWindow.MinecraftThread = new Thread(CheckMinecraftProcess)
        {
            Priority = ThreadPriority.BelowNormal
        };
        _mainWindow.MinecraftThread.Start();
        
    }
    
    private void CheckMinecraftProcess()
    {
        while (MainWindow.IsRunning)
        {
            _isMinecraftRunning = IsMinecraftRunning(false);
            DisplayMinecraftStatus(_isMinecraftRunning);
            Thread.Sleep(1000);
        }
    }

    private static bool IsMinecraftRunning(bool isMinecraftRunning)
    {
        // Get all instances of Minecraft running on the local computer.
        // This will return an empty array if Minecraft isn't running.
            
        Process[] localByName = Process.GetProcessesByName("javaw");
        if (localByName.Length > 0) isMinecraftRunning = true;
        return isMinecraftRunning;
    }

    private static void DisplayMinecraftStatus(bool isMinecraftRunning)
    {
        if (isMinecraftRunning)
        {
            Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.IsMinecraftOpenStatusText.Content = "TRUE");
        }
        else
        {
            Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.IsMinecraftOpenStatusText.Content = "FALSE");
        }
    }
}
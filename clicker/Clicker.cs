using Autoclicker.clicker.left_clicker;
using Autoclicker.clicker.right_clicker;
using Autoclicker.hooks;
using Autoclicker.mouse_control;

namespace Autoclicker.clicker;

public class Clicker
{
    public static MainWindow MainWindow;
    public readonly MouseHook MouseHook = new();
    public bool LeftDown;
    public static LeftClicker LeftClicker;
    public static MouseControl MouseControl;
    public bool RightDown;
    private static RightClicker _rightClicker;
    public Clicker(MainWindow mainWindow)
    {
        MainWindow = mainWindow;
        MouseControl = new MouseControl(this, mainWindow);
        MouseHook.MouseLeftDown += MouseControl.LeftMouseDown;
        MouseHook.MouseLeftUp += MouseControl.LeftMouseUp;
        MouseHook.MouseRightDown += MouseControl.RightMouseDown;
        MouseHook.MouseRightUp += MouseControl.RightMouseUp;
        MouseHook.InstallMouseHook();
        _rightClicker = new RightClicker(this);
        LeftClicker = new LeftClicker(this);
    }
}
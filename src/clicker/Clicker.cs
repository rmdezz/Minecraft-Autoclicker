using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;
using Autoclicker.clicker.left_clicker;
using Autoclicker.clicker.right_clicker;
using Autoclicker.hooks;
using Autoclicker.mouse_control;

namespace Autoclicker.clicker;


public static class WinApi
{
    /// <summary>TimeBeginPeriod(). See the Windows API documentation for details.</summary>

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
    [DllImport("winmm.dll", EntryPoint="timeBeginPeriod", SetLastError=true)]

    public static extern uint TimeBeginPeriod(uint uMilliseconds);

    /// <summary>TimeEndPeriod(). See the Windows API documentation for details.</summary>

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
    [DllImport("winmm.dll", EntryPoint="timeEndPeriod", SetLastError=true)]

    public static extern uint TimeEndPeriod(uint uMilliseconds);
    
    [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]

    public static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
}



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
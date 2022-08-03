using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Autoclicker.clicker;

namespace Autoclicker.hooks;

public class MouseHook
{
    #region WinAPI
    [DllImport("user32", EntryPoint = "SetWindowsHookExA")]
    private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, int hmod, int dwThreadId); //More info: https://docs.microsoft.com/es-es/windows/win32/winmsg/using-hooks?redirectedfrom=MSDN
    [DllImport("user32")]
    private static extern int CallNextHookEx(int hhk, int nCode, int wParam, Msllhookstruct lParam); //More info: https://docs.microsoft.com/es-es/windows/win32/api/winuser/nf-winuser-callnexthookex?redirectedfrom=MSDN
    [DllImport("user32")]
    private static extern int UnhookWindowsHookEx(int hHook);
        
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
        
    private delegate int HookProc(int nCode, int wParam, ref Msllhookstruct lParam);
    private int _mouseHook;
    public const int HcAction = 0;
    //public const int WhMouseLl = 14;

    [StructLayout(LayoutKind.Sequential)] //More info: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.structlayoutattribute?redirectedfrom=MSDN&view=netframework-4.8
    public struct Msllhookstruct
    {
        public Point pt;
        public uint  mouseData;
        public uint flags;
        public uint time;
        public IntPtr  dwExtraInfo;
            
    } 
    /*public enum WheelDirection
    {
        WheelUp,
        WheelDown
    }
    */
    private enum MouseMessages
    {
        WmLbuttondown = 0x0201,
        WmLbuttonup = 0x0202,
        WmMousemove = 0x0200,
        //WM_MOUSEWHEEL = 0x020A,
        WmRbuttondown = 0x0204,
        WmRbuttonup = 0x0205,
        //WM_LBUTTONDBLCLK = 0x0203,
        //WM_RBUTTONDBLCLK = 0x0206,
        //WM_MBUTTONDOWN = 0x0207,
        //WM_MBUTTONUP = 0x0208
    }
    #endregion

    #region Mouse Events
    private HookProc _mouseHookProcedure;
    public delegate void MouseMoveEventHandler(Point ptLocat);
    public delegate void MouseLeftDownEventHandler(Point ptLocat);
    public delegate void MouseLeftUpEventHandler(Point ptLocat);
    //public delegate void MouseLeftDoubleClickEventHandler(Point ptLocat);
    public delegate void MouseRightDownEventHandler(Point ptLocat);
    public delegate void MouseRightUpEventHandler(Point ptLocat);
    //public delegate void MouseRightDoubleClickEventHandler(Point ptLocat);
    //public delegate void MouseMiddleDownEventHandler(Point ptLocat);
    //public delegate void MouseMiddleUpEventHandler(Point ptLocat);
    //public delegate void MouseMiddleDoubleClickEventHandler(Point ptLocat);
    //public delegate void MouseWheelEventHandler(Point ptLocat, WheelDirection direction);

    public event MouseMoveEventHandler MouseMove;
    public event MouseLeftDownEventHandler MouseLeftDown;      
    public event MouseLeftUpEventHandler MouseLeftUp;
    //public event MouseLeftDoubleClickEventHandler MouseLeftDoubleClick;
    public event MouseRightDownEventHandler MouseRightDown;
    public event MouseRightUpEventHandler MouseRightUp;
    //public event MouseRightDoubleClickEventHandler MouseRightDoubleClick;
    //public event MouseMiddleDownEventHandler MouseMiddleDown;
    //public event MouseMiddleUpEventHandler MouseMiddleUp;
    //public event MouseMiddleDoubleClickEventHandler MouseMiddleDoubleClick;
    //public event MouseWheelEventHandler MouseWheel;
    #endregion

    #region LowLevelKeyboardProc callback function

    public static class HookStructData
    {
        public static Msllhookstruct Msllhookstruct;
    }
        

    public static uint Flag;
        
    //More info: https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms644985(v=vs.85)?redirectedfrom=MSDN
    private int LowLevelKeyboardProc(int nCode, int wParam, ref Msllhookstruct lParam) 
    {
        if (nCode < HcAction) return CallNextHookEx(_mouseHook, nCode, wParam, lParam);

        //More info: https://docs.microsoft.com/es-es/windows/win32/api/winuser/nf-winuser-callnexthookex?redirectedfrom=MSDN
            
        Msllhookstruct hookStruct = lParam;
        Flag = hookStruct.flags;
        
        //_flag = lParam.flags;

        bool isMouseStatusEnabled =
            Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.ToggleMouseStatus.IsChecked != null && Clicker.MainWindow.ToggleMouseStatus.IsChecked.Value);

        if (isMouseStatusEnabled)
        {
            Clicker.MainWindow.Dispatcher.Invoke(() =>
            {
                Clicker.MainWindow.ScreenXAxisText.Content = hookStruct.pt.X;
                Clicker.MainWindow.ScreenYAxisText.Content = hookStruct.pt.Y;
                if (hookStruct.flags == 1) Clicker.MainWindow.SimulatedClickStatusText.Content = "TRUE";
                else Clicker.MainWindow.SimulatedClickStatusText.Content = "FALSE";
            });
        }
            
            
        //Clicker.mainWindow.Dispatcher.Invoke(() => Clicker.mainWindow.LeftClickerStatusText.Content = hookStruct.pt.X + " " + hookStruct.pt.Y + " " + _flag);
            
            
        //HookStructData.msllhookstruct = lParam;

        //DisplayScreenCoordsAndMouseFlag(HookStructData.msllhookstruct);
            
        switch (wParam)
        {
            case (int)MouseMessages.WmMousemove:
                MouseMove?.Invoke(lParam.pt);
                break;
            case (int)MouseMessages.WmLbuttondown:
                MouseLeftDown?.Invoke(lParam.pt);
                break;
            case (int)MouseMessages.WmLbuttonup:
                MouseLeftUp?.Invoke(lParam.pt);
                break;
            case (int)MouseMessages.WmRbuttondown:
                MouseRightDown?.Invoke(lParam.pt);
                break;
            case (int)MouseMessages.WmRbuttonup:
                MouseRightUp?.Invoke(lParam.pt);
                break;
            /*
            case (int)MouseMessages.WM_RBUTTONDBLCLK:
            MouseRightDoubleClick?.Invoke(lParam.pt);
            break;
            case (int)MouseMessages.WM_LBUTTONDBLCLK:
            MouseLeftDoubleClick?.Invoke(lParam.pt);
            break; 
            case (int)MouseMessages.WM_MBUTTONDOWN:
            MouseMiddleDown?.Invoke(lParam.pt);
            break;
            case (int)MouseMessages.WM_MBUTTONUP:
            MouseMiddleUp?.Invoke(lParam.pt);
            break;
            case (int)MouseMessages.WM_MBUTTONDBLCLK:
            MouseMiddleDoubleClick?.Invoke(lParam.pt);
            break;
            case (int)MouseMessages.WM_MOUSEHWHEEL:
            {
                var wDirection = lParam.mouseData < 0 ? WheelDirection.WheelDown : WheelDirection.WheelUp;
                MouseWheel?.Invoke(lParam.pt, wDirection);
                break;
            }
            */
        }
        return CallNextHookEx(_mouseHook, nCode, wParam, lParam);
    }

    public static async Task DisplayScreenCoordsAndMouseFlag(Msllhookstruct hookStruct)
    {
        await Task.Run(() =>
        {
            Clicker.MainWindow.Dispatcher.Invoke(() =>
            {
                Clicker.MainWindow.ScreenXAxisText.Content = hookStruct.pt.X;
                Clicker.MainWindow.ScreenYAxisText.Content = hookStruct.pt.Y;
                if (hookStruct.flags == 1) Clicker.MainWindow.SimulatedClickStatusText.Content = "TRUE";
                else Clicker.MainWindow.SimulatedClickStatusText.Content = "FALSE";
            });
        });
    }

    //private static IntPtr SetHook(HookProc proc)
    //{
    //    using (var curProcess = Process.GetCurrentProcess())
    //   using (var curModule = curProcess.MainModule)
    //   {
    //       return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
    //   }
    // }
        
    private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    private const int WhMouseLl = 14;

    #endregion

    public void InstallMouseHook() // More info: https://docs.microsoft.com/es-es/windows/win32/api/winuser/nf-winuser-setwindowshookexa?redirectedfrom=MSDN
    {
        _mouseHookProcedure = LowLevelKeyboardProc;
        // Msllhookstruct hookStruct = lParam;
        //_flag = lParam.flags;
        //await Task.Run(()=> DisplayScreenCoordsAndMouseFlag(hookStruct));
        _mouseHook = SetWindowsHookEx(WhMouseLl, _mouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);
    }

    public void UninstallMouseHook() //More info: https://docs.microsoft.com/es-es/windows/win32/api/winuser/nf-winuser-unhookwindowshookex
    {
        UnhookWindowsHookEx(hHook: _mouseHook);
    }
}
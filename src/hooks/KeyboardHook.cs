using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Autoclicker.hooks;

public class KeyboardHook
{
	private delegate IntPtr KeyboardHookHandler(int nCode, IntPtr wParam, IntPtr lParam);

	public delegate void KeyboardHookCallback(Key key);

	private KeyboardHookHandler _hookHandler;

	private IntPtr _hookId = IntPtr.Zero;

	public event KeyboardHookCallback KeyDown;

	public event KeyboardHookCallback KeyUp;

	public void Install()
	{
		_hookHandler = HookFunc;
		_hookId = SetHook(_hookHandler);
	}

	public void Uninstall()
	{
		UnhookWindowsHookEx(_hookId);
	}

	private static IntPtr SetHook(KeyboardHookHandler proc)
	{
		using ProcessModule processModule = Process.GetCurrentProcess().MainModule;
		return SetWindowsHookEx(13, proc, GetModuleHandle(processModule?.ModuleName), 0u);
	}

	private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
	{
		if (nCode >= 0)
		{
			int num = wParam.ToInt32();
			if ((num == 256 || num == 260) && KeyDown != null)
			{
				KeyDown((Key) Marshal.ReadInt32(lParam));
			}
			if ((num == 257 || num == 261) && KeyUp != null)
			{
				KeyUp((Key) Marshal.ReadInt32(lParam));
			}
		}
		return CallNextHookEx(_hookId, nCode, wParam, lParam);
	}

	~KeyboardHook()
	{
		Uninstall();
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookHandler lpfn, IntPtr hMod, uint dwThreadId);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool UnhookWindowsHookEx(IntPtr hhk);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr GetModuleHandle(string lpModuleName);
}
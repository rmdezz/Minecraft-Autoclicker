using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Drown.Include
{
    public static partial class InputHelper
    {
        private static Keys ReplaceBadKeys(Keys key)
        {
            var key1 = key;
            if (key1.HasFlag(Keys.Control))
                key1 = key1 & (Keys.KeyCode | Keys.LButton | Keys.RButton | Keys.Cancel | Keys.MButton | Keys.XButton1 | Keys.XButton2 | Keys.Back | Keys.Tab | Keys.LineFeed | Keys.Clear | Keys.Return | Keys.Enter | Keys.ShiftKey | Keys.ControlKey | Keys.Menu | Keys.Pause | Keys.Capital | Keys.CapsLock | Keys.KanaMode | Keys.HanguelMode | Keys.HangulMode | Keys.JunjaMode | Keys.FinalMode | Keys.HanjaMode | Keys.KanjiMode | Keys.Escape | Keys.IMEConvert | Keys.IMENonconvert | Keys.IMEAccept | Keys.IMEAceept | Keys.IMEModeChange | Keys.Space | Keys.Prior | Keys.PageUp | Keys.Next | Keys.PageDown | Keys.End | Keys.Home | Keys.Left | Keys.Up | Keys.Right | Keys.Down | Keys.Select | Keys.Print | Keys.Execute | Keys.Snapshot | Keys.PrintScreen | Keys.Insert | Keys.Delete | Keys.Help | Keys.D0 | Keys.D1 | Keys.D2 | Keys.D3 | Keys.D4 | Keys.D5 | Keys.D6 | Keys.D7 | Keys.D8 | Keys.D9 | Keys.A | Keys.B | Keys.C | Keys.D | Keys.E | Keys.F | Keys.G | Keys.H | Keys.I | Keys.J | Keys.K | Keys.L | Keys.M | Keys.N | Keys.O | Keys.P | Keys.Q | Keys.R | Keys.S | Keys.T | Keys.U | Keys.V | Keys.W | Keys.X | Keys.Y | Keys.Z | Keys.LWin | Keys.RWin | Keys.Apps | Keys.Sleep | Keys.NumPad0 | Keys.NumPad1 | Keys.NumPad2 | Keys.NumPad3 | Keys.NumPad4 | Keys.NumPad5 | Keys.NumPad6 | Keys.NumPad7 | Keys.NumPad8 | Keys.NumPad9 | Keys.Multiply | Keys.Add | Keys.Separator | Keys.Subtract | Keys.Decimal | Keys.Divide | Keys.F1 | Keys.F2 | Keys.F3 | Keys.F4 | Keys.F5 | Keys.F6 | Keys.F7 | Keys.F8 | Keys.F9 | Keys.F10 | Keys.F11 | Keys.F12 | Keys.F13 | Keys.F14 | Keys.F15 | Keys.F16 | Keys.F17 | Keys.F18 | Keys.F19 | Keys.F20 | Keys.F21 | Keys.F22 | Keys.F23 | Keys.F24 | Keys.NumLock | Keys.Scroll | Keys.LShiftKey | Keys.RShiftKey | Keys.LControlKey | Keys.RControlKey | Keys.LMenu | Keys.RMenu | Keys.BrowserBack | Keys.BrowserForward | Keys.BrowserRefresh | Keys.BrowserStop | Keys.BrowserSearch | Keys.BrowserFavorites | Keys.BrowserHome | Keys.VolumeMute | Keys.VolumeDown | Keys.VolumeUp | Keys.MediaNextTrack | Keys.MediaPreviousTrack | Keys.MediaStop | Keys.MediaPlayPause | Keys.LaunchMail | Keys.SelectMedia | Keys.LaunchApplication1 | Keys.LaunchApplication2 | Keys.OemSemicolon | Keys.Oem1 | Keys.Oemplus | Keys.Oemcomma | Keys.OemMinus | Keys.OemPeriod | Keys.OemQuestion | Keys.Oem2 | Keys.Oemtilde | Keys.Oem3 | Keys.OemOpenBrackets | Keys.Oem4 | Keys.OemPipe | Keys.Oem5 | Keys.OemCloseBrackets | Keys.Oem6 | Keys.OemQuotes | Keys.Oem7 | Keys.Oem8 | Keys.OemBackslash | Keys.Oem102 | Keys.ProcessKey | Keys.Packet | Keys.Attn | Keys.Crsel | Keys.Exsel | Keys.EraseEof | Keys.Play | Keys.Zoom | Keys.NoName | Keys.Pa1 | Keys.OemClear | Keys.Shift | Keys.Alt) | Keys.ControlKey;
            if (key1.HasFlag(Keys.Shift))
                key1 = key1 & (Keys.KeyCode | Keys.LButton | Keys.RButton | Keys.Cancel | Keys.MButton | Keys.XButton1 | Keys.XButton2 | Keys.Back | Keys.Tab | Keys.LineFeed | Keys.Clear | Keys.Return | Keys.Enter | Keys.ShiftKey | Keys.ControlKey | Keys.Menu | Keys.Pause | Keys.Capital | Keys.CapsLock | Keys.KanaMode | Keys.HanguelMode | Keys.HangulMode | Keys.JunjaMode | Keys.FinalMode | Keys.HanjaMode | Keys.KanjiMode | Keys.Escape | Keys.IMEConvert | Keys.IMENonconvert | Keys.IMEAccept | Keys.IMEAceept | Keys.IMEModeChange | Keys.Space | Keys.Prior | Keys.PageUp | Keys.Next | Keys.PageDown | Keys.End | Keys.Home | Keys.Left | Keys.Up | Keys.Right | Keys.Down | Keys.Select | Keys.Print | Keys.Execute | Keys.Snapshot | Keys.PrintScreen | Keys.Insert | Keys.Delete | Keys.Help | Keys.D0 | Keys.D1 | Keys.D2 | Keys.D3 | Keys.D4 | Keys.D5 | Keys.D6 | Keys.D7 | Keys.D8 | Keys.D9 | Keys.A | Keys.B | Keys.C | Keys.D | Keys.E | Keys.F | Keys.G | Keys.H | Keys.I | Keys.J | Keys.K | Keys.L | Keys.M | Keys.N | Keys.O | Keys.P | Keys.Q | Keys.R | Keys.S | Keys.T | Keys.U | Keys.V | Keys.W | Keys.X | Keys.Y | Keys.Z | Keys.LWin | Keys.RWin | Keys.Apps | Keys.Sleep | Keys.NumPad0 | Keys.NumPad1 | Keys.NumPad2 | Keys.NumPad3 | Keys.NumPad4 | Keys.NumPad5 | Keys.NumPad6 | Keys.NumPad7 | Keys.NumPad8 | Keys.NumPad9 | Keys.Multiply | Keys.Add | Keys.Separator | Keys.Subtract | Keys.Decimal | Keys.Divide | Keys.F1 | Keys.F2 | Keys.F3 | Keys.F4 | Keys.F5 | Keys.F6 | Keys.F7 | Keys.F8 | Keys.F9 | Keys.F10 | Keys.F11 | Keys.F12 | Keys.F13 | Keys.F14 | Keys.F15 | Keys.F16 | Keys.F17 | Keys.F18 | Keys.F19 | Keys.F20 | Keys.F21 | Keys.F22 | Keys.F23 | Keys.F24 | Keys.NumLock | Keys.Scroll | Keys.LShiftKey | Keys.RShiftKey | Keys.LControlKey | Keys.RControlKey | Keys.LMenu | Keys.RMenu | Keys.BrowserBack | Keys.BrowserForward | Keys.BrowserRefresh | Keys.BrowserStop | Keys.BrowserSearch | Keys.BrowserFavorites | Keys.BrowserHome | Keys.VolumeMute | Keys.VolumeDown | Keys.VolumeUp | Keys.MediaNextTrack | Keys.MediaPreviousTrack | Keys.MediaStop | Keys.MediaPlayPause | Keys.LaunchMail | Keys.SelectMedia | Keys.LaunchApplication1 | Keys.LaunchApplication2 | Keys.OemSemicolon | Keys.Oem1 | Keys.Oemplus | Keys.Oemcomma | Keys.OemMinus | Keys.OemPeriod | Keys.OemQuestion | Keys.Oem2 | Keys.Oemtilde | Keys.Oem3 | Keys.OemOpenBrackets | Keys.Oem4 | Keys.OemPipe | Keys.Oem5 | Keys.OemCloseBrackets | Keys.Oem6 | Keys.OemQuotes | Keys.Oem7 | Keys.Oem8 | Keys.OemBackslash | Keys.Oem102 | Keys.ProcessKey | Keys.Packet | Keys.Attn | Keys.Crsel | Keys.Exsel | Keys.EraseEof | Keys.Play | Keys.Zoom | Keys.NoName | Keys.Pa1 | Keys.OemClear | Keys.Control | Keys.Alt) | Keys.ShiftKey;
            if (key1.HasFlag(Keys.Alt))
                key1 = key1 & (Keys.KeyCode | Keys.LButton | Keys.RButton | Keys.Cancel | Keys.MButton | Keys.XButton1 | Keys.XButton2 | Keys.Back | Keys.Tab | Keys.LineFeed | Keys.Clear | Keys.Return | Keys.Enter | Keys.ShiftKey | Keys.ControlKey | Keys.Menu | Keys.Pause | Keys.Capital | Keys.CapsLock | Keys.KanaMode | Keys.HanguelMode | Keys.HangulMode | Keys.JunjaMode | Keys.FinalMode | Keys.HanjaMode | Keys.KanjiMode | Keys.Escape | Keys.IMEConvert | Keys.IMENonconvert | Keys.IMEAccept | Keys.IMEAceept | Keys.IMEModeChange | Keys.Space | Keys.Prior | Keys.PageUp | Keys.Next | Keys.PageDown | Keys.End | Keys.Home | Keys.Left | Keys.Up | Keys.Right | Keys.Down | Keys.Select | Keys.Print | Keys.Execute | Keys.Snapshot | Keys.PrintScreen | Keys.Insert | Keys.Delete | Keys.Help | Keys.D0 | Keys.D1 | Keys.D2 | Keys.D3 | Keys.D4 | Keys.D5 | Keys.D6 | Keys.D7 | Keys.D8 | Keys.D9 | Keys.A | Keys.B | Keys.C | Keys.D | Keys.E | Keys.F | Keys.G | Keys.H | Keys.I | Keys.J | Keys.K | Keys.L | Keys.M | Keys.N | Keys.O | Keys.P | Keys.Q | Keys.R | Keys.S | Keys.T | Keys.U | Keys.V | Keys.W | Keys.X | Keys.Y | Keys.Z | Keys.LWin | Keys.RWin | Keys.Apps | Keys.Sleep | Keys.NumPad0 | Keys.NumPad1 | Keys.NumPad2 | Keys.NumPad3 | Keys.NumPad4 | Keys.NumPad5 | Keys.NumPad6 | Keys.NumPad7 | Keys.NumPad8 | Keys.NumPad9 | Keys.Multiply | Keys.Add | Keys.Separator | Keys.Subtract | Keys.Decimal | Keys.Divide | Keys.F1 | Keys.F2 | Keys.F3 | Keys.F4 | Keys.F5 | Keys.F6 | Keys.F7 | Keys.F8 | Keys.F9 | Keys.F10 | Keys.F11 | Keys.F12 | Keys.F13 | Keys.F14 | Keys.F15 | Keys.F16 | Keys.F17 | Keys.F18 | Keys.F19 | Keys.F20 | Keys.F21 | Keys.F22 | Keys.F23 | Keys.F24 | Keys.NumLock | Keys.Scroll | Keys.LShiftKey | Keys.RShiftKey | Keys.LControlKey | Keys.RControlKey | Keys.LMenu | Keys.RMenu | Keys.BrowserBack | Keys.BrowserForward | Keys.BrowserRefresh | Keys.BrowserStop | Keys.BrowserSearch | Keys.BrowserFavorites | Keys.BrowserHome | Keys.VolumeMute | Keys.VolumeDown | Keys.VolumeUp | Keys.MediaNextTrack | Keys.MediaPreviousTrack | Keys.MediaStop | Keys.MediaPlayPause | Keys.LaunchMail | Keys.SelectMedia | Keys.LaunchApplication1 | Keys.LaunchApplication2 | Keys.OemSemicolon | Keys.Oem1 | Keys.Oemplus | Keys.Oemcomma | Keys.OemMinus | Keys.OemPeriod | Keys.OemQuestion | Keys.Oem2 | Keys.Oemtilde | Keys.Oem3 | Keys.OemOpenBrackets | Keys.Oem4 | Keys.OemPipe | Keys.Oem5 | Keys.OemCloseBrackets | Keys.Oem6 | Keys.OemQuotes | Keys.Oem7 | Keys.Oem8 | Keys.OemBackslash | Keys.Oem102 | Keys.ProcessKey | Keys.Packet | Keys.Attn | Keys.Crsel | Keys.Exsel | Keys.EraseEof | Keys.Play | Keys.Zoom | Keys.NoName | Keys.Pa1 | Keys.OemClear | Keys.Shift | Keys.Control) | Keys.Menu;
            return key1;
        }

        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false, SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        public static void SetKeyState(Keys key, bool keyUp)
        {
            key = ReplaceBadKeys(key);
            var kEybdinput = new Keybdinput
            {
                wVk = Conversions.ToUShort(key),
                wScan = Conversions.ToShort(0),
                time = 0,
                dwFlags = Conversions.ToUInteger(keyUp ? Keyeventf.Keyup : 0),
                dwExtraInfo = IntPtr.Zero
            };
            var nPutunion = new Inputunion
            {
                ki = kEybdinput
            };
            var nPut = new Input
            {
                type = 1,
                u = nPutunion
            };
            SendInput(Conversions.ToUInteger(1), new[] { nPut }, Marshal.SizeOf(typeof(Input)));
        }

        private struct Hardwareinput
        {
            public short WParamL { get; private set; }

            public void SetWParamL(short value) => WParamL = value;

            public short WParamH { get; set; }
            public int UMsg { get; set; }

            public int GetUMsg()
            {
                return UMsg;
            }

            public void SetUMsg(int value)
            {
                UMsg = value;
            }
        }

        private struct Input
        {
            public int type;

            public Inputunion u;
        }

        private enum Inputtype : uint
        {
            Mouse,
            Keyboard,
            Hardware
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Inputunion
        {
            [FieldOffset(0)] private readonly Mouseinput mi;

            [FieldOffset(0)]
            public Keybdinput ki;

            [FieldOffset(0)] private readonly Hardwareinput hi;
        }

        private struct Keybdinput
        {
            public ushort wVk;

            public short wScan;

            public uint dwFlags;

            public int time;

            public IntPtr dwExtraInfo;
        }

        private struct Mouseinput
        {
            public int Time { get; set; }
            public int Dx { get; set; }
            public int Dy { get; set; }
            public int MouseData { get; set; }
            public int DwFlags { get; set; }
            public IntPtr DwExtraInfo { get; set; }
        }
    }
}

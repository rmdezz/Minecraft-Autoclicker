using System;

namespace Autoclicker.clicker;

public class Constants
{
    [Flags]
    public enum MouseEventFlags
    {
        Absolute = 0x8000,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        RightDown = 0x0008,
        RightUp = 0x0010
    }
        
    public const double Tolerance = 0.0000001;
    public const int CpsLimit = 500;
    public const int HalfSecond = 500; // ms
    public const int Second = 1000; //ms

    public enum ClickerType
    {
        RightClicker,
        LeftClicker
    }

    public enum RightClickingMethods
    {
        Butterfly,
        DragClick,
        GodBridge,
        NormalClick,
        Breezily,
        Moonwalk
    }

    public enum LeftClickingMethods
    {
        Normal,
        Jitter,
        Butterfly
    }
}
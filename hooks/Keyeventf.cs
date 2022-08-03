using System;

namespace Drown.Include
{
    public static partial class InputHelper
    {
        [Flags]
        private enum Keyeventf : uint
        {
            Extendedkey = 1,
            Keyup = 2,
            Unicode = 4,
            Scancode = 8
        }
    }
}

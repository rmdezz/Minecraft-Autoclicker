using Autoclicker.clicker.left_clicker;
using Autoclicker.mouse_control;

namespace Autoclicker.clicker.extra;

public class BreakBlocksUtil
{
    private readonly MouseControl _mouseControl;

    public BreakBlocksUtil(MouseControl mouseControl)
    {
        _mouseControl = mouseControl;
    }

    public void BreakBlocksToggle()
    {
        bool breakBlocks = MouseControlUtil.IsBreakBlocksEnabled();

        if (!breakBlocks)
        {
            if (!LeftClicker.IgnoreNextRelease) _mouseControl.Clicker.LeftDown = false;
            LeftClicker.IgnoreNextRelease = false;
        }
        else
            _mouseControl.Clicker.LeftDown = false;
    }
}
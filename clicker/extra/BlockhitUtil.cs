using System.Threading.Tasks;
using Autoclicker.mouse_control;
using Autoclicker.random_generator;

namespace Autoclicker.clicker.extra;

public class BlockhitUtil
{
    private readonly MainWindow _mainWindow;
    private MouseControl _mouseControl;

    public BlockhitUtil(MainWindow mainWindow, MouseControl mouseControl)
    {
        _mainWindow = mainWindow;
        _mouseControl = mouseControl;
    }

    private void SimulateBlockhit()
    {
        double getProbability = Random.NextDoubleLinear(0, 101);
        double probability = _mainWindow.Dispatcher.Invoke(() => _mainWindow.LeftBlockhitProbabilitySlider.Value);

        if (getProbability <= probability)
        {
            double ms = _mainWindow.Dispatcher.Invoke(() => _mainWindow.BlockhitDelaySlider.Value);
            int additionalTime = (int) ((ms - (int) ms) * 10);

            ClickerUtil.SimulateRightButtonDown();
            Task.Delay((int) ms - additionalTime); // Default: 500 ms
            ClickerUtil.SimulateRightButtonUp();
            Task.Delay((int) ms - additionalTime);
        }
    }

    public async Task BlockhitToggle()
    {
        bool isLeftClickerEnabled = MouseControlUtil.IsLeftClickerEnabled();
        bool isBlockHitEnabled = MouseControlUtil.IsBlockHitEnabled();
        bool isBlockhitValid = MouseControlUtil.IsBlockhitValid();
        string caption = ClickerUtil.GetCaption();
        bool isMinecraftFocused = ClickerUtil.IsMinecraftFocused(caption);

        if (isLeftClickerEnabled && isBlockHitEnabled && isBlockhitValid && isMinecraftFocused)
            await Task.Run(SimulateBlockhit);
    }
        
}
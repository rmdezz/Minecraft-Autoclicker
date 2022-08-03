using System.Drawing;
using System.Threading.Tasks;
using Autoclicker.mouse_control;
using Autoclicker.random_generator;

namespace Autoclicker.clicker.extra;

public class RefillUtil
{
    private readonly MainWindow _mainWindow;
    
    public RefillUtil(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    private async Task Refill()
    {
        double mouseSpeed = GetMouseSpeed();
        MouseControl.GetCursorPos(out Point point);

        double getUserStepXRandom = GetUserStepXRandom();
        double getUserXAxisRandom = GetUserXAxisRandom();
        double getUserYAxisRandom = GetUserYAxisRandom();

        double stepXRandom = Random.NextDoubleLinear(getUserStepXRandom - 10, getUserStepXRandom);
        double yAxisRandom = Random.NextDoubleLinear(-getUserXAxisRandom, getUserXAxisRandom);
        double xAxisRandom = Random.NextDoubleLinear(-getUserYAxisRandom, getUserYAxisRandom);

        await Task.Run(() =>
            MoveMouseUtil.MoveMouse(mouseSpeed, point.X + (int) xAxisRandom, point.Y + (int) yAxisRandom, (int) stepXRandom, 0));
    }

    public async Task RefillToggle(bool isLeftClickerEnabled)
    {
        bool isRefillSpeedEnabled = MouseControlUtil.IsRefillSpeedEnabled();
        bool keysPressed = MouseControlUtil.IsRefillKeysDown();
        bool canRefill = isLeftClickerEnabled && isRefillSpeedEnabled && keysPressed;
        if (canRefill) await Refill();
    }

    private double GetUserYAxisRandom()
    {
        return _mainWindow.Dispatcher.Invoke(() => _mainWindow.RefillYAxisRandomSlider.Value);
    }

    private double GetUserXAxisRandom()
    {
        return _mainWindow.Dispatcher.Invoke(() => _mainWindow.RefillXAxisRandomSlider.Value);
    }

    private double GetUserStepXRandom()
    {
        return _mainWindow.Dispatcher.Invoke(() => _mainWindow.RefillStepsRandomSlider.Value);
    }

    private double GetMouseSpeed()
    {
        return _mainWindow.Dispatcher.Invoke(() => _mainWindow.RefillSpeedSlider.Value);
    }
}
using System.Drawing;
using System.Threading.Tasks;
using Autoclicker.mouse_control;
using Autoclicker.random_generator;

namespace Autoclicker.clicker.extra;

public class JitterUtil
{
    public static async Task Jitter(double xAxis, double yAxis)
    {
        double xRnd = Random.NextDoubleLinear(-xAxis, xAxis);
        double yRnd = Random.NextDoubleLinear(-yAxis, yAxis);
        
        // Point of type float
        MouseControl.GetCursorPos(out Point currentPosition);
                
        Point targetPosition = new Point
        {
            X = (int) (currentPosition.X + xRnd),
            Y = (int) (currentPosition.Y + yRnd)
        };

        await MoveMouseUtil.LinearSmoothMove( currentPosition, targetPosition, 10);
    }

    public async Task LeftJitterToggle(bool isLeftClickerEnabled)
    {
        bool isLeftJitterEnabled = MouseControlUtil.IsLeftJitterEnabled();
        bool isLeftJitterValid = MouseControlUtil.IsLeftJitterValid();
        bool canJitter = isLeftClickerEnabled && isLeftJitterEnabled && isLeftJitterValid;

        if (canJitter)
        {
            double xAxis = Clicker.MainWindow.LeftJitterXAxis.Value;
            double yAxis = Clicker.MainWindow.LeftJitterYAxis.Value;
            await Jitter(xAxis, yAxis);
        }
    }

    public async Task RightClickerToggle(bool isRightClickerEnabled)
    {
        bool isRightJitterEnabled = MouseControlUtil.IsRightJitterEnabled();
        bool isRightJitterValid = MouseControlUtil.IsRightJitterValid();

        if (isRightClickerEnabled && isRightJitterEnabled && isRightJitterValid)
        {
            double xAxis = Clicker.MainWindow.RightClickerJitterXAxis.Value;
            double yAxis = Clicker.MainWindow.RightClickerJitterYAxis.Value;

            await Jitter(xAxis, yAxis);
        }
    }
}
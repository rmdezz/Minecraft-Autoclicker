using System;
using System.Threading;
using System.Threading.Tasks;
using Autoclicker.clicker.ms;
using Random = Autoclicker.random_generator.Random;

namespace Autoclicker.clicker.right_clicker;

public static class RightClickerUtil
{
    public static async Task MakeRightClicks(double cps, double lowerBound)
    {
        if (Clicker.MainWindow.FirstRightClick)
        {
            int ms = Random.NextIntLinear(100, 201);
            Thread.Sleep(ms);
            Clicker.MainWindow.FirstRightClick = false;
        }
        else
        {
            SetThreadPriority();
            double upperBound = RightClickerValues.GetUpperBound();
            bool newValues = RightClickerValues.NewValues(cps, lowerBound, upperBound);

            if (newValues)
            {
                /* If new CPS or lowerBound or upperBound, then compute values again */
                double cpsMs = Constants.HalfSecond / cps;
                double lowerCps = cps - lowerBound;
                double lowerCpsMs = Constants.HalfSecond / lowerCps;
                double upperCps = cps + upperBound;
                double upperCpsMs = Constants.HalfSecond / upperCps;

                /* Store new values into old-values variables */
                ClickerData.RightClicker.OldCps = cps;
                ClickerData.RightClicker.OldCpsMs = cpsMs;
                ClickerData.RightClicker.OldLowerCpsMs = lowerCpsMs;
                ClickerData.RightClicker.OldUpperCpsMs = upperCpsMs;
                ClickerData.RightClicker.LowerBound = lowerBound;
                ClickerData.RightClicker.UpperBound = upperBound;
            }

            double dropProbability = RightClickerValues.GetDropProbability();
            double dropCps = RightClickerValues.GetDropCps();

            ClickerUtil.SimulateRightButtonDown();
            await SimulateDelay(dropProbability, dropCps);
            RightClicker.IgnoreNextRelease = true;
            ClickerUtil.SimulateRightButtonUp();
            await SimulateDelay(dropProbability, dropCps);            
        }
    }

    private static async Task SimulateDelay(double dropProbability, double dropCps)
    {
        await MillisecondsUtil.SimulateMillisecondsBetweenClicks(ClickerData.RightClicker.OldCps, dropProbability,
            ClickerData.RightClicker.OldCpsMs, ClickerData.RightClicker.OldUpperCpsMs, ClickerData.RightClicker.OldLowerCpsMs, dropCps, false,
            true);
    }
    
    private static void SetThreadPriority()
    {
        string priority = GetPriority();
        bool priorityChanged = String.Equals(ClickerData.RightClicker.OldPriority, priority) == false;

        if (priorityChanged)
        {
            Clicker.MainWindow.Dispatcher.Invoke(() =>
            {
                if (Clicker.MainWindow.RightClickerThread.IsAlive)
                {
                    Clicker.MainWindow.RightClickerThread.Priority =
                        Clicker.MainWindow.RightClickerPriorityThread.SelectedIndex switch
                        {
                            0 => ThreadPriority.BelowNormal,
                            1 => ThreadPriority.AboveNormal,
                            2 => ThreadPriority.Normal,
                            3 => ThreadPriority.Lowest,
                            4 => ThreadPriority.Highest,
                            _ => Clicker.MainWindow.RightClickerThread.Priority
                        };
                    ClickerData.RightClicker.OldPriority = priority;
                }
            });
        }
    }
    
    private static string GetPriority()
    {
        return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.RightClickerPriorityThread.Items[
            Clicker.MainWindow.RightClickerPriorityThread.SelectedIndex].ToString());
    }
    
}
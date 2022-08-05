using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoclicker.clicker.ms;
using Autoclicker.hooks;
using Random = Autoclicker.random_generator.Random;

namespace Autoclicker.clicker.left_clicker;

public static class LeftClickerUtil
{
    public static async Task MakeLeftClicks(double cps, double lowerBound)
    {
        // For safety purposes there should be a delay for the first left mouse button click
            if (Clicker.MainWindow.FirstLeftClick)
            {
                int ms = Random.NextIntLinear(100, 201);
                Thread.Sleep(ms);
                Clicker.MainWindow.FirstLeftClick = false;
            }
            else
            {
                SetThreadPriority();
                
                double upperBound = LeftClickerValues.GetLeftClickerUpperBound();
                bool newValues = LeftClickerValues.NewValues(cps, lowerBound, upperBound);
                
                if (newValues)
                {
                    // If new CPS or lowerBound or upperBound, then compute values again 
                    double cpsMs = Constants.HalfSecond / cps;
                    double lowerCps = cps - lowerBound;
                    double lowerCpsMs = Constants.HalfSecond / lowerCps;
                    double upperCps = cps + upperBound;
                    double upperCpsMs = Constants.HalfSecond / upperCps;
                    
                    // Store new values into old-values variables 
                    ClickerData.LeftClicker.OldCps = cps;
                    ClickerData.LeftClicker.OldCpsMs = cpsMs;
                    ClickerData.LeftClicker.OldLowerCpsMs = lowerCpsMs;
                    ClickerData.LeftClicker.OldUpperCpsMs = upperCpsMs;
                    ClickerData.LeftClicker.LowerBound = lowerBound;
                    ClickerData.LeftClicker.UpperBound = upperBound;
                }
                
                bool breakBlocks = LeftClickerValues.IsBreakBlocksChecked();
                double dropProbability = LeftClickerValues.GetDropProbability();
                double dropCps = LeftClickerValues.GetDropCps();
                        
                ClickerUtil.SimulateLeftButtonDown();
                await SimulateDelay(dropProbability, dropCps);
                LeftClicker.IgnoreNextRelease = true;
                if (!breakBlocks) ClickerUtil.SimulateLeftButtonUp();
                await SimulateDelay(dropProbability, dropCps);
            }
    }

        private static async Task SimulateDelay(double dropProbability, double dropCps)
        {
            await MillisecondsUtil.SimulateMillisecondsBetweenClicks(ClickerData.LeftClicker.OldCps, dropProbability,
                ClickerData.LeftClicker.OldCpsMs, ClickerData.LeftClicker.OldUpperCpsMs, ClickerData.LeftClicker.OldLowerCpsMs, dropCps, true,
                false);
        }

        private static void SetThreadPriority()
        {
            string priority = GetPriority();
            bool priorityChanged = String.Equals(ClickerData.LeftClicker.OldPriority, priority) == false;

            if (priorityChanged)
            {
                Clicker.MainWindow.Dispatcher.Invoke(() =>
                {
                    if (Clicker.MainWindow.LeftClickerThread.IsAlive)
                    {
                        Clicker.MainWindow.LeftClickerThread.Priority =
                            Clicker.MainWindow.LeftClickerPriorityThread.SelectedIndex switch
                            {
                                0 => ThreadPriority.BelowNormal,
                                1 => ThreadPriority.AboveNormal,
                                2 => ThreadPriority.Normal,
                                3 => ThreadPriority.Lowest,
                                4 => ThreadPriority.Highest,
                                _ => Clicker.MainWindow.LeftClickerThread.Priority
                            };
                        ClickerData.LeftClicker.OldPriority = priority;
                    }
                });
            }
        }

        private static string GetPriority()
        {
            return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.LeftClickerPriorityThread.Items[
                Clicker.MainWindow.LeftClickerPriorityThread.SelectedIndex].ToString());
        }

        public static async Task DisableWhenInventoryOpen()
        {
            bool disableInInventory = IsDisableInInventoryChecked();
            string inventoryKey = GetInventoryKey();

            if (disableInInventory)
            {
                if (inventoryKey != "BIND A KEY")
                {
                    if (InventoryKeyIsDown())
                    {
                        await LeftClickerPauseDelay.Wait();
                    }
                }
                else MessageBox.Show(@"You need to bind an inventory key first!");
            }
        }

        private static bool InventoryKeyIsDown()
        {
            return Worker.GetAsyncKeyState(Clicker.MainWindow.GetInventoryKey);
        }

        private static string GetInventoryKey()
        {
            return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.InventoryKeyBindButton.Content.ToString());
        }

        private static bool IsDisableInInventoryChecked()
        {
            return Clicker.MainWindow.Dispatcher.Invoke(() => Clicker.MainWindow.DisableWhenInventoryOpenCheckbox.IsChecked.HasValue && Clicker.MainWindow.DisableWhenInventoryOpenCheckbox.IsChecked.Value);
        }

        public static int GetFirstDecimal(double getSec)
        {
            return (int) Math.Floor((getSec - Math.Truncate(getSec)) * 10);
        }
}
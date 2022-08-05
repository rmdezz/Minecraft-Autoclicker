using System.Threading;
using System.Threading.Tasks;
using Autoclicker.random_generator;

namespace Autoclicker.clicker.ms;

public static class MillisecondsUtil
{
    public static async Task SimulateMillisecondsBetweenClicks(double cps, double dropProbability, double cpsMs, double upperCpsMs, double lowerCpsMs, double dropCps, bool leftClicker, bool rightClicker)
    {
        double ms = await GetRandomMilliseconds(cps, dropProbability, cpsMs, upperCpsMs, lowerCpsMs, dropCps, leftClicker, rightClicker);
        
        /*
         * You can improve the accuracy of Sleep() by using timeBeginPeriod(1),
         * but it depends on your hardware peripheral's limits on the "one millisecond" delay — is that a minimum,
         * maximum, or in the middle of a range? - it will still, with a non-zero probability, fail to meet your timing requirement.
         */
        
        int dsv = 1;
        Thread.Sleep((int)ms - dsv);
    }

    private static async Task<double> GetRandomMilliseconds(double cps, double dropProbability, double cpsMs, double upperCpsMs, double lowerCpsMs, double dropCps, bool leftClicker, bool rightClicker)
    {
        Task task1 = GetLessMs(cpsMs, upperCpsMs, leftClicker, rightClicker);
        Task task2 = GetMoreMs(lowerCpsMs, cpsMs, leftClicker, rightClicker);
        Task task3 = GetProbability(leftClicker, rightClicker);
            
        await Task.WhenAll(task1, task2, task3);
        
        if (dropProbability > 0) GetDropMoreMs(cps, dropProbability, dropCps, leftClicker, rightClicker);
        else
        {
            if (leftClicker) ClickerData.LeftClicker.DropMs = 0;
            else if (rightClicker) ClickerData.RightClicker.DropMs = 0;
        }
            
        double ms = 0;
        
        if (leftClicker)
            ms = ClickerData.LeftClicker.OldCpsMs -
                 ClickerData.LeftClicker.LessMs +
                 ClickerData.LeftClicker.MoreMs +
                 ClickerData.LeftClicker.DropMs;
        
        else if (rightClicker)
            ms = ClickerData.RightClicker.OldCpsMs -
                 ClickerData.RightClicker.LessMs +
                 ClickerData.RightClicker.MoreMs +
                 ClickerData.RightClicker.DropMs;
        
        return ms;
    }

    private static void GetDropMoreMs(double cps, double dropProbability, double dropCps, bool leftClicker, bool rightClicker)
    {
        /*
             * If you wish to imitate real human clicks, you must be aware that clicking for an extended period of
             * time tires the hands, thus it makes sense to simulate this as well. In this case, it is achieved using
             * a probability chance and a random double logarithmic generator.
             */
        
        double probability = 0;

        if (leftClicker) probability = ClickerData.LeftClicker.Probability;
        else if (rightClicker) probability = ClickerData.RightClicker.Probability;
        
        if (probability <= dropProbability)
        {
            double tiredHandCps = cps - dropCps;
            double tiredHandMs = Constants.HalfSecond / tiredHandCps;
                
            /*
                 Why not double random linear generator?
                 Since if linear, values will be high the majority of the time, and since the thread executes
                 continuously, it's very likely that even though we're restricting to drop cps if it hits a certain
                 probability chance, it's going to get into that range the majority of the time, which is why I'm
                 using a logarithmic generator instead of a linear generator to make it less frequent.
            */

            double randomValue = Random.NextDoubleLinear(0, tiredHandMs);
            
            if (leftClicker) ClickerData.LeftClicker.DropMs = randomValue;
            else if (rightClicker) ClickerData.RightClicker.DropMs = randomValue;
        }
        else
        {
            if (leftClicker) ClickerData.LeftClicker.DropMs = 0;
            else ClickerData.RightClicker.DropMs = 0;
        }
    }

    private static async Task GetProbability(bool leftClicker, bool rightClicker)
    {
        await Task.Run(() =>
        {
            double probability = Random.NextDoubleLinear(1, 101);
            if (leftClicker) ClickerData.LeftClicker.Probability = probability;
            else if (rightClicker) ClickerData.RightClicker.Probability = probability;
        });
    }

    private static async Task GetMoreMs(double oldLowerCpsMs, double oldCpsMs, bool leftClicker, bool rightClicker)
    {
        await Task.Run(() =>
        {
            double ms = Random.NextDoubleLinear(0, oldLowerCpsMs - oldCpsMs);
            if (leftClicker) ClickerData.LeftClicker.MoreMs = ms;
            else if (rightClicker) ClickerData.RightClicker.MoreMs = ms;
        });
    }

    private static async Task GetLessMs(double oldCpsMs, double oldUpperCpsMs, bool leftClicker, bool rightClicker)
    {
        await Task.Run(() =>
        {
            double lim = oldCpsMs - oldUpperCpsMs;
            double ms = Random.NextDoubleLinear(0, lim + 1);
            if (leftClicker) ClickerData.LeftClicker.LessMs = ms;
            else if (rightClicker) ClickerData.RightClicker.LessMs = ms;
        });
    }
}
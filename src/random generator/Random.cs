using System;
using System.Security.Cryptography;

namespace Autoclicker.random_generator;

public static class Random
{
    private static double GenerateRandomDouble()
    { 
        var rng = new RNGCryptoServiceProvider();
        // Fill an array of bytes with 8 random bytes
        byte[] bytes = new byte[sizeof(double)];
        rng.GetBytes(bytes);
        // Bit-shift 11 and 53 based on double's mantissa bits
        var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
        double d = ul / (double)(1UL << 53);
        return d;
    }

    public static double NextDoubleLinear(double minValue, double maxValue)
    {
        double sample = GenerateRandomDouble();
        return maxValue * sample + minValue * (1d - sample);
    }
        
    public static int NextIntLinear(int minValue, int maxValue)
    {
        double sample = GenerateRandomDouble();
        return (int)(maxValue * sample + minValue * (1d - sample));
    }

    public static double NextDoubleLogarithmic(double minValue, double maxValue) // 0 y 7
    {
        // TODO: some validation here...
        bool minValueNegative = minValue < 0d;
        bool maxValuePositive = maxValue > 0d;
            
        bool posAndNeg = minValueNegative && maxValuePositive;
        double absMinValue = Math.Abs(minValue);
        double absMaxValue = Math.Abs(maxValue);
            
        double minAbs = Math.Min(absMinValue, absMaxValue);
        double maxAbs = Math.Max(absMinValue, absMaxValue);

        int sign;
        if (!posAndNeg)
            if (minValue < 0d) sign = -1;
            else sign = 1;
        else
        {
            // if both negative and positive results are expected we select the sign based on the size of the ranges
            double sample = GenerateRandomDouble(); // generate random double from 0.0 to 1.0
            var rate = minAbs / maxAbs;
            //absMinValue = Math.Abs(minValue);
            bool isNeg;
                
            if (absMinValue <= maxValue)
                isNeg = rate / 2d > sample;
            else
                isNeg = rate / 2d < sample;
                
            if (isNeg)
                sign = -1;
            else
                sign = 1;

            // now adjusting the limits for 0..[selected range]
            minAbs = 0d;
                
            maxAbs = isNeg ? absMinValue : Math.Abs(maxValue);
        }

        // Possible double exponents are -1022..1023 but we don't generate too small exponents for big ranges because
        // that would cause too many almost zero results, which are much smaller than the original NextDouble values.
        double minExponent; // 6.64
            
        if (minAbs != 0d)
            minExponent = Math.Log(minAbs, 2d);
        else
            minExponent = -16d; // -16.0
            
        double maxExponent = Math.Log(maxAbs, 2d); // 6.64
            
        if (Math.Abs(minExponent - maxExponent) < 0.000000001)
            return minValue;

        // We decrease exponents only if the given range is already small. Even lower than -1022 is no problem, the result may be 0
        if (maxExponent < minExponent)
            minExponent = maxExponent - 4;

        double result = sign * Math.Pow(2d, NextDoubleLinear(minExponent, maxExponent));

        // protecting ourselves against inaccurate calculations; however, in practice result is always in range.
        if (result < minValue)
            return minValue;
        return result > maxValue ? maxValue : result;
    }
}
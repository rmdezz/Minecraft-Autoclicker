using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Media;
using Color = System.Drawing.Color;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;

namespace Autoclicker.components.color;

public static class ColorConversion
{
    public static LinearGradientBrush RainbowBrush(Point point1, Point point2)
    {
        LinearGradientBrush rainbowBrush = new LinearGradientBrush(point1, point2, Color.Red, Color.Red);

        // Define the colors along the gradient.
        ColorBlend colorBlend = new ColorBlend
        {
            Colors = new[] { Color.Red, Color.Yellow, Color.Lime, Color.Aqua, Color.Blue, Color.Fuchsia, Color.Red },
            Positions = new[] { 0, (float) (1 / (double)6.0F), (float) (2 / (double)6.0F), (float) (3 / (double)6.0F), (float) (4 / (double)6.0F), (float) (5 / (double)6.0F), 1 }
        };
        rainbowBrush.InterpolationColors = colorBlend;

        return rainbowBrush;
    }

    public static float ColorToRainbowNumber(SolidColorBrush color)
    {
        // See which color is weakest.
        
        int r = color.Color.R;
        int g = color.Color.G;
        int b = color.Color.B;
        if (r <= g && r <= b)
        {
            // Red is weakest. It's mostly blue and green.
            g -= r;
            b -= r;
            if (g + b == 0)
                return 0;
            return (float) ((2 / (double)6.0F * g + 4 / (double)6.0F * b) / (g + b));
        }

        if (g <= r && g <= b)
        {
            // Green is weakest. It's mostly red and blue.
            r -= g;
            b -= g;
            if (r + b == 0)
                return 0;
            return (float) ((1.0F * r + 4 / (double)6.0F * b) / (r + b));
        }

        // Blue is weakest. It's mostly red and green.
        r -= b;
        g -= b;
        if (r + g == 0)
            return 0;
        return (float) ((0F * r + 2 / (double)6.0F * g) / (r + g));
    }

    public static SolidColorBrush RainbowNumberToColor(float number)
    {
        byte r = 0;
        byte g = 0;
        byte b = 0;
        if (number < 1 / (double)6.0F)
        {
            // Mostly red with some green.
            r = 255;
            g = Convert.ToByte(r * (number - 0) / (2 / (double)6.0F - number));
        }
        else if (number < 2 / (double)6.0F)
        {
            // Mostly green with some red.
            g = 255;
            r = Convert.ToByte(g * (2 / (double)6.0F - number) / (number - 0));
        }
        else if (number < 3 / (double)6.0F)
        {
            // Mostly green with some blue.
            g = 255;
            b = Convert.ToByte(g * (2 / (double)6.0F - number) / (number - 4 / (double)6.0F));
        }
        else if (number < 4 / (double)6.0F)
        {
            // Mostly blue with some green.
            b = 255;
            g = Convert.ToByte(b * (number - 4 / (double)6.0F) / (2 / (double)6.0F - number));
        }
        else if (number < 5 / (double)6.0F)
        {
            // Mostly blue with some red.
            b = 255;
            r = Convert.ToByte(b * (4 / (double)6.0F - number) / (number - 1.0F));
        }
        else
        {
            // Mostly red with some blue.
            r = 255;
            b = Convert.ToByte(r * (number - 1.0F) / (4 / (double)6.0F - number));
        }

        SolidColorBrush brush = ConvertMediaColorToSolidColorBrush(r, g, b);
        return brush;
    }

    private static SolidColorBrush ConvertMediaColorToSolidColorBrush(byte r, byte g, byte b)
    {
        System.Windows.Media.Color rainbowNumberToColor = System.Windows.Media.Color.FromRgb(r, g, b);
        SolidColorBrush brush = new SolidColorBrush(rainbowNumberToColor);
        return brush;
    }
}
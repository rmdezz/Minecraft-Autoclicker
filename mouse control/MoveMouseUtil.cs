using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Random = Autoclicker.random_generator.Random;

namespace Autoclicker.mouse_control;

public static class MoveMouseUtil
{
    public static async Task LinearSmoothMove(Point currentPosition, Point targetPosition, int steps)
    {
        // PointF: Point float
        PointF iterPoint = currentPosition;

        // Find the slope of the line segment defined by start and targetPosition
        PointF slope = new PointF(targetPosition.X - currentPosition.X, targetPosition.Y - currentPosition.Y);

        // Divide by the number of steps
        slope.X /= steps;
        slope.Y /= steps;

        // Move the mouse to each iterative point.
        List<Task<PointF>> tasks = new List<Task<PointF>>();
        
        for (int i = 0; i < steps; i++)
        {
            tasks.Add(Task.Run(() =>  iterPoint = MoveMouse(iterPoint, slope)));
        }

        await Task.WhenAll(tasks);
			
        // Move the mouse to the final destination.
        MouseControl.SetCursorPos(targetPosition.X, targetPosition.Y);
    }

    private static PointF MoveMouse(PointF iterativePoint, PointF slope)
    {
        iterativePoint = new PointF(iterativePoint.X + slope.X, iterativePoint.Y + slope.Y);
        MouseControl.SetCursorPos((int) iterativePoint.X, (int) iterativePoint.Y);
        Task.Delay(1);
        return iterativePoint;
    }

    public static void MoveMouse(double mouseSpeed, int x, int y, int rx, int ry)
    {
        MouseControl.GetCursorPos(out Point c);
        x += (int)Random.NextDoubleLinear(0, rx);
        y += (int)Random.NextDoubleLinear(0, ry);
        double randomSpeed = Math.Max((Random.NextDoubleLinear(0, mouseSpeed) / 2.0 + mouseSpeed) / 5.0, 0.1);
        WindMouse(c.X, c.Y, x, y, 9.0, 3.0, 10.0 / randomSpeed, 10.0 / randomSpeed, 5.0 * randomSpeed, 5.0 * randomSpeed);
    }

    private static void WindMouse(double xs, double smax, double xe, double ye, double gravity, double wind, double minWait, double maxWait, double maxStep, double targetArea)
    {
        double windX = 0.0;
        double windY = 0.0;
        double veloX = 0.0;
        double veloY = 0.0;
        int newX = (int)Math.Round(xs);
        int newY = (int)Math.Round(smax);
        double waitDiff = maxWait - minWait;
        double sqrt2 = Math.Sqrt(2.0);
        double sqrt3 = Math.Sqrt(3.0);
        double sqrt4 = Math.Sqrt(5.0);
        double distance = Hypotenuse(xe - xs, ye - smax);
		
        while (distance >= 1.0)
        {
            wind = Math.Min(wind, distance);
            
            if (distance >= targetArea)
            {
                int w = (int)Random.NextDoubleLinear(0, Math.Round(wind) * 2 + 1);
                windX = windX / sqrt3 + (w - wind) / sqrt4;
                windY = windY / sqrt3 + (w - wind) / sqrt4;
            }
            else
            {
                windX /= sqrt2;
                windY /= sqrt2;
				
                if (maxStep < 3.0)
                    maxStep = Random.NextDoubleLinear(0, 3) + 3.0; 
                else
                    maxStep /= sqrt4;
            }
            
            veloX += windX;
            veloY += windY;
            veloX += gravity * (xe - xs) / distance;
            veloY += gravity * (ye - smax) / distance;
            
            if (Hypotenuse(veloX, veloY) > maxStep)
            {
                double randomDist = maxStep / 2.0 + Random.NextDoubleLinear(0, Math.Round(maxStep) / 2);
                double veloMag = Hypotenuse(veloX, veloY);
                veloX = veloX / veloMag * randomDist;
                veloY = veloY / veloMag * randomDist;
            }
            
            int oldX = (int)Math.Round(xs);
            int oldY = (int)Math.Round(smax);
            xs += veloX;
            smax += veloY;
            distance = Hypotenuse(xe - xs, ye - smax);
            newX = (int)Math.Round(xs);
            newY = (int)Math.Round(smax);
            if (oldX != newX || oldY != newY)
            {
                MouseControl.SetCursorPos(newX, newY);
            }
            double step = Hypotenuse(xs - oldX, smax - oldY);
            Task.Delay((int) Math.Round(waitDiff * (step / maxStep) + minWait));
        }
		
        int endX = (int)Math.Round(xe);
        int endY = (int)Math.Round(ye);
        if (endX != newX || endY != newY)
        {
            MouseControl.SetCursorPos(endX, endY);
        }
    }

    private static double Hypotenuse(double dx, double dy)
    {
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
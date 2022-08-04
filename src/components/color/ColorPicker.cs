using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Autoclicker.components.color;

public class ColorPicker
{
    public readonly MainWindow MainWindow;
    private bool _clickDetected;
    public float SelectedRainbowNumber;
    public readonly SetComponentsColor SetComponentsColor;
    private readonly ColorPickerUtil _colorPickerUtil;

    public ColorPicker(MainWindow mainWindow)
    {
        MainWindow = mainWindow;
        MainWindow.PicRainbow.Paint += picRainbow_Paint;
        MainWindow.PicRainbow.Resize += picRainbow_Resize;
        MainWindow.PicRainbow.MouseMove += picRainbow_MouseMove;
        MainWindow.PicRainbow.Click += picRainbow_Click;
        SetComponentsColor = new SetComponentsColor(this);
        _colorPickerUtil = new ColorPickerUtil(this, mainWindow);
    }

    public void CustomRainbow(object obj)
    {
        while (MainWindow.IsRunning && !MainWindow.RainbowThreadAborted)
        {
            bool rainbowChecked = _colorPickerUtil.IsRainbowChecked();
		        
            if (rainbowChecked)
            {
                MainWindow.Dispatcher.Invoke(() => MainWindow.ResetToDefaultCheckbox.IsEnabled = true);
                // Update color in each iteration
                _colorPickerUtil.GetNewColor();

                bool includeTab = _colorPickerUtil.IsIncludeTabChecked();
                
                if (includeTab)
                    _colorPickerUtil.SetTabColorToSelectedColor();
                else
                    _colorPickerUtil.SetTabColorToColorString("#1F1E1F");

                ColorPickerUtil.SetLabelsColorBasedOnThemeColor(SelectedRainbowNumber);
                _colorPickerUtil.SetLabelsForegroundColor();
                _colorPickerUtil.SetComponentsColor(SelectedRainbowNumber);

                MainWindow.Dispatcher.Invoke(() => MainWindow.WindowsFormsHost1.Child.Refresh());
            }
            else MainWindow.Dispatcher.Invoke(() => MainWindow.ResetToDefaultCheckbox.IsEnabled = false);

            int delay = _colorPickerUtil.GetRainbowDelay();
            Thread.Sleep(delay);
        }
    }

    private void picRainbow_Click(object sender, EventArgs eventArgs)
    {
        _clickDetected = true;
    }

    private void picRainbow_MouseMove(object sender, MouseEventArgs e)
    {
        bool customColorChecked = _colorPickerUtil.IsCustomColorChecked();
	        
        if (customColorChecked && _clickDetected)
        {
            /* Retrieve color from picRainbow */
            _colorPickerUtil.GetSelectedColor(e);

            bool includeTab = _colorPickerUtil.IsIncludeTabChecked();

            if (includeTab)
                _colorPickerUtil.SetTabColorToSelectedColor();
            else
                _colorPickerUtil.SetTabColorToColorString("#1F1E1F");

            ColorPickerUtil.SetLabelsColorBasedOnThemeColor(SelectedRainbowNumber);
            _colorPickerUtil.SetComponentsColor(SelectedRainbowNumber);
            _colorPickerUtil.SetLabelsForegroundColor();
		        
            _clickDetected = false;

            MainWindow.WindowsFormsHost1.Child.Refresh();
        }
    }

    public void SetDefaultColors()
    {
        _colorPickerUtil.DefaultColors();
    }

    private void picRainbow_Resize(object sender, EventArgs e)
    {
        MainWindow.WindowsFormsHost1.Child.Refresh();
    }

    private void picRainbow_Paint(object sender, PaintEventArgs e)
    {
        // Draw the rainbow.
        using (Brush rainbowBrush = ColorConversion.RainbowBrush(new Point(0, 0), new Point(MainWindow.WindowsFormsHost1.Child.Width, MainWindow.WindowsFormsHost1.Child.Height)))
        {
            e.Graphics.FillRectangle(rainbowBrush, MainWindow.WindowsFormsHost1.Child.ClientRectangle);
        }
        
        // Get and draw the selected location.
        int x = Convert.ToInt32(SelectedRainbowNumber * MainWindow.WindowsFormsHost1.Child.ClientSize.Width);
        Point[] pts = { new(x - 5, 0), new(x, 5), new(x + 5, 0) };
	        
        Brush blueBrush = new SolidBrush(Color.Black);
        e.Graphics.FillPolygon(blueBrush, pts);
    }
}
using System.Windows.Forms;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace Autoclicker.components.color;

public class ColorPickerUtil
{
    private readonly ColorPicker _colorPicker;
    private readonly MainWindow _mainWindow;
    
    public ColorPickerUtil(ColorPicker colorPicker, MainWindow mainWindow)
    {
        _colorPicker = colorPicker;
        _mainWindow = mainWindow;
    }

    public bool IsCustomColorChecked()
    {
        return _colorPicker.MainWindow.Dispatcher.Invoke(() => _colorPicker.MainWindow.CustomColorCheckbox.IsChecked != null && _colorPicker.MainWindow.CustomColorCheckbox.IsChecked.Value);
    }

    public bool IsIncludeTabChecked()
    {
        return _colorPicker.MainWindow.Dispatcher.Invoke(() => _colorPicker.MainWindow.IncludeTabCheckbox.IsChecked != null && _colorPicker.MainWindow.IncludeTabCheckbox.IsChecked.Value);
    }

    public void GetSelectedColor(MouseEventArgs e)
    {
        float rainbowColor = e.X / (float) _colorPicker.MainWindow.WindowsFormsHost1.Child.ClientSize.Width;
        _colorPicker.MainWindow.SelectedColor = ColorConversion.RainbowNumberToColor(rainbowColor);
        _colorPicker.SelectedRainbowNumber = ColorConversion.ColorToRainbowNumber(_colorPicker.MainWindow.SelectedColor);
    }

    public void SetTabColorToColorString(string color)
    {
        _colorPicker.MainWindow.Dispatcher.Invoke(() =>
        {
            BrushConverter converter = new BrushConverter();
            Brush brush =
                (Brush) converter.ConvertFromString(color);
            _colorPicker.MainWindow.TabablzControl.BorderBrush = brush;
        });
    }

    public void SetTabColorToSelectedColor()
    {
        _colorPicker.MainWindow.Dispatcher.Invoke(() => _colorPicker.MainWindow.TabablzControl.BorderBrush = ColorConversion.RainbowNumberToColor(_colorPicker.SelectedRainbowNumber));
    }

    public static void SetLabelsColorBasedOnThemeColor(float selectedColorNumber)
    {
        PaletteHelper paletteHelper = new PaletteHelper();
        ITheme theme = paletteHelper.GetTheme();
        theme.SetPrimaryColor(ColorConversion.RainbowNumberToColor(selectedColorNumber).Color);
        paletteHelper.SetTheme(theme);
    }

    public void SetComponentsColor(float selectedColorNumber)
    {
        _colorPicker.SetComponentsColor.RectanglesRainbow(selectedColorNumber);
        _colorPicker.SetComponentsColor.TextRainbow(selectedColorNumber);
        _colorPicker.SetComponentsColor.CheckboxesRainbow(selectedColorNumber);
        _colorPicker.SetComponentsColor.SlidersRainbow(selectedColorNumber);
        _colorPicker.SetComponentsColor.TextboxesRainbow(selectedColorNumber);
        _colorPicker.SetComponentsColor.ButtonsRainbow(selectedColorNumber);
    }
    
    public void DefaultColors()
    {
        if (_mainWindow.RainbowThread.IsAlive) _mainWindow.RainbowThread.Abort();
        
        Color numberColor = Color.FromRgb(255, 155, 0);
        SolidColorBrush brush = new SolidColorBrush(numberColor);
        float defaultColorNumber = ColorConversion.ColorToRainbowNumber(brush);
        
        SetLabelsColorBasedOnThemeColor(defaultColorNumber);
        SetLabelsForegroundColor();
        SetTabColorToColorString("#FF8D00");
        SetComponentsColor(defaultColorNumber);
    }

    public void SetLabelsForegroundColor()
    {
        _colorPicker.MainWindow.Dispatcher.Invoke(() =>
        {
            Brush foregroundColor = _colorPicker.MainWindow.RightClickerButton.Foreground;

            _colorPicker.MainWindow.RightButtonLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.BoundsLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.CpsDropLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.JitterLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.LeftButtonLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.LeftBoundsLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.LeftCpsDropLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.LeftJitterLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.BlockhitLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.RefillLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.BreakBlocksLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.DisableWhenInventoryLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.SettingsLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.StatusLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.ThreadLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.ColorPickerLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.RightSoundPickerLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.LeftSoundPickerLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.MinecraftStatusLabel.Foreground = foregroundColor;
            _colorPicker.MainWindow.MouseStatusLabel.Foreground = foregroundColor;
            
        });
    }

    public int GetRainbowDelay()
    {
        return _colorPicker.MainWindow.Dispatcher.Invoke(() => (int) _colorPicker.MainWindow.RainbowDelaySlider.Value);
    }

    public void GetNewColor()
    {
        _colorPicker.SelectedRainbowNumber = (float) (_colorPicker.SelectedRainbowNumber + 0.005);
        if (_colorPicker.SelectedRainbowNumber > 1f) _colorPicker.SelectedRainbowNumber = 0f;
    }

    public bool IsRainbowChecked()
    {
        return _colorPicker.MainWindow.Dispatcher.Invoke(() => _colorPicker.MainWindow.RainbowCheckbox.IsChecked != null && _colorPicker.MainWindow.RainbowCheckbox.IsChecked.Value);
    }
}
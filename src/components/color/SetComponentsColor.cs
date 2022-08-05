using System.Windows.Controls;
using System.Windows.Shapes;

namespace Autoclicker.components.color;

public class SetComponentsColor
{
    private readonly ColorPicker _colorPicker;

    public SetComponentsColor(ColorPicker colorPicker)
    {
        _colorPicker = colorPicker;
    }

    public void TextboxesRainbow(float selectedRainbowNumber)
    {
        /* Textboxes */
        _colorPicker.MainWindow.Dispatcher.Invoke(() => _colorPicker.MainWindow.MinecraftClientTextBox.CaretBrush = ColorConversion.RainbowNumberToColor(selectedRainbowNumber));
    }

    public void ButtonsRainbow(float selectedRainbowNumber)
    {
        _colorPicker.MainWindow.Dispatcher.Invoke(() =>
        {
            ButtonToSelectedColor(_colorPicker.MainWindow.RightClickerButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.InventoryKeyBindButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.LeftClickerKeyBindButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.RightNormalClickingButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.DragClickButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.BreezilyButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.GodBridgeButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.TellyBridgeButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.MoonwalkButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.LeftNormalClickButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.JitterButton, selectedRainbowNumber);
            ButtonToSelectedColor(_colorPicker.MainWindow.ButterflyButton, selectedRainbowNumber);
        });
    }

    public void ButtonToSelectedColor(Button button, float selectedColorNumber)
    {
        button.Background = ColorConversion.RainbowNumberToColor(selectedColorNumber);
    }

    public void SlidersRainbow(float selectedRainbowNumber)
    {
        /* Sliders */

        _colorPicker.MainWindow.Dispatcher.Invoke(() =>
        {
            SliderToSelectedColor(_colorPicker.MainWindow.LeftCpsSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.LeftLowerCpsSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.LeftUpperCpsSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.LeftCpsDropAmountSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.LeftCpsDropProbabilitySlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.LeftJitterXAxis, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.LeftJitterYAxis, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.LeftBlockhitProbabilitySlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RefillSpeedSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RefillXAxisRandomSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RefillYAxisRandomSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RefillStepsRandomSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.InventoryDelaySlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightCpsSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightLowerCpsSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightUpperCpsSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightCpsDropAmountSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightCpsDropProbabilitySlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightClickerJitterXAxis, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightClickerJitterYAxis, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.BlockhitDelaySlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RainbowDelaySlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.RightCpsDelimiterSlider, selectedRainbowNumber);
            SliderToSelectedColor(_colorPicker.MainWindow.CpsDelimiterSlider, selectedRainbowNumber);
        });
        
    }

    public void SliderToSelectedColor(Slider slider, float selectedColorNumber)
    {
        slider.Foreground = ColorConversion.RainbowNumberToColor(selectedColorNumber);
    }

    public void CheckboxesRainbow(float selectedRainbowNumber)
    {
        /* Checkboxes */
        _colorPicker.MainWindow.Dispatcher.Invoke(() =>
        {
            CheckboxToSelectedColor(_colorPicker.MainWindow.OnlyInMinecraftCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.CustomColorCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.RainbowCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.LeftClickerCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.JitterCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.BlockhitCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.RefillSpeedCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.BreakBlocksCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.DisableWhenInventoryOpenCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.RightClickerCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.RightJitterCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.IncludeTabCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.ResetToDefaultCheckbox, selectedRainbowNumber);
            CheckboxToSelectedColor(_colorPicker.MainWindow.ToggleMouseStatus, selectedRainbowNumber);
        });
    }

    public void CheckboxToSelectedColor(CheckBox checkBox, float selectedColorNumber)
    {
        checkBox.Background = ColorConversion.RainbowNumberToColor(selectedColorNumber);
    }

    public void TextRainbow(float selectedRainbowNumber)
    {
        /* Text */
        _colorPicker.MainWindow.Dispatcher.Invoke(() =>
        {
            LabelToSelectedColor(_colorPicker.MainWindow.LeftClickerStatusText, selectedRainbowNumber);
            LabelToSelectedColor(_colorPicker.MainWindow.RightClickerStatusText, selectedRainbowNumber);
            LabelToSelectedColor(_colorPicker.MainWindow.IsMinecraftOpenStatusText, selectedRainbowNumber);
            LabelToSelectedColor(_colorPicker.MainWindow.LeftSoundPickerMode, selectedRainbowNumber);
            LabelToSelectedColor(_colorPicker.MainWindow.RightSoundPickerMode, selectedRainbowNumber);
            LabelToSelectedColor(_colorPicker.MainWindow.SimulatedClickStatusText, selectedRainbowNumber);
            LabelToSelectedColor(_colorPicker.MainWindow.ScreenXAxisText, selectedRainbowNumber);
            LabelToSelectedColor(_colorPicker.MainWindow.ScreenYAxisText, selectedRainbowNumber);
        });
    }

    private void LabelToSelectedColor(Label label, float selectedColorNumber)
    {
        label.Foreground = ColorConversion.RainbowNumberToColor(selectedColorNumber);
    }

    public void RectanglesRainbow(float selectedRainbowNumber)
    {
        /* Rectangles */

        _colorPicker.MainWindow.Dispatcher.Invoke(() =>
        {
            RectangleToSelectedColor(_colorPicker.MainWindow.SettingsRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.StatusRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.RightButtonRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonBoundRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonCpsDropRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonJitterRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonBlockhitRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonRefillRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonBreakBlocksRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftButtonInventoryRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.RightButtonBoundsRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.RightButtonCpsDropRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.RightButtonJitterRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.ColorPickerRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.ThreadRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.SettingsRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.MouseStatusRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.MinecraftStatusRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.RightSoundPickerRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.LeftSoundPickerRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.RightCpsDelimiterRectangle, selectedRainbowNumber);
            RectangleToSelectedColor(_colorPicker.MainWindow.CpsDelimiterRectangle, selectedRainbowNumber);
        });
    }

    public void RectangleToSelectedColor(Rectangle rectangle, float selectedColorNumber)
    {
        rectangle.Fill = ColorConversion.RainbowNumberToColor(selectedColorNumber);
    }
}
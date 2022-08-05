namespace Autoclicker.components.events;

public class ComponentsEventsUtil
{
    private readonly MainWindow _mainWindow;
    private readonly ComponentsEvents _componentsEvents;
    
    public ComponentsEventsUtil(MainWindow mainWindow, ComponentsEvents componentsEvents)
    {
        _mainWindow = mainWindow;
        _componentsEvents = componentsEvents;
        LoadComponentEvents();
    }

    private void LoadComponentEvents()
    {
        _mainWindow.RefillSpeedSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.RefillSliderValueChanged;
        
        _mainWindow.LeftCpsDropAmountSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftCpsDropAmountSliderValueChanged;
        _mainWindow.LeftCpsDropProbabilitySlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftCpsDropProbabilitySliderValueChanged;
        _mainWindow.LeftCpsSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftCpsSliderValueChanged;
        
        _mainWindow.LeftJitterXAxis.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftJitterXAxisValueChanged;
        _mainWindow.LeftJitterYAxis.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftJitterYAxisValueChanged;
        
        _mainWindow.LeftBlockhitProbabilitySlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftBlockhitProbabilitySliderValueChanged;
        
        _mainWindow.InventoryDelaySlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.inventory_delay_slider_ValueChanged;
        
        _mainWindow.RefillXAxisRandomSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.RefillXAxisRandomSliderValueChanged;
        _mainWindow.RefillYAxisRandomSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.RefillYAxisRandomSliderValueChanged;
        _mainWindow.RefillStepsRandomSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.RefillStepsRandomSliderValueChanged;
        
        _mainWindow.LeftLowerCpsSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftLowerCpsSliderValueChanged;
        _mainWindow.LeftUpperCpsSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftUpperCpsSliderValueChanged;
        
        _mainWindow.BlockhitDelaySlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.BlockhitDelaySliderValueChanged;
        
        _mainWindow.RightClickerButton.KeyDown += _componentsEvents.RightClickerEvents.right_clicker_KeyDown;
        _mainWindow.RightClickerButton.Click += _componentsEvents.RightClickerEvents.right_clicker_Click;
        _mainWindow.RightCpsSlider.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightCpsSlider_ValueChanged;
        
        _mainWindow.RightLowerCpsSlider.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightLowerCpsSlider_ValueChanged;
        _mainWindow.RightUpperCpsSlider.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightUpperCpsSlider_ValueChanged;
        
        _mainWindow.RightCpsDropAmountSlider.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightCpsDropAmountSlider_ValueChanged;
        _mainWindow.RightCpsDropProbabilitySlider.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightCpsDropProbabilitySlider_ValueChanged;
        
        _mainWindow.RightClickerJitterXAxis.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightClicker_JitterXAxis_ValueChanged;
        _mainWindow.RightClickerJitterYAxis.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightClicker_JitterYAxis_ValueChanged;
        
        _mainWindow.RainbowDelaySlider.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RainbowDelaySlider_ValueChanged;
        
        _mainWindow.ResetToDefaultCheckbox.Checked += _componentsEvents.RainbowColorEvents.ResetToDefaultCheckbox_Checked;
        
        _mainWindow.LeftClickerCheckbox.Checked += _componentsEvents.LeftClickerEvents.LeftClickerCheckbox_Checked;
        _mainWindow.LeftClickerCheckbox.Unchecked += _componentsEvents.LeftClickerEvents.LeftClickerCheckbox_Unchecked;
        
        _mainWindow.RightClickerCheckbox.Checked += _componentsEvents.RightClickerEvents.RightClickerCheckbox_Checked;
        _mainWindow.RightClickerCheckbox.Unchecked += _componentsEvents.RightClickerEvents.RightClickerCheckbox_Unchecked;
        
        _mainWindow.RainbowCheckbox.Checked += _componentsEvents.RainbowColorEvents.rainbow_checkbox_Checked;
        _mainWindow.RainbowCheckbox.Unchecked += _componentsEvents.RainbowColorEvents.rainbow_checkbox_Unchecked;
        
        _mainWindow.InventoryKeyBindButton.Click += _componentsEvents.LeftClickerEvents.inventory_button_Click;
        _mainWindow.InventoryKeyBindButton.KeyDown += _componentsEvents.LeftClickerEvents.inventory_button_KeyDown;
        
        _mainWindow.LeftClickerKeyBindButton.KeyDown += _componentsEvents.LeftClickerEvents.LeftClickerKeyBindButton_KeyDown;
        _mainWindow.LeftClickerKeyBindButton.Click += _componentsEvents.LeftClickerEvents.LeftClickerKeyBindButton_Click;
        
        _mainWindow.GodBridgeButton.KeyDown += _componentsEvents.RightClickerSoundEvents.GodBridgeKeyDown;
        _mainWindow.GodBridgeButton.Click += _componentsEvents.RightClickerSoundEvents.GodBridgeClick;
        
        _mainWindow.DragClickButton.KeyDown += _componentsEvents.RightClickerSoundEvents.DragClick_KeyDown;
        _mainWindow.DragClickButton.Click += _componentsEvents.RightClickerSoundEvents.DragClick_Click;
        
        _mainWindow.TellyBridgeButton.KeyDown += _componentsEvents.RightClickerSoundEvents.TellyBridge_KeyDown;
        _mainWindow.TellyBridgeButton.Click += _componentsEvents.RightClickerSoundEvents.TellyBridge_Click;

        _mainWindow.RightNormalClickingButton.KeyDown += _componentsEvents.RightClickerSoundEvents.right_normal_clicking_KeyDown;
        _mainWindow.RightNormalClickingButton.Click += _componentsEvents.RightClickerSoundEvents.right_normal_clicking_Click;
        
        _mainWindow.BreezilyButton.KeyDown += _componentsEvents.RightClickerSoundEvents.breezily_keyDown;
        _mainWindow.BreezilyButton.Click += _componentsEvents.RightClickerSoundEvents.breezily_Click;
        
        _mainWindow.MoonwalkButton.KeyDown += _componentsEvents.RightClickerSoundEvents.moonwalk_KeyDown;
        _mainWindow.MoonwalkButton.Click += _componentsEvents.RightClickerSoundEvents.moonwalk_Click;
        
        
        /* Left Mouse Button Clicking Methods Sounds */
        
        _mainWindow.LeftNormalClickButton.KeyDown += _componentsEvents.RightClickerSoundEvents.NormalLeftClick_KeyDown;
        _mainWindow.LeftNormalClickButton.Click += _componentsEvents.RightClickerSoundEvents.NormalLeftClick_Click;
        
        _mainWindow.JitterButton.KeyDown += _componentsEvents.RightClickerSoundEvents.JitterLeftClick_KeyDown;
        _mainWindow.JitterButton.Click += _componentsEvents.RightClickerSoundEvents.JitterLeftClick_Click;
        
        _mainWindow.ButterflyButton.KeyDown += _componentsEvents.RightClickerSoundEvents.ButterflyClick_KeyDown;
        _mainWindow.ButterflyButton.Click += _componentsEvents.RightClickerSoundEvents.ButterflyClick_Click;

        _mainWindow.RightClickingMethodSoundComboBox.SelectionChanged += _componentsEvents.RightClickerSoundEvents
            .RightClickingMethodSoundComboBox_SelectionChanged;

        _mainWindow.LeftClickingMethodSoundComboBox.SelectionChanged +=
            _componentsEvents.LeftClickerSoundEvents.LeftClickingMethodSoundComboBox_SelectionChanged;
        
        //
        
        _mainWindow.CpsDelimiterSlider.ValueChanged += _mainWindow.DisplayValues.DisplayLeftClickerValues.LeftCpsDelimiterValueChanged;
        _mainWindow.RightCpsDelimiterSlider.ValueChanged += _mainWindow.DisplayValues.DisplayRightClickerValues.RightCpsDelimiterValueChanged;
    }
}
using System.Windows.Controls;

namespace Autoclicker;

public class SettingsUtil
{
    private MainWindow _mainWindow;

    public SettingsUtil(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public void GetSettings()
    {
        Get(_mainWindow.LeftCpsSlider, Properties.Settings.Default.left_cps);
        Get(_mainWindow.LeftLowerCpsSlider, Properties.Settings.Default.left_lower_bound);
        Get(_mainWindow.LeftUpperCpsSlider, Properties.Settings.Default.left_upper_bound);
        Get(_mainWindow.LeftCpsDropAmountSlider, Properties.Settings.Default.left_cps_drop_amount);
        Get(_mainWindow.LeftCpsDropProbabilitySlider, Properties.Settings.Default.left_cps_drop_probability);
        Get(_mainWindow.LeftJitterXAxis, Properties.Settings.Default.left_jitter_x_axis);
        Get(_mainWindow.LeftJitterYAxis, Properties.Settings.Default.left_jitter_y_axis);
		
        Get(_mainWindow.LeftBlockhitProbabilitySlider, Properties.Settings.Default.left_blockhit_probability);
        Get(_mainWindow.BlockhitDelaySlider, Properties.Settings.Default.left_blockhit_delay);
        Get(_mainWindow.RefillSpeedSlider, Properties.Settings.Default.refill_mouse_speed);
        Get(_mainWindow.RefillXAxisRandomSlider, Properties.Settings.Default.refill_x_axis);
        Get(_mainWindow.RefillYAxisRandomSlider, Properties.Settings.Default.refill_y_axis);
        Get(_mainWindow.RefillStepsRandomSlider, Properties.Settings.Default.refill_steps);
        Get(_mainWindow.InventoryDelaySlider, Properties.Settings.Default.wait_time);
		
        Get(_mainWindow.RightCpsSlider, Properties.Settings.Default.right_cps);
        Get(_mainWindow.RightLowerCpsSlider, Properties.Settings.Default.right_lower_bound);
        Get(_mainWindow.RightUpperCpsSlider, Properties.Settings.Default.right_upper_bound);
        Get(_mainWindow.RightCpsDropAmountSlider, Properties.Settings.Default.right_cps_drop_amount);
        Get(_mainWindow.RightCpsDropProbabilitySlider, Properties.Settings.Default.right_cps_drop_probability);
        Get(_mainWindow.RightClickerJitterXAxis, Properties.Settings.Default.right_jitter_x_axis);
        Get(_mainWindow.RightClickerJitterYAxis, Properties.Settings.Default.right_jitter_y_axis);
    }

    private void Get(Slider slider, double value)
    {
        slider.Value = value;
    }

    public void SaveSettings()
    {
        Properties.Settings.Default.left_cps = _mainWindow.LeftCpsSlider.Value;
        Properties.Settings.Default.left_lower_bound = _mainWindow.LeftLowerCpsSlider.Value;
        Properties.Settings.Default.left_upper_bound = _mainWindow.LeftUpperCpsSlider.Value;
        Properties.Settings.Default.left_cps_drop_amount = _mainWindow.LeftCpsDropAmountSlider.Value;
        Properties.Settings.Default.left_cps_drop_probability = _mainWindow.LeftCpsDropProbabilitySlider.Value;
        Properties.Settings.Default.left_jitter_x_axis = _mainWindow.LeftJitterXAxis.Value;
        Properties.Settings.Default.left_jitter_y_axis = _mainWindow.LeftJitterYAxis.Value;
        Properties.Settings.Default.left_blockhit_probability = _mainWindow.LeftBlockhitProbabilitySlider.Value;
        Properties.Settings.Default.left_blockhit_delay = _mainWindow.BlockhitDelaySlider.Value;
        Properties.Settings.Default.refill_mouse_speed = _mainWindow.RefillSpeedSlider.Value;
        Properties.Settings.Default.refill_x_axis = _mainWindow.RefillXAxisRandomSlider.Value;
        Properties.Settings.Default.refill_y_axis = _mainWindow.RefillYAxisRandomSlider.Value;
        Properties.Settings.Default.refill_steps = _mainWindow.RefillStepsRandomSlider.Value;
        Properties.Settings.Default.wait_time = _mainWindow.InventoryDelaySlider.Value;
        Properties.Settings.Default.right_cps = _mainWindow.RightCpsSlider.Value;
        Properties.Settings.Default.right_lower_bound = _mainWindow.RightLowerCpsSlider.Value;
        Properties.Settings.Default.right_upper_bound = _mainWindow.RightUpperCpsSlider.Value;
        Properties.Settings.Default.right_cps_drop_amount = _mainWindow.RightCpsDropAmountSlider.Value;
        Properties.Settings.Default.right_cps_drop_probability = _mainWindow.RightCpsDropProbabilitySlider.Value;
        Properties.Settings.Default.right_jitter_x_axis = _mainWindow.RightClickerJitterXAxis.Value;
        Properties.Settings.Default.right_jitter_y_axis = _mainWindow.RightClickerJitterYAxis.Value;
        Properties.Settings.Default.Save();
    }
}
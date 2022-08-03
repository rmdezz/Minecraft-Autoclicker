using System.Windows;

namespace Autoclicker.components.events.left_clicker;

public class LeftClickerSoundEvents
{
    private ComponentsEvents _componentsEvents;

    public LeftClickerSoundEvents(ComponentsEvents componentsEvents)
    {
        _componentsEvents = componentsEvents;
    }

    private void CollapseLeftSoundsButton()
    {
        _componentsEvents.MainWindow.LeftNormalClickButton.Visibility = Visibility.Collapsed;
        _componentsEvents.MainWindow.ButterflyButton.Visibility = Visibility.Collapsed;
        _componentsEvents.MainWindow.JitterButton.Visibility = Visibility.Collapsed;
    }

    private void ShowLeftSoundButton(UIElement button)
    {
        CollapseLeftSoundsButton();
        button.Visibility = Visibility.Visible;
    }

    public void LeftClickingMethodSoundComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (_componentsEvents.MainWindow.LeftClickingMethodSoundComboBox.SelectedIndex == 0) // normal click
        {
            ShowLeftSoundButton(_componentsEvents.MainWindow.LeftNormalClickButton);
        }
        else if (_componentsEvents.MainWindow.LeftClickingMethodSoundComboBox.SelectedIndex == 1) // jitter click
        {
            ShowLeftSoundButton(_componentsEvents.MainWindow.JitterButton);
        }
        else if (_componentsEvents.MainWindow.LeftClickingMethodSoundComboBox.SelectedIndex == 2) // butterfly click
        {
            ShowLeftSoundButton(_componentsEvents.MainWindow.ButterflyButton);
        }
    }
}
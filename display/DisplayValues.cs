namespace Autoclicker.display;

public class DisplayValues
{
    public readonly MainWindow MainWindow;

    public DisplayValues(MainWindow mainWindow)
    {
        MainWindow = mainWindow;
        DisplayLeftClickerValues = new DisplayLeftClickerValues(this);
        DisplayRightClickerValues = new DisplayRightClickerValues(this);
    }

    public DisplayLeftClickerValues DisplayLeftClickerValues { get; }
    public DisplayRightClickerValues DisplayRightClickerValues { get; }
}
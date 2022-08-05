using Autoclicker.components.events.color;
using Autoclicker.components.events.left_clicker;
using Autoclicker.components.events.right_Clicker;

namespace Autoclicker.components.events;

public class ComponentsEvents
{
    public readonly MainWindow MainWindow;
    private ComponentsEventsUtil _componentsEventsUtil;
    public readonly LeftClickerSoundEvents LeftClickerSoundEvents;
    private readonly LeftClickerEvents _leftClickerEvents;
    private readonly RightClickerEvents _rightClickerEvents;
    private readonly RainbowColorEvents _rainbowColorEvents;

    public ComponentsEvents(MainWindow mainWindow)
    {
        MainWindow = mainWindow;
        RightClickerSoundEvents = new RightClickerSoundEvents(this, mainWindow);
        LeftClickerSoundEvents = new LeftClickerSoundEvents(this);
        _leftClickerEvents = new LeftClickerEvents(this, mainWindow);
        _rightClickerEvents = new RightClickerEvents(this);
        _rainbowColorEvents = new RainbowColorEvents(this);
        _componentsEventsUtil = new ComponentsEventsUtil(MainWindow, this);
    }

    public RightClickerSoundEvents RightClickerSoundEvents { get; }

    public LeftClickerEvents LeftClickerEvents
    {
        get { return _leftClickerEvents; }
    }

    public RightClickerEvents RightClickerEvents
    {
        get { return _rightClickerEvents; }
    }

    public RainbowColorEvents RainbowColorEvents
    {
        get { return _rainbowColorEvents; }
    }
}
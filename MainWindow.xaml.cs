using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Autoclicker.clicker;
using Autoclicker.components.events;
using Autoclicker.display;
using Autoclicker.hooks;
using Autoclicker.sound;
using MahApps.Metro;
using MaterialDesignThemes.Wpf;
using Application = System.Windows.Application;
using ColorPicker = Autoclicker.components.color.ColorPicker;

namespace Autoclicker;

public partial class MainWindow
{
	public static bool IsRunning = true;
	    
	public int LeftClickerKey;
	public int GetInventoryKey;
	public int RightClickerKey;
	public int GodBridgeKey;
	public int TellyBridgeKey;
	public int DragClickKey;
	public int RightNormalClickKey;
	public int BreezilyKey;
	public int MoonwalkKey;
	    
	public int LeftNormalClickKey;
	public int JitterKey;
	public int ButterflyKey;
	    
	public readonly PictureBox PicRainbow;
	    
	// Boolean values
	public bool FirstLeftClick = true; 
	public bool FirstRightClick = true;
	    
	public bool IsLeftClickerEnabled;
	public bool IsRightClickerEnabled;
        
	public bool IsGodBridgeEnabled;
	public bool IsTellyBridgeEnabled;
	public bool IsDragClickEnabled;
	public bool IsRightNormalClickEnabled;
	public bool IsBreezilyEnabled;
	public bool IsMoonwalkEnabled;

	public bool IsLeftNormalClickEnabled;
	public bool IsLeftJitterClickEnabled;
	public bool IsLeftButterflyClickEnabled;
	    
	public ColorPicker ColorPicker { get; }
	private ComponentsEvents ComponentsEvents { get; }
	public DisplayValues DisplayValues { get; }
	private Clicker Clicker { get;  }
	private Worker Worker { get; }
	private MinecraftUtil MinecraftUtil { get; }


	public Thread RainbowThread;
	public Thread LeftClickerThread;
	public Thread RightClickerThread;
	public Thread MinecraftThread;
	    
	public SolidColorBrush SelectedColor;
	    

	/* Declare DLL */
	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool GetAsyncKeyState(int vKey);

	public MainWindow()
	{
		InitializeComponent();

		DisplayValues = new DisplayValues(this);
		Clicker = new Clicker(this);
		Worker = new Worker(this);
		MinecraftUtil = new MinecraftUtil(this);

		PicRainbow = new PictureBox();
		WindowsFormsHost1.Child = PicRainbow;
		ColorPicker = new ColorPicker(this);
		SetTheme();
		ComponentsEvents = new ComponentsEvents(this);
	}

	private static void SetTheme()
	{
		// 255, 87, 0
		Color rainbowNumberToColor = Color.FromRgb(255, 155, 0);
		PaletteHelper paletteHelper = new PaletteHelper();
		ITheme theme = paletteHelper.GetTheme();
		theme.SetPrimaryColor(rainbowNumberToColor);
		paletteHelper.SetTheme(theme);
	        
		theme.SetSecondaryColor(rainbowNumberToColor);
		paletteHelper.SetTheme(theme);

		ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Steel"),
			ThemeManager.GetAppTheme("BaseDark"));
	}

	private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
	{
		Process process = Process.GetCurrentProcess();
		process.PriorityBoostEnabled = true;
		process.PriorityClass = ProcessPriorityClass.High;
			
		SetDefaultValuesOnLoad();
	}

	private void SetDefaultValuesOnLoad()
	{
		/* Set default values */
		LeftCpsDropProbabilitySlider.Value = 22;
		LeftCpsDropAmountSlider.Value = 2.5;
		LeftCpsDropAmountSlider.Minimum = 0;
		LeftCpsDropAmountSlider.Maximum = 5;
		InventoryDelaySlider.Value = 1;
		RefillSpeedSlider.Value = 30;
		RefillStepsRandomSlider.Value = 30;
		RefillXAxisRandomSlider.Value = 5;
		RefillYAxisRandomSlider.Value = 5;

		LeftClickerPriorityThread.Items.Add("Below Normal");
		LeftClickerPriorityThread.Items.Add("Above Normal");
		LeftClickerPriorityThread.Items.Add("Normal");
		LeftClickerPriorityThread.Items.Add("Lowest");
		LeftClickerPriorityThread.Items.Add("Highest");

		RightClickerPriorityThread.Items.Add("Below Normal");
		RightClickerPriorityThread.Items.Add("Above Normal");
		RightClickerPriorityThread.Items.Add("Normal");
		RightClickerPriorityThread.Items.Add("Lowest");
		RightClickerPriorityThread.Items.Add("Highest");

		LeftClickerPriorityThread.SelectedIndex = 4;
		RightClickerPriorityThread.SelectedIndex = 4;

		LeftClickerSoundPickerComboBox.Items.Add("NONE");
		LeftClickerSoundPickerComboBox.Items.Add("Roccat Kain 100");

		LeftClickerSoundPickerComboBox.SelectedIndex = 0;

		RightClickerSoundPickerComboBox.Items.Add("NONE");
		RightClickerSoundPickerComboBox.Items.Add("Roccat Kain 100");

		RightClickerSoundPickerComboBox.SelectedIndex = 0;

		RightClickingMethodSoundComboBox.Items.Add("Normal");
		RightClickingMethodSoundComboBox.Items.Add("Drag");
		RightClickingMethodSoundComboBox.Items.Add("Breezily");
		RightClickingMethodSoundComboBox.Items.Add("God Bridge");
		RightClickingMethodSoundComboBox.Items.Add("Telly Bridge");
		RightClickingMethodSoundComboBox.Items.Add("Moonwalk");

		LeftClickingMethodSoundComboBox.Items.Add("Normal");
		LeftClickingMethodSoundComboBox.Items.Add("Jitter");
		LeftClickingMethodSoundComboBox.Items.Add("Butterfly");
	}

	private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		IsRunning = false;
		if (LeftClickerThread.IsAlive) LeftClickerThread.Abort();
		if (RightClickerThread.IsAlive) RightClickerThread.Abort();
		if (RainbowThread.IsAlive) RainbowThread.Abort();
		if (MinecraftThread.IsAlive) MinecraftThread.Abort();
		if (Clicker.MouseControl.SoundData.MakeSoundsThread.IsAlive) Clicker.MouseControl.SoundData.MakeSoundsThread.Abort();
		Clicker.MouseHook.UninstallMouseHook();	
		Worker.KeyHook.Uninstall();
	}
}
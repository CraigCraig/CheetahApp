namespace CheetahApp;

using CheetahApp.Commands;
using CheetahUtils;

/// <summary>
/// Creates a new Console App.
/// </summary>
public class ConsoleApp(AppInfo info, AppSettings settings) : App(info, settings)
{
	public override void Start()
	{
	}

	public override void Update()
	{
		while (true)
		{
		}
	}

	public override void Close()
	{
	}
}

/// <summary>
/// Creates a new Window App, using SFML.
/// </summary>
public class WindowApp() : App(new(), new())
{
	public override void Start()
	{
	}

	public override void Update()
	{
		while (true)
		{
		}
	}

	public override void Close()
	{
	}
}

/// <summary>
/// Base class for all Applications.
/// <para>See also <seealso cref="ConsoleApp"/> and <seealso cref="WindowApp" /></para>
/// </summary>
public class App
{
	public AppInfo Info { get; }
	public AppSettings Settings { get; }

	// TODO: Create the Module system
	// TODO: Create the Command system
	// TODO: Create the Plugin system

	private CommandHandler _commandHandler;


	public App(AppInfo info, AppSettings settings)
	{
		Log.WriteLine($"{info}");

		_commandHandler = new CommandHandler();
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		while (true)
		{
		}
	}

	public virtual void Close()
	{
	}
}

//public class App
//{
//public static string Name { get; set; } = string.Empty;
//public static string Author { get; set; } = string.Empty;
//public static string Version { get; set; } = string.Empty;

//public static App? Instance { get; private set; }
//public readonly RootElement RootElement = new(new(0, 0));
//private readonly RenderWindow _window;

//public App(AppSettings settings)
//{
//	Instance = this;

// TODO: Console App Framework

// TODO: Fix UI Framework

//ConsoleInitializer.Initialize();
//Log.Info($"{Colors.White}{Name} v{Version} by {Author}");
//Log.Info($"{Colors.White}CheeseyUI v{CheesyUI.Version}");
//Log.Info($"{Colors.White}CheeseyUtils v{CheeseyUtils.Version}");
//_window = new(new VideoMode(settings.Width, settings.Height), settings.Title);
//RootElement.Position = new Vector2f(0, 0);
//RootElement.Size = new Vector2f(settings.Width, settings.Height);
//_window.SetFramerateLimit(60);
//_ = _window.SetActive(true);

//_window.Closed += (sender, args) => _window.Close();
//}

/// <summary>
/// Closes the application.
/// </summary>
//public static void Close()
//{
//	Instance?._window.Close();
//}

//public void Run()
//{
//	while (_window.IsOpen)
//	{
//		_window.DispatchEvents();
//		_window.Clear();

//		Input.Update(_window);
//		RootElement.Draw(_window);

//		_window.Display();
//	}
//}
//}
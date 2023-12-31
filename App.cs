﻿namespace CheetahApp;

using CheetahApp.Commands;
using CheetahApp.Modules;
using CheetahApp.Plugins;
using System;

/// <summary>
/// Base class for all Applications.
/// <para>See also <seealso cref="ConsoleApp"/> and <seealso cref="WindowApp" /></para>
/// </summary>
public class App
{
	public AppInfo Info { get; }
	public AppSettings Settings { get; }

	private CommandHandler _commandHandler;
	private ModuleHandler _moduleHandler;
	private PluginHandler _pluginHandler;

	public App(AppInfo info, AppSettings settings)
	{
        Console.WriteLine("CheetahTerminal: v1.0.0-nightly");

		_commandHandler = new();
		_moduleHandler = new();
		_pluginHandler = new();
	}

	public virtual void Start()
	{

        PrintPrompt();
        while (true)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
				string command = input.Split(' ')[0];
				string[] arguments = input.Split(' ')[1..];
				_commandHandler.HandleCommand(command, arguments);
            }
			PrintPrompt();
        }

        void PrintPrompt() => Console.Write("nightly@CTerm -> "); // TODO: Make a better prompt
    }

	public virtual void Update()
	{
	}

	public virtual void Command(CommandContext context)
	{
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
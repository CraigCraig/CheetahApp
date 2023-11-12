namespace CheeseyUI;

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using CheeseyUtils;
using CheeseyUtils.Console;

public class App
{
    public static string Name { get; set; } = string.Empty;
    public static string Author { get; set; } = string.Empty;
    public static Version Version { get; set; } = new(0, 0, 0, 0);

    public static App? Instance { get; private set; }
    public readonly RootElement RootElement = new(new(0, 0));
    private readonly RenderWindow _window;

    public App(AppSettings settings)
    {
        ConsoleInitializer.Initialize();
        Log.WriteLine($"{Name} v{Version} by {Author}");
        Instance = this;
        _window = new(new VideoMode(settings.Width, settings.Height), settings.Title);
        RootElement.Position = new Vector2f(0, 0);
        RootElement.Size = new Vector2f(settings.Width, settings.Height);
        _window.SetFramerateLimit(60);
        _ = _window.SetActive(true);

        _window.Closed += (sender, args) => _window.Close();
    }

    /// <summary>
    /// Closes the application.
    /// </summary>
    public static void Close()
    {
        Instance?._window.Close();
    }

    public void Run()
    {
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            _window.Clear();

            Input.Update(_window);
            RootElement.Draw(_window);

            _window.Display();
        }
    }
}
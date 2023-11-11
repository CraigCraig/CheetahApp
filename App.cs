namespace CheeseyUI;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class App
{
    public static class AppInfo
    {
        public static string Name { get; set; } = string.Empty;
        public static string Author { get; set; } = string.Empty;
        public static Version Version { get; set; } = new(0, 0, 0, 0);
    }

    public static App? Instance { get; }
    public readonly Element RootElement = new(null, new(0, 0), new(0, 0), bgColor: Colors.DarkGray);
    private readonly RenderWindow _window;

    public App(AppSettings settings)
    {
        _window = new(new VideoMode(settings.Width, settings.Height), settings.Title);
        RootElement.Position = new Vector2f(0, 0);
        RootElement.Size = new Vector2f(settings.Width, settings.Height);
        _window.SetFramerateLimit(60);

        _window.Closed += (sender, args) => _window.Close();

        _window.KeyPressed += (sender, args) =>
        {
            if (args.Code == Keyboard.Key.Escape)
            {
                _window.Close();
            }
        };

        _window.MouseButtonPressed += (sender, args) =>
        {
            Input.HandleMouseClick(args);
        };

        _window.MouseMoved += (sender, args) =>
        {
            Input.MousePosition = new(args.X, args.Y);
        };
    }

    public void Close()
    {
        _window.Close();
    }

    public void Run()
    {
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            _window.Clear();

            RootElement.Draw(_window);

            _window.Display();
        }
    }
}
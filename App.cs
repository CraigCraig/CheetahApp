namespace CheeseyUI;

using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class App
{
    public static App? Instance { get; }
    public readonly Element RootElement = new(new(0, 0), new(0, 0), null, true);
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
            Input.OnMouseClicked.Invoke(this, args);
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

public static class Input
{
    public static EventHandler<MouseButtonEventArgs> OnMouseClicked { get; } = (sender, args) => { };
    public static Vector2i MousePosition { get; internal set; }

    internal static void HandleMouseClick(MouseButtonEventArgs args)
    {
        if (App.Instance is null) return;

        lock (App.Instance.RootElement.Children)
        {
            foreach (var element in App.Instance.RootElement.Children)
            {
                if (element.IsActive)
                {
                    if (element.IsMouseOver())
                    {
                        if (element is Button button)
                        {
                            button.HandleClick();
                            break;
                        }
                    }
                }
            }

            OnMouseClicked.Invoke(null, args);
        }
    }
}
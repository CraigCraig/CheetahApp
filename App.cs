namespace CheeseyUI;

using System;
using SFML.Window;

public class App
{
    public readonly List<Element> RootElements = [];
    private readonly Window _window;

    public App(AppSettings settings)
    {
        _window = new Window(new VideoMode(settings.Width, settings.Height), settings.Title);
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
            InputHandler.HandleInput();
            if (args.Button == Mouse.Button.Left)
            {
                Console.WriteLine($"Mouse clicked at {args.X}, {args.Y}");
            }
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

            foreach (var element in RootElements)
            {
                element.Draw(_window);
            }

            _window.Display();
        }
    }
}

internal class InputHandler
{
    internal static void HandleInput()
    {
    }
}

public class Input
{
}
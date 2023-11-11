namespace CheeseyUI;

using SFML.Window;

public class App
{
    private readonly Window _window;

    public App()
    {
        _window = new Window(new VideoMode(800, 600), "CheeseyUI");

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
            if (args.Button == Mouse.Button.Left)
            {
                Console.WriteLine($"Mouse clicked at {args.X}, {args.Y}");
            }
        };

        while(_window.IsOpen)
        {
            _window.DispatchEvents();
            _window.Clear();
            _window.Display();
        }
    }
}
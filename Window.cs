namespace CheeseyUI;

using SFML.Window;

internal class Window(VideoMode mode, string title) : SFML.Graphics.RenderWindow(mode, title)
{
}
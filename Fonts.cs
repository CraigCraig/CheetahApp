namespace CheeseyUI;

using SFML.Graphics;

public static class Fonts
{
    public static string FontPath { get; set; } = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Fonts)}\";
    public static Font Arial { get; set; } = new(FontPath + "arial.ttf");

}
namespace CheeseyUI;

using CheeseyUtils;

public static class ColorExtensions
{
    public static SFML.Graphics.Color ToSFMLColor(this Color color)
    {
        return new SFML.Graphics.Color(color.R, color.G, color.B, color.A);
    }

    public static Color ToCheeseyColor(this SFML.Graphics.Color sfmlColor)
    {
        return new Color(sfmlColor.R, sfmlColor.G, sfmlColor.B, sfmlColor.A);
    }
}
namespace CheeseyUI;

public class Color : CheeseyUtils.Color
{
    public Color(byte r, byte g, byte b, byte a) : base(r, g, b, a)
    {
    }

    public Color(string hex) : base(hex)
    {
    }

    // Cast to SFML.Color
    public static implicit operator SFML.Graphics.Color(Color color) => new(color.R, color.G, color.B, color.A);

    // Cast from SFML.Color
    public static implicit operator Color(SFML.Graphics.Color color) => new(color.R, color.G, color.B, color.A);
}
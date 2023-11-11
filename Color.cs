namespace CheeseyUI;

public class Color : CheeseyUtils.Color
{
    public Color(byte r, byte g, byte b, byte a) : base(r, g, b, a)
    {
    }

    public Color(string hex) : base(hex)
    {
    }

    /// <summary>
    /// A struct containing the default colors.
    /// </summary>
    public readonly struct DefaultColors
    {
        public static Color Transparent { get; } = new(0, 0, 0, 0);
        public static Color Black { get; } = new(0, 0, 0, 255);
        public static Color White { get; } = new(255, 255, 255, 255);
        public static Color Red { get; } = new(255, 0, 0, 255);
        public static Color Green { get; } = new(0, 255, 0, 255);
        public static Color Blue { get; } = new(0, 0, 255, 255);
        public static Color Yellow { get; } = new(255, 255, 0, 255);
        public static Color Magenta { get; } = new(255, 0, 255, 255);
        public static Color Cyan { get; } = new(0, 255, 255, 255);
    }

    // Cast to SFML.Color
    public static implicit operator SFML.Graphics.Color(Color color) => new(color.R, color.G, color.B, color.A);

    // Cast from SFML.Color
    public static implicit operator Color(SFML.Graphics.Color color) => new(color.R, color.G, color.B, color.A);
}
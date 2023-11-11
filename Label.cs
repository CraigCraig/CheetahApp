namespace CheeseyUI;

using SFML.Graphics;
using SFML.System;

public class Label(Element? parent, Vector2f position, Vector2f size, string text) : Element(parent, position, size)
{
    public Text Text { get; set; } = new(text, Fonts.Arial);

    public override void Draw(RenderTarget target)
    {
        base.Draw(target);
        Text.Draw(target, RenderStates.Default);
    }
}

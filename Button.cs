namespace CheeseyUI;

using SFML.Graphics;
using SFML.System;

public class Button(Vector2f position, Vector2f size, string text, Action onClick) : Element(position, size)
{
    public Label Label { get; set; } = new(position, size, text);
    public Action OnClick { get; set; } = onClick;

    public override void Draw(RenderTarget target)
    {
        base.Draw(target);
        Label.Draw(target);
    }
}

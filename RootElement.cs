namespace CheeseyUI;

using CheeseyUtils;
using SFML.Graphics;
using SFML.System;

public class RootElement : Element
{
    public RootElement(Vector2f size) : base(null, new Vector2f(0, 0), size)
    {
        BgColor = Colors.DarkGray;
    }

    public override void Draw(RenderTarget target)
    {
        base.Draw(target);
    }
}
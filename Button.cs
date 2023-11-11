﻿namespace CheeseyUI;

using SFML.Graphics;
using SFML.System;

public class Button : Element
{
    public Button(Vector2f position, Vector2f size, string text, Action onClick, Color? color = null) : base(position, size)
    {
        Label = new(position, size, text);
        Children.Add(Label);
        OnClick = onClick;
        BgColor = Color.DefaultColors.Blue;
    }

    public Label Label { get; set; }
    public Action OnClick { get; set; }

    internal void HandleClick()
    {
        OnClick.Invoke();
    }

    public override void Draw(RenderTarget target)
    {
        if (IsActive)
        {
            if (IsMouseOver())
            {
                BgColor = Color.DefaultColors.Cyan;
            }
            else
            {
                BgColor = Color.DefaultColors.Blue;
            }
        }
        base.Draw(target);
    }

    private bool IsMouseOver()
    {
        var mousePos = Input.MousePosition;
        var pos = Position;
        var size = Size;

        return mousePos.X >= pos.X && mousePos.X <= pos.X + size.X && mousePos.Y >= pos.Y && mousePos.Y <= pos.Y + size.Y;
    }
}

﻿namespace CheeseyUI;

using CheeseyUtils;
using SFML.Graphics;
using SFML.System;
using Color = CheeseyUtils.Color;

public class Element
{
    public Element? Parent { get; set; }

    public List<Element> Children { get; set; } = [];

    public Vector2f Position { get; set; }

    public Vector2f Size { get; set; }

    public bool IsActive { get; set; }

    public Color BgColor
    {
        get => _bg.FillColor.ToCheeseyColor();
        set => _bg.FillColor = value.ToSFMLColor();
    }

    private readonly RectangleShape _bg;

    public Element(Element? parent, Vector2f position, Vector2f size, bool active = true, Color? bgColor = null)
    {
        if (parent != null)
        {
            SetParent(parent);
        }

        Position = position;
        Size = size;
        IsActive = active;

        _bg = new RectangleShape
        {
            FillColor = (bgColor ?? Colors.Transparent).ToSFMLColor(),
        };
    }

    public void SetParent(Element parent)
    {
        Parent?.RemoveChild(this);
        Parent = parent;
        parent.Children.Add(this);
    }

    public void AddChild(Element child)
    {
        child.Parent = this;
        Children.Add(child);
    }

    public void RemoveChild(Element child)
    {
        child.Parent = null;
        _ = Children.Remove(child);
    }

    public virtual void Draw(RenderTarget target)
    {
        if (IsActive)
        {
            _bg.Position = Position;
            _bg.Size = Size;
            _bg.Draw(target, RenderStates.Default);
            foreach (var child in Children)
            {
                child.Draw(target);
            }
        }
    }

    public bool IsMouseOver()
    {
        var mousePos = Input.MousePosition;
        var pos = Position;
        var size = Size;

        return mousePos.X >= pos.X && mousePos.X <= pos.X + size.X && mousePos.Y >= pos.Y && mousePos.Y <= pos.Y + size.Y;
    }
}
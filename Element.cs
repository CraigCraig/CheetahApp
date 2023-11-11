namespace CheeseyUI;

using SFML.Graphics;
using SFML.System;

public class Element
{
    public Element? Parent { get; set; }

    public List<Element> Children { get; set; } = [];

    public Vector2f Position { get; set; }

    public Vector2f Size { get; set; }

    public bool IsActive { get; set; }

    public Color BgColor
    {
        get => _bg.FillColor;
        set => _bg.FillColor = value;
    }

    private readonly RectangleShape _bg;

    public Element(Vector2f position, Vector2f size, Element? parent = null, bool active = true, Color? bgColor = null)
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
            FillColor = bgColor ?? Color.DefaultColors.Transparent,
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
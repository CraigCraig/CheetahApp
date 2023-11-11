namespace CheeseyUI;

using SFML.Graphics;
using SFML.System;

public class Element(Vector2f position, Vector2f size, bool active = true)
{
    public Element? Parent { get; set; }

    public List<Element> Children { get; set; } = [];

    public Vector2f Position { get; set; } = position;

    public Vector2f Size { get; set; } = size;

    public bool IsActive { get; set; } = active;

    private readonly RectangleShape? _bg;

    public void SetParent(Element parent)
    {
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
            _bg?.Draw(target, RenderStates.Default);
            foreach (var child in Children)
            {
                child.Draw(target);
            }
        }
    }
}
namespace CheeseyUI;

using CheeseyUtils;
using SFML.Graphics;
using SFML.System;
using Color = CheeseyUtils.Color;

public class Button : Element
{
    public Button(Element? parent, Vector2f position, Vector2f size, string text, Action? onClick = null, Color? color = null) : base(parent, position, size)
    {
        Label = new(this, position, size, text);
        Children.Add(Label);
        OnClick = onClick;
    }

    public Label Label { get; set; }
    public Action? OnClick { get; set; }

    internal void HandleClick()
    {
        try
        {
            OnClick?.Invoke();
        }
        catch (Exception e)
        {
            throw new Exception($"Error while handling click for button '{Label.Text.DisplayedString}': {e.Message}");
        }
    }

    public override void Draw(RenderTarget target)
    {
        if (IsActive)
        {
            if (IsMouseOver())
            {
                BgColor = (Color) Colors.LightBlue;
            }
            else
            {
                BgColor = (Color) Colors.Blue;
            }
        }
        base.Draw(target);
    }
}

namespace CheeseyUI;

using System;
using SFML.System;
using SFML.Window;

public static class Input
{
    public static EventHandler<MouseButtonEventArgs> OnMouseClicked { get; } = (sender, args) => { };
    public static Vector2i MousePosition { get; internal set; }

    internal static void HandleMouseClick(MouseButtonEventArgs args)
    {
        if (App.Instance is null) return;

        lock (App.Instance.RootElement.Children)
        {
            foreach (var element in App.Instance.RootElement.Children)
            {
                if (element.IsActive)
                {
                    if (element.IsMouseOver())
                    {
                        if (element is Button button)
                        {
                            button.HandleClick();
                            break;
                        }
                    }
                }
            }

            OnMouseClicked.Invoke(null, args);
        }
    }
}
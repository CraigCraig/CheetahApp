namespace CheeseyUI;

using SFML.System;

public static class Input
{
    public static Vector2i MousePosition { get; internal set; }

    internal static void HandleMouseClick()
    {
        if (App.Instance is null || App.Instance.RootElement is null) return;

        lock (App.Instance.RootElement.Children)
        {
            foreach (var element in App.Instance.RootElement.Children)
            {
                if (element is Button button && button.IsActive && button.IsMouseOver())
                {
                    button.HandleClick();
                    break;
                }
            }
        }
    }
}
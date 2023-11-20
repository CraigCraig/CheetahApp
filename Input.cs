namespace CheetahApp;

using SFML.System;
using SFML.Window;

public static class Input
{
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

	internal static void Update(SFML.Graphics.RenderWindow _window)
	{
		Mouse.Update(_window);
		if (Mouse.IsButtonPressed(Mouse.Button.Left))
		{
			HandleMouseClick();
		}

		if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
		{
			App.Close();
		}
	}
}

public static class Mouse
{
	public enum Button
	{
		Left,
		Right,
	}

	public static Vector2i Position { get; private set; } = new(0, 0);

	private static List<Button> _pressedButtons { get; } = [];

	private static List<Button> _downButtons { get; } = [];

	public static bool IsButtonDown(Button button)
	{
		return _downButtons.Contains(button);
	}

	public static bool IsButtonPressed(Button button)
	{
		return _pressedButtons.Contains(button);
	}

	internal static void Update(SFML.Graphics.RenderWindow _window)
	{
		Position = SFML.Window.Mouse.GetPosition(_window);
		_pressedButtons.Clear();

		if (SFML.Window.Mouse.IsButtonPressed(SFML.Window.Mouse.Button.Left))
		{
			if (!_downButtons.Contains(Button.Left))
			{
				_pressedButtons.Add(Button.Left);
				_downButtons.Add(Button.Left);
			}
		}
		else
		{
			_ = _downButtons.Remove(Button.Left);
		}

		if (SFML.Window.Mouse.IsButtonPressed(SFML.Window.Mouse.Button.Right))
		{
			if (!_downButtons.Contains(Button.Right))
			{
				_pressedButtons.Add(Button.Right);
				_downButtons.Add(Button.Right);
			}
		}
		else
		{
			_ = _downButtons.Remove(Button.Right);
		}
	}
}
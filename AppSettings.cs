namespace CheetahApp;

public struct AppSettings(string title = "CheetahApp", AppSettings.AppType type = AppSettings.AppType.Console)
{
	public string Title = title;
	public AppType Type = type;

	public enum AppType
	{
		Window,
		Console
	}
}
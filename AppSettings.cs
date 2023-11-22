namespace CheetahApp;

public struct AppSettings(string title = "CheetahApp", AppType type = AppType.Console)
{
	public string Title = title;
	public AppType Type = type;
}
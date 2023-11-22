namespace CheetahApp.Plugins;

using CheetahUtils;

public class PluginManager
{
	public static void Initialize()
	{
		Log.WriteLine("PluginManager Initialized");
	}
}

/// <summary>
/// Base class for plugins.
/// </summary>
public class Plugin(string name)
{
	public string Name { get; private set; } = name;
}
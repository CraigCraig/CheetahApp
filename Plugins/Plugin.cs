namespace CheetahApp.Plugins;

/// <summary>
/// Base class for plugins.
/// </summary>
public class Plugin(string name)
{
    public string Name { get; private set; } = name;
}
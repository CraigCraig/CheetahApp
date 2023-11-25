namespace CheetahApp.Modules;

/// <summary>
/// Base class for all modules.
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
public abstract class Module(string name, string description)
{
	public string Name = name;
	public string Description = description;
	public abstract void Start();
}
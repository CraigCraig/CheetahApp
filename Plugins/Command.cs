namespace CheetahApp.Plugins;

public abstract class Plugins(string name, string description)
{
	public string Name = name;
	public string Description = description;
	public abstract void Execute(string[] args);
}
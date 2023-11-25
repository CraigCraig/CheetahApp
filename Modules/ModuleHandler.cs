namespace CheetahApp.Modules;

#region Using Statements
using System.Collections.Generic;
using System.Reflection;
#endregion

public class ModuleHandler
{
	public Dictionary<string, Module> Modules { get; } = [];

	private bool _initialized;

	public ModuleHandler()
	{
		if (_initialized) return;
		_initialized = true;

		Assembly assembly = Assembly.GetExecutingAssembly();
		var types = assembly.GetTypes();
		foreach (var type in types)
		{
			if (type.BaseType == typeof(Module))
			{
				if (type == null || string.IsNullOrEmpty(type.FullName)) continue;
				if (assembly.CreateInstance(type.FullName) is not Module module) continue;
				Modules.Add(module.Name, module);
			}
		}
	}
}

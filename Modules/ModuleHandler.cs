namespace CheetahApp.Modules;

#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using CheetahApp.Commands;
#endregion

public static class ModuleHandler
{
	public static Dictionary<string, Command> Commands { get; } = [];

	private static bool _initialized;

	public static void Initialize()
	{
		if (_initialized) return;
		_initialized = true;

		Assembly assembly = Assembly.GetExecutingAssembly();
		var types = assembly.GetTypes();
		foreach (var type in types)
		{
			if (type.BaseType == typeof(Command))
			{
				if (type == null || string.IsNullOrEmpty(type.FullName)) continue;
				if (assembly.CreateInstance(type.FullName) is not Command command) continue;
				Commands.Add(command.Name, command);
			}
		}
	}

	public static void HandleCommand(string command, string[] arguments)
	{
		if (!_initialized) Initialize();
		if (string.IsNullOrEmpty(command))
		{
			Console.WriteLine("No command");
			return;
		}

		if (Commands.TryGetValue(command, out var cmd))
		{
			cmd.Execute(arguments);
		}
		else
		{
			Console.WriteLine($"Command \"{command}\" not found");
		}
	}
}

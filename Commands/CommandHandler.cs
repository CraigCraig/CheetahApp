namespace CheetahApp.Commands;

#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using CheetahUtils;
#endregion

public class CommandHandler
{
	private Dictionary<string, Command> _commands { get; } = [];

	private bool _initialized;

	public void Start()
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
				_commands.Add(command.Name, command);
			}
		}
	}

	public void HandleCommand(string command, string[] arguments)
	{
		if (!_initialized)
		{
			Log.WriteLine("CommandHandler not initialized");
			return;
		}

		if (_commands.TryGetValue(command, out var cmd))
		{
			cmd.Execute(arguments);
		}
		else
		{
			Log.WriteLine($"Command \"{command}\" not found");
		}
	}
}

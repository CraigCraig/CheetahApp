namespace CheetahApp.Commands;

#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion

public class CommandHandler
{
	public Dictionary<string, Command> Commands { get; } = [];

	private bool _initialized;

	public CommandHandler()
	{
		if (_initialized) return;
		_initialized = true;

		foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.BaseType?.Name == nameof(Command))
                {
                    if (type == null || string.IsNullOrEmpty(type.FullName)) continue;
                    if (assembly.CreateInstance(type.FullName) is not Command command) continue;
                    Commands.Add(command.Name, command);
                }
            }
        }
	}

	public void HandleCommand(string command, string[] arguments)
	{
		if (!_initialized)
		{
			Console.WriteLine("CommandHandler not initialized");
			return;
		}

		CommandContext context = new();
		if (Commands.TryGetValue(command, out var cmd))
		{
			cmd.Execute(context);
		}
		else
		{
            Console.WriteLine($"Command \"{command}\" not found");
		}
	}
}

namespace CheetahApp.Commands;

using CheetahApp;
using System;

public class Exit() : Command("exit", "quit the program")
{
    public override void Execute(CommandContext context)
    {
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }
}
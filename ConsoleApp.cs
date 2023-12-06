namespace CheetahApp;

/// <summary>
/// Creates a new Console App.
/// </summary>
public class ConsoleApp(AppInfo info, AppSettings settings) : App(info, settings)
{
	public override void Start()
	{
		base.Start();
	}

    public override void Update()
    {
        base.Update();
    }

    public override void Command(CommandContext context)
	{
		base.Command(context);
		while (true)
		{
		}
	}

	public override void Close()
	{
		base.Close();
	}
}
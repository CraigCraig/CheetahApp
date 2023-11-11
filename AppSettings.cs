namespace CheeseyUI;

public struct AppSettings
{
    public uint Width = 800;
    public uint Height = 600;
    public string Title = "CheeseyUI";

    public AppSettings(uint? width, uint? height, string? title)
    {
        if (width is not null)
        {
            Width = width.Value;
        }

        if (height is not null)
        {
            Height = height.Value;
        }

        if (title is not null)
        {
            Title = title;
        }
    }
}

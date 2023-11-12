namespace CheeseyUI;

using CheeseyUtils;

/// <summary>
/// Class specific to CheesyUI.
/// </summary>
public static class CheesyUI
{
    /// <summary>
    /// The version of CheesyUI.
    /// </summary>
    public static Version Version { get; } = new(0, 0, 1, 0, 0, Version.ReleaseChannel.Development);

    /// <summary>
    /// Author of CheesyUI.
    /// </summary>
    public static string Author { get; } = "Craig Craig";

    /// <summary>
    /// Description of CheesyUI.
    /// </summary>
    public static string Description { get; } = "A UI library for SFML.";

    /// <summary>
    /// Repository of CheesyUI.
    /// </summary>
    public static string Repository { get; } = "https://github.com/CraigCriag/CheeseyUI";
}
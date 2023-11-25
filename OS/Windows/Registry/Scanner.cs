#if WINDOWS
namespace CheetahApp.OS.Windows.Registry;

using System;
using System.IO;
using System.Runtime.Versioning;
using Microsoft.Win32;

internal static class Scanner
{
    [SupportedOSPlatform("windows")]
    public static void DoScan()
    {
        Console.WriteLine("This feature is still in development and may not work properly.");

        var uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall")
            ?? throw new Exception("Uninstall key not found.");

        foreach (var subKeyName in uninstallKey.GetSubKeyNames())
        {
            var subKey = uninstallKey.OpenSubKey(subKeyName);
            if (subKey is not null && CheckUninstallEntry(subKey))
            {
                Console.WriteLine("Removing Registry Entries Not Supported Yet");
                //uninstallKey.DeleteSubKey(subKeyName, true);
            }
        }
    }

    /// <summary>
    /// Checks if the given uninstall entry is a ghost app.
    /// </summary>
    /// <param name="subKey"></param>
    /// <returns>true if the entry is a ghost app, otherwise false</returns>
    [SupportedOSPlatform("windows")]
    private static bool CheckUninstallEntry(RegistryKey subKey)
    {
        bool result = false;
        var displayName = subKey.GetValue("DisplayName")?.ToString();
        var displayIcon = subKey.GetValue("DisplayIcon")?.ToString()?.Split(',')[0];
        var installLocation = subKey.GetValue("InstallLocation")?.ToString();
        var uninstallString = subKey.GetValue("UninstallString")?.ToString();

        if (!string.IsNullOrEmpty(displayIcon) && !File.Exists(displayIcon))
        {
            result = true;
        }

        if (!string.IsNullOrEmpty(installLocation))
        {
            if (!Directory.Exists(installLocation))
            {
                result = true;
            }
        }

        if (result && !string.IsNullOrEmpty(displayName))
        {
            Console.WriteLine($"{displayName} - is a ghost app");
        }

        return result;
    }
}
#endif
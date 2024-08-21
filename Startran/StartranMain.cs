using System.IO;
using Startran.Forms;

namespace Startran;

public static class StartranMain
{
    public static readonly string AppSavingPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StarTran");

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
    }
}
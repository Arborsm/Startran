using System.IO;
using Startran.Forms;

namespace Startran;

public static class StartranMain
{
    public static readonly string AppSavingPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StarTran");

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
    }
}
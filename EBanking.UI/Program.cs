using EBanking.Data;
using EBanking.UI.Properties;

namespace EBanking.UI;

internal static class Program
{
    public static bool IsRunning { get; private set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        App.Initialize(new EBankingDbContext(Resources.DBPath));
        Application.Run(App.Instance);
    }
}
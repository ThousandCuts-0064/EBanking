using System.Configuration;
using EBanking.Data;
using EBanking.UI.Forms;

namespace EBanking.UI;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        App.Initialize(new EBankingDbContext(ConfigurationManager.ConnectionStrings["Database"].ConnectionString));
        Application.Run(App.Instance);
    }
}
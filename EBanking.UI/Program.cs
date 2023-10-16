using System.Configuration;
using EBanking.Data;
using EBanking.Logic.Services;

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
        var connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        var isStrictEmailValidation = bool.Parse(ConfigurationManager.AppSettings[nameof(Authenticator.IsStrictEmailValidation)]!);
        var dbContext = new EBankingDbContext(connectionString);
        var transactionService = new TransactionService(dbContext);
        var encryptionService = new EncryptionService(16, 32, 16, '-');
        var authenticator = new Authenticator(encryptionService, transactionService, dbContext, isStrictEmailValidation);
        var eBankingAppContext = new EBankingAppContext(authenticator);
        Application.Run(eBankingAppContext);
    }
}
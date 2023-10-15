using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EBanking.Logic.Services;

internal class TransactionService : ITransactionService
{
    public bool IsAmountValid(decimal amount, [NotNullWhen(false)] out string? error)
    {
        error = null;
        var sb = new StringBuilder();

        if (amount < 0)
            sb.AppendLine("Amount must be a positive number");
        
        if (amount % 0.01m > 0)
            sb.AppendLine("Amount must be with at most 2 fraction digits");

        if (sb.Length == 0)
            return true;

        error = sb.ToString();
        return false;
    }
}

using System.Diagnostics.CodeAnalysis;

namespace EBanking.Logic.Services;

public interface ITransactionService
{
    public bool IsAmountValid(decimal amount, [NotNullWhen(false)] out string? error);
}

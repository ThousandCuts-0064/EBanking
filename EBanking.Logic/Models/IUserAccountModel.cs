using System.Diagnostics.CodeAnalysis;
using EBanking.Data.Entities;

namespace EBanking.Logic.Models;

public interface IUserAccountModel
{
    public string Name { get; }
    public decimal Balance { get; }
    public Guid Key { get; }

    public bool TryAlterBalance(decimal amount, TransactionType type, [NotNullWhen(false)] out string? error);
}

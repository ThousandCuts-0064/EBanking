using System.Diagnostics.CodeAnalysis;
using EBanking.Data.Entities;
using EBanking.Logic.Models;

namespace EBanking.Logic.Services;

public interface ITransactionService
{
    public decimal WithdrawFeeFactor { get; }
    public decimal WithdrawFeeMinimal { get; }

    public bool IsAmountValid(decimal amount, ICollection<string> errors);
    public bool IsDebitValid(
        decimal currentAmount, 
        decimal debitAmount, 
        out decimal tax, 
        [NotNullWhen(false)] out string? error);

    public bool IsKeyExisting(Guid Key, [NotNullWhen(false)] out string? error);

    internal void GetAllTransactionsFor(
        IUserAccountModel userAccount,
        ICollection<ITransactionModel> transactions,
        UserAccount entityForUpdates);

    internal bool TryAlterBalance(
        IUserAccountModel userAccount,
        decimal amount, 
        TransactionType type,
        ICollection<string> errors);

    internal bool TryTransfer(
        IUserAccountModel senderAccount, 
        Guid recieverKey, 
        decimal amount,
        ICollection<string> errors);
}

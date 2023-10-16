using EBanking.Data.Entities;
using EBanking.Logic.Models;

namespace EBanking.UI.ViewModels;

internal class UserAccountViewModel
{
    private readonly IUserAccountModel _userAccount;

    public Guid Key => _userAccount.Key;
    public string Name => _userAccount.Name;
    public decimal Balance => _userAccount.Balance;

    public IEnumerable<TransactionViewModel> Transactions =>
        _userAccount.Transactions.Select(t => new TransactionViewModel(t));

    public UserAccountViewModel(IUserAccountModel userAccount) => _userAccount = userAccount;

    public override string ToString() => $"{Name}: {Balance:0.00}";

    public bool TryAlterBalance(
        decimal amount,
        TransactionType type,
        ICollection<string> errors)
    {
        var startCount = errors.Count;
        var transactionService = _userAccount.TransactionService;

        if (transactionService.IsAmountValid(amount, errors))
        {
            if (type == TransactionType.Debit
                && !transactionService.IsDebitValid(_userAccount.Balance, amount, out _, out var errorTax))
            {
                errors.Add(errorTax);
            }
        }

        return startCount == errors.Count
            && _userAccount.TryAlterBalance(amount, type, errors);
    }

    public bool TryTransfer(
        Guid recieverKey,
        decimal amount,
        ICollection<string> errors)
    {
        var startCount = errors.Count;
        var transactionService = _userAccount.TransactionService;

        if (transactionService.IsAmountValid(amount, errors)
            && Balance - amount < 0)
        {
            errors.Add("Insufficient amount");
        }

        if (Key.Equals(recieverKey))
            errors.Add("Please enter a Key of another account");

        else if (!transactionService.IsKeyExisting(recieverKey, out var errorKey))
            errors.Add(errorKey);

        return startCount == errors.Count
            && _userAccount.TryTransfer(recieverKey, amount, errors);
    }
}

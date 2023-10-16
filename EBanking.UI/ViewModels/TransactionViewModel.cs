using EBanking.Data.Entities;
using EBanking.Logic.Models;

namespace EBanking.UI.ViewModels;

internal class TransactionViewModel
{
    private readonly ITransactionModel _transaction;

    public IUserAccountModel UserAccount => _transaction.UserAccount;
    public TransactionType Type => _transaction.Type;
    public decimal Amount => _transaction.Amount;
    public DateTime EventDate => _transaction.EventDate;

    public TransactionViewModel(ITransactionModel transaction) => _transaction = transaction;
}

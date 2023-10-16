using EBanking.Data.Entities;

namespace EBanking.Logic.Models;

internal class TransactionModel : ITransactionModel
{
    private readonly Transaction _transaction;
    public IUserAccountModel UserAccount { get; }
    public TransactionType Type => _transaction.Type;
    public decimal Amount => _transaction.Amount;
    public DateTime EventDate => _transaction.EventDate;

    public TransactionModel(IUserAccountModel userAccount, Transaction transaction)
    {
        _transaction = transaction;
        UserAccount = userAccount;
    }
}

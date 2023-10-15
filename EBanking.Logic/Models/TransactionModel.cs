using EBanking.Data.Entities;

namespace EBanking.Logic.Models;

internal class TransactionModel : ITransactionModel
{
    private readonly Transaction _transaction;

    public TransactionModel(Transaction transaction)
    {
        _transaction = transaction;
    }
}

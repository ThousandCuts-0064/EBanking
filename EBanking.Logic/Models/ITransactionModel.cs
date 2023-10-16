using EBanking.Data.Entities;

namespace EBanking.Logic.Models;

public interface ITransactionModel
{
    public IUserAccountModel UserAccount { get; }
    public TransactionType Type { get; }
    public decimal Amount { get; }
    public DateTime EventDate { get; }
}

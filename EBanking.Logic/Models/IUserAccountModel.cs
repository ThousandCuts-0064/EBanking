using EBanking.Data.Entities;
using EBanking.Logic.Services;

namespace EBanking.Logic.Models;

public interface IUserAccountModel
{
    internal int Id { get; }
    internal int UserId { get; }

    public IReadOnlyList<ITransactionModel> Transactions { get; }
    public ITransactionService TransactionService { get; }
    public string Name { get; }
    public decimal Balance { get; }
    public Guid Key { get; }

    public bool TryAlterBalance(decimal amount, TransactionType type, ICollection<string> errors);
    public bool TryTransfer(Guid recieverKey, decimal amount, ICollection<string> errors);
}

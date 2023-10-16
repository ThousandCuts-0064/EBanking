using EBanking.Data.Entities;
using EBanking.Logic.Services;

namespace EBanking.Logic.Models;

internal class UserAccountModel : IUserAccountModel
{
    private readonly List<ITransactionModel> _transactions = new();
    private readonly UserAccount _entity;

    int IUserAccountModel.Id => _entity.Id;
    int IUserAccountModel.UserId => _entity.UserId;

    public IReadOnlyList<ITransactionModel> Transactions => _transactions;
    public ITransactionService TransactionService { get; }
    public Guid Key => _entity.Key;
    public string Name => _entity.FriendlyName;
    public decimal Balance => _entity.Balance;

    internal UserAccountModel(ITransactionService transactionService, UserAccount entity)
    {
        _entity = entity;
        TransactionService = transactionService;
        TransactionService.GetAllTransactionsFor(this, _transactions, _entity);
    }

    public bool TryAlterBalance(decimal amount, TransactionType type, ICollection<string> errors) =>
        TransactionService.TryAlterBalance(this, amount, type, errors);

    public bool TryTransfer(Guid recieverKey, decimal amount, ICollection<string> errors) =>
        TransactionService.TryTransfer(this, recieverKey, amount, errors);
}

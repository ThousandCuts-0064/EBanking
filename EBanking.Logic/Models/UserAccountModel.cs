using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Linq;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.Logic.Services;

namespace EBanking.Logic.Models;

internal class UserAccountModel : IUserAccountModel
{
    private readonly List<TransactionModel> _transactions;
    private readonly ITransactionService _transactionService;
    private readonly IEbankingDbContext _dbContext;
    private readonly UserAccount _userAccount;
    public Guid Key => _userAccount.Key;
    public string Name => _userAccount.FriendlyName;
    public decimal Balance => _userAccount.Balance;
    public IReadOnlyList<ITransactionModel> Transactions => _transactions;

    internal UserAccountModel(ITransactionService transactionService, IEbankingDbContext dbContext, UserAccount userAccount)
    {
        _userAccount = userAccount;
        _transactionService = transactionService;
        _dbContext = dbContext;
        _transactions = _dbContext.Transactions.All
            .Where(t => t.UserAccountId == _userAccount.Id)
            .Select(t => new TransactionModel(t))
            .ToList();
    }

    public bool TryAlterBalance(decimal amount, TransactionType type, [NotNullWhen(false)] out string? error)
    {
        error = null;
        var sb = new StringBuilder();

        if (!_transactionService.IsAmountValid(amount, out var errorAmount))
            sb.AppendLine(errorAmount);

        decimal tax = 0;
        if (type == TransactionType.Debit)
        {
            tax = Math.Max(
                Math.Round(amount * 0.001m, 2, MidpointRounding.AwayFromZero),
                0.10m);

            if (Balance - amount - tax < 0)
                sb.AppendLine("Insufficient amount");
        }

        if (sb.Length > 0)
        {
            error = sb.ToString();
            return false;
        }

        var key = Guid.NewGuid();
        Transaction? transactionTax = null;
        string? comment;
        int sign;

        if (type == TransactionType.Debit)
        {
            sign = -1;
            transactionTax = new()
            {
                UserAccountId = _userAccount.Id,
                Key = key,
                Type = TransactionType.Debit,
                Amount = tax,
                EventDate = DateTime.Now,
                SystemComment = $"Tax for withdrawing from {Name}({Key})"
            };
            _userAccount.Balance -= tax;

            type = TransactionType.Debit;
            comment = $"Withdraw from {Name}({Key})";
        }
        else
        {
            sign = 1;
            comment = $"Deposit to {Name}({Key})";
        }

        var transaction = new Transaction()
        {
            UserAccountId = _userAccount.Id,
            Key = key,
            Type = type,
            Amount = amount,
            EventDate = DateTime.Now,
            SystemComment = comment ?? throw new UnreachableException()
        };
        _userAccount.Balance += sign * amount;
        _transactions.Add(new TransactionModel(transaction));
        if (transactionTax is not null)
            _transactions.Add(new TransactionModel(transactionTax));

        using (var dbTransaction = _dbContext.StartDbTransaction())
        {
            _dbContext.UserAccounts.Update(_userAccount);
            _dbContext.Transactions.Insert(transaction);
            if (transactionTax is not null)
                _dbContext.Transactions.Insert(transactionTax);

            dbTransaction.Commit();
        }

        return true;
    }
}

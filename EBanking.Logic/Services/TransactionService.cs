using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.Logic.Models;

namespace EBanking.Logic.Services;

public class TransactionService : ITransactionService
{
    private readonly Dictionary<Guid, UserAccountInfo> _keyToUserAccountInfo = new();
    private readonly IEbankingDbContext _dbContext;

    public decimal WithdrawFeeFactor { get; } = 0.001m;
    public decimal WithdrawFeeMinimal { get; } = 0.10m;

    public TransactionService(IEbankingDbContext dbContext) => _dbContext = dbContext;

    public bool IsAmountValid(decimal amount, ICollection<string> errors)
    {
        var startCount = errors.Count;

        if (amount < 0)
            errors.Add("Amount must be a positive number");

        if (amount % 0.01m > 0)
            errors.Add("Amount must be with at most 2 fraction digits");

        return startCount == errors.Count;
    }

    public bool IsDebitValid(
        decimal currentAmount,
        decimal debitAmount,
        out decimal tax,
        [NotNullWhen(false)] out string? error)
    {
        tax = 0;
        error = null;

        if (currentAmount - debitAmount < 0)
        {
            error = "Insufficient amount";
            return false;
        }

        tax = Math.Max(
            Math.Round(currentAmount * WithdrawFeeFactor, 2, MidpointRounding.AwayFromZero),
            WithdrawFeeMinimal);

        if (currentAmount - debitAmount - tax < 0)
        {
            error = "Insufficient amount for the tax";
            return false;
        }

        return true;
    }

    public bool IsKeyExisting(Guid key, [NotNullWhen(false)] out string? error)
    {
        error = null;

        if (key.Equals(Guid.Empty))
        {
            error = "Key was empty";
            return false;
        }

        if (_keyToUserAccountInfo.ContainsKey(key))
            return true;

        if (_dbContext.UserAccounts.All.FirstOrDefault(ua => ua.Key.Equals(key)) is not null)
            return true;

        error = "Account with this Key was not found";
        return false;
    }

    void ITransactionService.GetAllTransactionsFor(
        IUserAccountModel userAccount,
        ICollection<ITransactionModel> transactions,
        UserAccount entityForUpdates)
    {
        foreach (var transaction in _dbContext.Transactions.All
            .Where(t => t.UserAccountId == userAccount.Id))
        {
            transactions.Add(new TransactionModel(userAccount, transaction));
        }

        _keyToUserAccountInfo.Add(userAccount.Key, new UserAccountInfo(userAccount, transactions, entityForUpdates));
    }

    bool ITransactionService.TryAlterBalance(
        IUserAccountModel userAccount,
        decimal amount,
        TransactionType type,
        ICollection<string> errors)
    {
        var startCount = errors.Count;

        IsAmountValid(amount, errors);

        decimal tax = 0;
        if (type == TransactionType.Debit
            && !IsDebitValid(userAccount.Balance, amount, out tax, out var errorTax))
        {
            errors.Add(errorTax);
        }

        if (startCount < errors.Count)
            return false;

        var key = Guid.NewGuid();
        Transaction? transactionTax = null;
        string? comment;
        int sign;

        if (type == TransactionType.Debit)
        {
            sign = -1;
            transactionTax = new()
            {
                UserAccountId = userAccount.Id,
                Key = key,
                Type = TransactionType.Debit,
                Amount = tax,
                EventDate = DateTime.Now,
                SystemComment = $"Tax for withdrawing from {userAccount.Name}({userAccount.Key})"
            };

            type = TransactionType.Debit;
            comment = $"Withdraw from {userAccount.Name}({userAccount.Key})";
        }
        else
        {
            sign = 1;
            comment = $"Deposit to {userAccount.Name}({userAccount.Key})";
        }

        var transaction = new Transaction()
        {
            UserAccountId = userAccount.Id,
            Key = key,
            Type = type,
            Amount = amount,
            EventDate = DateTime.Now,
            SystemComment = comment ?? throw new UnreachableException()
        };

        (var transactions, var entity) = _keyToUserAccountInfo[userAccount.Key];
        entity.Balance += sign * amount - tax;
        transactions.Add(new TransactionModel(userAccount, transaction));
        if (transactionTax is not null)
            transactions.Add(new TransactionModel(userAccount, transactionTax));


        using var dbTransaction = _dbContext.StartDbTransaction();

        _dbContext.UserAccounts.Update(entity);
        _dbContext.Transactions.Insert(transaction);
        if (transactionTax is not null)
            _dbContext.Transactions.Insert(transactionTax);

        dbTransaction.Commit();
        return true;
    }

    bool ITransactionService.TryTransfer(
        IUserAccountModel senderAccount,
        Guid recieverKey,
        decimal amount,
        ICollection<string> errors)
    {
        var startCount = errors.Count;
        IUserAccountModel? recieverAccount = null;
        ICollection<ITransactionModel>? recieverTransactions = null;
        UserAccount? recieverEntity = null;

        if (senderAccount.Key.Equals(recieverKey))
            errors.Add("Please enter a Key of another account");

        else
        {
            if (senderAccount.Balance - amount < 0)
                errors.Add("Insufficient amount");

            if (_keyToUserAccountInfo.TryGetValue(recieverKey, out var info))
                (recieverAccount, recieverTransactions, recieverEntity) = info;

            else
            {
                recieverEntity = _dbContext.UserAccounts.All.FirstOrDefault(ua => ua.Key.Equals(recieverKey));
                if (recieverEntity is null)
                    errors.Add("Account with this Key was not found");
            }
        }

        if (startCount < errors.Count)
            return false;

        var transactionGuid = Guid.NewGuid();
        var systemComment = $"{senderAccount.Name}({senderAccount.Key}) made a transaction to {recieverEntity!.FriendlyName}({recieverEntity.Key})";
        var transactionSender = new Transaction()
        {
            UserAccountId = senderAccount.Id,
            Key = transactionGuid,
            Type = TransactionType.Debit,
            Amount = amount,
            EventDate = DateTime.Now,
            SystemComment = systemComment
        };
        var transactionReciever = new Transaction()
        {
            UserAccountId = recieverEntity.Id,
            Key = transactionGuid,
            Type = TransactionType.Credit,
            Amount = amount,
            EventDate = DateTime.Now,
            SystemComment = systemComment
        };

        (var senderTransactions, var senderEntity) = _keyToUserAccountInfo[senderAccount.Key];

        senderEntity.Balance -= amount;
        recieverEntity.Balance += amount;
        senderTransactions.Add(new TransactionModel(senderAccount, transactionSender));
        recieverTransactions?.Add(new TransactionModel(recieverAccount!, transactionReciever));

        using var dbTransaction = _dbContext.StartDbTransaction();
        _dbContext.UserAccounts.Update(senderEntity);
        _dbContext.UserAccounts.Update(recieverEntity);
        _dbContext.Transactions.Insert(transactionSender);
        _dbContext.Transactions.Insert(transactionReciever);
        dbTransaction.Commit();
        return true;
    }

    private readonly struct UserAccountInfo
    {
        public IUserAccountModel UserAccount { get; }
        public ICollection<ITransactionModel> Transactions { get; }
        public UserAccount Entity { get; }

        public UserAccountInfo(
            IUserAccountModel userAccount, 
            ICollection<ITransactionModel> transactions, 
            UserAccount entity)
        {
            UserAccount = userAccount;
            Transactions = transactions;
            Entity = entity;
        }

        public void Deconstruct(out ICollection<ITransactionModel> transactions, out UserAccount entity)
        {
            transactions = Transactions;
            entity = Entity;
        }

        public void Deconstruct(
            out IUserAccountModel userAccount, 
            out ICollection<ITransactionModel> transactions, 
            out UserAccount entity)
        {
            userAccount = UserAccount;
            transactions = Transactions;
            entity = Entity;
        }
    }
}

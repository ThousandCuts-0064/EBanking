using System.Diagnostics.CodeAnalysis;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.Logic.Services;

namespace EBanking.Logic.Models;

internal class UserModel : IUserModel
{
    private readonly List<IUserAccountModel> _userAccounts;
    private readonly ITransactionService _transactionService;
    private readonly IEbankingDbContext _dbContext;

    int IUserModel.Id => _user.Id;

    private readonly User _user;
    public string Username => _user.Username;
    public string FullName => _user.FullName;
    public string Email => _user.Email;
    public DateTime DateRegistered => _user.DateRegistered;

    public IReadOnlyList<IUserAccountModel> UserAccounts => _userAccounts;

    internal UserModel(ITransactionService transactionService, IEbankingDbContext dbContext, User user)
    {
        _transactionService = transactionService;
        _dbContext = dbContext;
        _user = user;
        _userAccounts = _dbContext.UserAccounts.All
            .Where(ua => ua.UserId == _user.Id)
            .Select<UserAccount, IUserAccountModel>(ua => new UserAccountModel(transactionService, ua))
            .ToList();
    }

    public bool IsNameValid(string name, [NotNullWhen(false)] out string? error)
    {
        error = null;

        if (name is "")
        {
            error = "Name cannot be empty";
            return false;
        }

        if (UserAccounts
            .Select(ua => ua.Name)
            .Contains(name))
        {
            error = "Name is already taken";
            return false;
        }

        return true;
    }

    public bool TryCreateUserAccount(
        string name, 
        [NotNullWhen(true)] out IUserAccountModel? userAccount, 
        [NotNullWhen(false)] out string? error)
    {
        userAccount = null;

        if (!IsNameValid(name, out error))
        {
            return false;
        }

        var entity = new UserAccount()
        {
            FriendlyName = name,
            UserId = _user.Id,
            Key = Guid.NewGuid(),
        };

        var userAccountImpl = new UserAccountModel(_transactionService, entity);
        userAccount = userAccountImpl;
        _userAccounts.Add(userAccountImpl);
        _dbContext.UserAccounts.Insert(entity);
        return true;
    }
}

using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.Logic.Models;

internal class UserModel : IUserModel
{
    private readonly IEbankingDbContext _dbContext;
    private readonly User _user;
    private readonly List<UserAccountModel> _userAccounts;
    public string FullName => _user.FullName;

    public IReadOnlyList<IUserAccountModel> UserAccounts => _userAccounts;

    internal UserModel(IEbankingDbContext dbContext, User user)
    {
        _dbContext = dbContext;
        _user = user;
        _userAccounts = _dbContext.UserAccounts.All
            .Where(ua => ua.Id == _user.Id)
            .Select(ua => new UserAccountModel(dbContext, ua))
            .ToList();
    }
}

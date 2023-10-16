using System.Diagnostics.CodeAnalysis;
using EBanking.Logic.Models;

namespace EBanking.UI.ViewModels;

internal class UserViewModel
{
    private readonly IUserModel _user;

    public string FullName => _user.FullName;

    public IEnumerable<UserAccountViewModel> UserAccounts => 
        _user.UserAccounts.Select(ua => new UserAccountViewModel(ua));

    public UserViewModel(IUserModel userModel) => _user = userModel;

    public bool TryCreateUserAccount(
        string name,
        [NotNullWhen(true)] out IUserAccountModel? userAccount,
        [NotNullWhen(false)] out string? error)
    {
        userAccount = null;
        return _user.IsNameValid(name, out error) 
            && _user.TryCreateUserAccount(name, out userAccount, out error);
    }
}

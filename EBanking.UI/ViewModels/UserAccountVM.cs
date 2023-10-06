using EBanking.Data.Entities;

namespace EBanking.UI.ViewModels;

internal class UserAccountVM
{
    private readonly UserAccount _userAccount;

    public UserAccountVM(UserAccount userAccount)
    {
        _userAccount = userAccount;
    }

    public override string ToString() => _userAccount.FriendlyName;
}

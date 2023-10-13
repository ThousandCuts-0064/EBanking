using EBanking.Data.Entities;

namespace EBanking.UI.ViewModels;

internal class UserAccountVM
{
    internal UserAccount UserAccount { get; }

    public int Id => UserAccount.Id;
    public Guid Key => UserAccount.Key;
    public string FriendlyName => UserAccount.FriendlyName;
    public decimal Balance => UserAccount.Balance;

    public UserAccountVM(UserAccount userAccount) => UserAccount = userAccount;

    public override string ToString() => $"{FriendlyName}: {Balance:0.00}";
}

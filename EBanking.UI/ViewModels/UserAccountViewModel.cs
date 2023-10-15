using EBanking.Data.Entities;
using EBanking.Logic.Models;

namespace EBanking.UI.ViewModels;

internal class UserAccountViewModel
{
    internal IUserAccountModel UserAccount { get; }

    public int Id => UserAccount.Id;
    public Guid Key => UserAccount.Key;
    public string Name => UserAccount.Name;
    public decimal Balance => UserAccount.Balance;

    public UserAccountViewModel(IUserAccountModel userAccount) => UserAccount = userAccount;

    public override string ToString() => $"{Name}: {Balance:0.00}";
}

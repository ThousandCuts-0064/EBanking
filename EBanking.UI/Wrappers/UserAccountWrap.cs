using EBanking.Data.Entities;

namespace EBanking.UI.Wrappers;

internal class UserAccountWrap
{
    internal UserAccount UserAccount { get; }

    public string Name => UserAccount.FriendlyName;
    public Guid Guid => UserAccount.Key;
    public decimal Balance => UserAccount.Balance;
    public int Id => UserAccount.Id;

    public UserAccountWrap(UserAccount userAccount)
    {
        UserAccount = userAccount;
    }

    public override string ToString() => $"{Name}: {Balance}";
}

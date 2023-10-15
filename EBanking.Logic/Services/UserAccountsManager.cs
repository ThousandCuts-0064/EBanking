using System.Diagnostics.CodeAnalysis;
using EBanking.Logic.Models;

namespace EBanking.Logic.Services;

internal class UserAccountsManager : IUserAccountsManager
{
    private readonly Dictionary<Guid, IUserAccountModel> _keyToUseAccount = new();

    void IUserAccountsManager.Add(IUserAccountModel userAccount) => 
        _keyToUseAccount.Add(userAccount.Key, userAccount);

    bool IUserAccountsManager.TryGet(Guid key, [NotNullWhen(true)] out IUserAccountModel? userAccount) => 
        _keyToUseAccount.TryGetValue(key, out userAccount);
}

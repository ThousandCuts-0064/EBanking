using System.Diagnostics.CodeAnalysis;
using EBanking.Logic.Models;

namespace EBanking.Logic.Services;

internal interface IUserAccountsManager
{
    internal void Add(IUserAccountModel userAccount);
    internal bool TryGet(Guid key, [NotNullWhen(true)] out IUserAccountModel? userAccount);
}

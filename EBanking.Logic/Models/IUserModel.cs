using System.Diagnostics.CodeAnalysis;

namespace EBanking.Logic.Models;

public interface IUserModel
{
    internal int Id { get; }

    public IReadOnlyList<IUserAccountModel> UserAccounts { get; }
    public string Username { get; }
    public string FullName { get; }
    public string Email { get; }
    public DateTime DateRegistered { get; }

    public bool IsNameValid(string name, [NotNullWhen(false)] out string? error);

    public bool TryCreateUserAccount(
        string name, 
        [NotNullWhen(true)] out IUserAccountModel? userAccount,
        [NotNullWhen(false)] out string? error);
}

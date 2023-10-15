using System.Diagnostics.CodeAnalysis;
using EBanking.Logic.Models;

namespace EBanking.Logic.Services;

public interface IAuthenticator
{
    public bool IsStrictEmailValidation { get; set; }

    public bool IsUsernameValid(string username, [NotNullWhen(false)] out string? error);
    public bool IsPasswordValid(string password, [NotNullWhen(false)] out string? error);
    public bool IsEmailValid(string email, [NotNullWhen(false)] out string? error);

    public bool TryRegister(
        string username,
        string password,
        string name,
        string email,
        [NotNullWhen(true)] out IUserModel? user,
        [NotNullWhen(false)] out string? error);

    public bool TryLogin(
        string username,
        string password,
        [NotNullWhen(true)] out IUserModel? user);
}

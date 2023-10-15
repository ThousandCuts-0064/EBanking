using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.Logic.Models;

namespace EBanking.Logic.Services;

internal partial class Authenticator : IAuthenticator
{
    private readonly IEbankingDbContext _dbContext;
    public bool IsStrictEmailValidation { get; set; } = true;

    public Authenticator(IEbankingDbContext dbContext) => _dbContext = dbContext;

    public bool IsUsernameValid(string username, [NotNullWhen(false)] out string? error)
    {
        error = null;
        var sb = new StringBuilder();

        if (username.Length is < 4 or > 16)
            sb.AppendLine("Username must contain between 4 and 16 symbols");

        foreach (var symbol in username)
            if (char.IsAsciiLetterOrDigit(symbol))
            {
                sb.AppendLine("Username can only contain symbols: a-z A-Z 0-9");
                break;
            }

        if (_dbContext.Users.All
            .Select(u => u.Username)
            .Contains(username))
        {
            sb.AppendLine("Username is already taken");
        }

        if (sb.Length == 0)
            return true;

        error = sb.ToString();
        return false;
    }

    public bool IsPasswordValid(string password, [NotNullWhen(false)] out string? error)
    {
        error = null;
        var sb = new StringBuilder();

        var hasLetter = false;
        var hasDigit = false;
        foreach (var symbol in password)
        {
            if (char.IsDigit(symbol))
                hasDigit = true;

            else if (char.IsLetter(symbol))
                hasLetter = true;
        }

        if (!hasLetter)
            sb.AppendLine("Password must contain at least 1 letter");

        if (!hasDigit)
            sb.AppendLine("Password must contain at least 1 digit");

        if (password.Length < 8)
            sb.AppendLine("Password must be at least 8 symbols");

        if (sb.Length == 0)
            return true;

        error = sb.ToString();
        return false;
    }

    public bool IsEmailValid(string email, [NotNullWhen(false)] out string? error)
    {
        error = null;

        if (IsStrictEmailValidation)
        {
            if (RegexEmailValidation().IsMatch(email))
                return true;

            error = "Invalid email format";
            return false;
        }
        else
        {
            if (MailAddress.TryCreate(email, out _))
                return true;

            error = "Invalid email format";
            return false;
        }
    }

    public bool TryRegister(
        string username,
        string password,
        string fullName,
        string email,
        [NotNullWhen(true)] out IUserModel? user,
        [NotNullWhen(false)] out string? error)
    {
        user = null;
        error = null;
        var sb = new StringBuilder();

        if (!IsUsernameValid(username, out var errorUsername))
            sb.AppendLine(errorUsername);

        if (!IsPasswordValid(password, out var errorPassword))
            sb.AppendLine(errorPassword);

        if (!IsEmailValid(email, out var errorEmail))
            sb.AppendLine(errorEmail);

        if (sb.Length > 0)
        {
            error = sb.ToString();
            return false;
        }

        var userEntity = new User()
        {
            Username = username,
            Password = Encryption.SHA512(password),
            FullName = fullName,
            Email = email,
            DateRegistered = DateTime.UtcNow,
        };
        user = new UserModel(_dbContext, userEntity);
        _dbContext.Users.Insert(userEntity);
        return true;
    }

    public bool TryLogin(
        string username,
        string password,
        [NotNullWhen(true)] out IUserModel? user)
    {
        user = null;
        password = Encryption.SHA512(password);

        var userEntity = _dbContext.Users.All
            .FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

        if (userEntity is null)
            return false;

        user = new UserModel(_dbContext, userEntity);
        return true;
    }

    [GeneratedRegex("^(?=.{1,256}$)(?=.{1,64}@.{1,255}$)(?=.{1,253}\\..{1,253}$)(?=.{1,64}@.{1,64}@.{1,255}$)^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@([a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$\r\n")]
    private static partial Regex RegexEmailValidation();
}

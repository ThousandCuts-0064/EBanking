using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using System.Text.RegularExpressions;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.Logic.Models;

namespace EBanking.Logic.Services;

public partial class Authenticator : IAuthenticator
{
    private readonly IEncryptionService _encryptionService;
    private readonly ITransactionService _transactionService;
    private readonly IEbankingDbContext _dbContext;
    public bool IsStrictEmailValidation { get; set; }

    public Authenticator(
        IEncryptionService encryptionService, 
        ITransactionService transactionService, 
        IEbankingDbContext dbContext,
        bool isStrictEmailValidation = true)
    {
        _encryptionService = encryptionService;
        _transactionService = transactionService;
        _dbContext = dbContext;
        IsStrictEmailValidation = isStrictEmailValidation;
    }

    public bool IsUsernameValid(string username, ICollection<string> errors)
    {
        var startCount = errors.Count;

        if (username.Length is < 4 or > 16)
            errors.Add("Username must contain between 4 and 16 symbols");

        foreach (var symbol in username)
            if (!char.IsAsciiLetterOrDigit(symbol))
            {
                errors.Add("Username can only contain symbols: a-z A-Z 0-9");
                break;
            }

        if (_dbContext.Users.All
            .Select(u => u.Username)
            .Contains(username))
        {
            errors.Add("Username is already taken");
        }

        return startCount == errors.Count;
    }

    public bool IsPasswordValid(string password, ICollection<string> errors)
    {
        var startCount = errors.Count;

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
            errors.Add("Password must contain at least 1 letter");

        if (!hasDigit)
            errors.Add("Password must contain at least 1 digit");

        if (password.Length < 8)
            errors.Add("Password must be at least 8 symbols");

        return startCount == errors.Count;
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
        ICollection<string> errors)
    {
        user = null;
        var startCount = errors.Count;

        IsUsernameValid(username, errors);
        IsPasswordValid(password, errors);
        if (!IsEmailValid(email, out var errorEmail))
            errors.Add(errorEmail);

        if (startCount < errors.Count)
            return false;

        password = _encryptionService
            .Encrypt(password, out var hash, out var salt)
            .Compose(hash, salt);

        var userEntity = new User()
        {
            Username = username,
            Password = password,
            FullName = fullName,
            Email = email,
            DateRegistered = DateTime.UtcNow,
        };
        user = new UserModel(_transactionService, _dbContext, userEntity);
        _dbContext.Users.Insert(userEntity);
        return true;
    }

    public bool TryLogin(
        string username,
        string password,
        [NotNullWhen(true)] out IUserModel? user,
        [NotNullWhen(false)] out string? error)
    {
        user = null;
        error = null;

        var userEntity = _dbContext.Users.All
            .FirstOrDefault(u => u.Username.Equals(username));

        if (userEntity is null
            || !_encryptionService
                .Decompose(userEntity.Password, out var hash, out var salt)
                .Verify(password, hash, salt))
        {
            error = "No Username and Password match was found";
            return false;
        }

        user = new UserModel(_transactionService, _dbContext, userEntity);
        return true;
    }

    [GeneratedRegex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
    private static partial Regex RegexEmailValidation();
}

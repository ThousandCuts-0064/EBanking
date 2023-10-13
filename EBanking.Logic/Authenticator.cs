using System.Net.Mail;
using System.Text;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.Logic;

public class Authenticator
{
    private readonly IEbankingDbContext _dbContext;
    private readonly StringBuilder _stringBuilder = new();

    public Authenticator(IEbankingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool TryRegister(string username, string password, string name, string email, out string error)
    {
        _stringBuilder.Clear();

        if (username.Length is < 4 or > 16)
            _stringBuilder.AppendLine("Username must contain between 4 and 16 symbols");

        foreach (var symbol in username)
            if (symbol is (< 'a' or > 'z') and (< 'A' or > 'Z') and (< '0' or > '9'))
            {
                _stringBuilder.AppendLine("Username can only contain symbols: a-z A-Z 0-9");
                break;
            }

        if (_dbContext.Users.All
            .Select(u => u.Username)
            .Contains(username))
        {
            _stringBuilder.AppendLine("Username is already taken");
        }

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
            _stringBuilder.AppendLine("Password must contain at least 1 letter");

        if (!hasDigit)
            _stringBuilder.AppendLine("Password must contain at least 1 digit");

        if (password.Length < 8)
            _stringBuilder.AppendLine("Password must be at least 8 symbols");

        if (!MailAddress.TryCreate(email, out _))
            _stringBuilder.AppendLine("Invalid email format");

        var user = new User()
        {
            Username = username,
            Password = password,
            FullName = name,
            Email = email,
        };

        error = _stringBuilder.ToString();
        return error is not "";
    }

    public bool IsLoginMatch(string username, string password)
    {
        var user = _dbContext.Users.All
            .FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

        return user is not null;
    }
}

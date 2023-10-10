using System.Net.Mail;
using System.Text;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI.Forms;

public partial class Register : App.Form
{
    private readonly IEbankingDbContext _dbContext;

    public Register(IEbankingDbContext dbContext)
    {
        InitializeComponent();
        _dbContext = dbContext;
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new();

        User user = new()
        {
            Username = _tbUsername.Text,
            Password = Encryption.SHA512(_tbPassword.Text),
            FullName = _tbName.Text,
            Email = _tbEmail.Text,
            DateRegistered = DateTime.Now,
        };

        if (user.Username.Length is < 4 or > 16)
            sb.AppendLine("Username must contain between 4 and 16 symbols");

        foreach (var symbol in user.Username)
            if (symbol is (< 'a' or > 'z') and (< 'A' or > 'Z') and (< '0' or > '9'))
            {
                sb.AppendLine("Username can only contain symbols: a-z A-Z 0-9");
                break;
            }

        if (_tbPassword.Text != _tbRepeatPassword.Text)
            sb.AppendLine("The repeat password is different");

        if (_dbContext.Users.All.Contains(user, Comparers.UserRegister))
            sb.AppendLine("Username is already taken");

        bool hasLetter = false;
        bool hasDigit = false;
        foreach (var symbol in _tbPassword.Text)
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

        if (_tbPassword.Text.Length < 8)
            sb.AppendLine("Password must be at least 8 symbols");

        if (!MailAddress.TryCreate(user.Email, out _))
            sb.AppendLine("Invalid email format");

        string error = sb.ToString();

        if (error is "")
        {
            _dbContext.Users.Insert(user);
            new UserForm(_dbContext, user).Show();
            Close();
        }
        else
            MessageBox.Show(error, "Invalid register", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
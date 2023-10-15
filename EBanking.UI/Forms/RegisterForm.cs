using System.Net.Mail;
using System.Text;
using EBanking.Logic.Models;
using EBanking.Logic.Services;

namespace EBanking.UI.Forms;

public partial class RegisterForm : Form
{
    private readonly IAuthenticator _authenticator;
    public IUserModel? AuthenticatedUser { get; private set; }

    public RegisterForm(IAuthenticator authenticator)
    {
        InitializeComponent();
        _authenticator = authenticator;
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();

        if (!_authenticator.IsUsernameValid(_tbUsername.Text, out var errorUsername))
            sb.AppendLine(errorUsername);

        if (!_tbPassword.Text.Equals(_tbRepeatPassword.Text))
            sb.AppendLine("Repeat password mismatch");

        if (!_authenticator.IsPasswordValid(_tbPassword.Text, out var errorPassword))
            sb.AppendLine(errorPassword);

        if (!_authenticator.IsEmailValid(_tbEmail.Text, out var errorEmail))
            sb.AppendLine(errorEmail);

        if (sb.Length == 0)
        {
            if (_authenticator.TryRegister(
                _tbUsername.Text,
                _tbPassword.Text,
                _tbFullName.Text,
                _tbEmail.Text,
                out var user,
                out var errorRegister))
            {
                AuthenticatedUser = user;
                Close();
                return;
            }

            sb.AppendLine(errorRegister);
        }

        MessageBox.Show(sb.ToString(), "Invalid register", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
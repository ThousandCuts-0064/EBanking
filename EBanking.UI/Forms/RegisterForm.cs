using EBanking.Logic.Services;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

internal partial class RegisterForm : Form
{
    private readonly IAuthenticator _authenticator;
    public UserViewModel? AuthenticatedUser { get; private set; }

    public RegisterForm(IAuthenticator authenticator)
    {
        InitializeComponent();
        _authenticator = authenticator;
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        var errors = new List<string>();

        _authenticator.IsUsernameValid(_tbUsername.Text, errors);

        if (!_tbPassword.Text.Equals(_tbRepeatPassword.Text))
            errors.Add("Repeat password mismatch");

        _authenticator.IsPasswordValid(_tbPassword.Text, errors);

        if (!_authenticator.IsEmailValid(_tbEmail.Text, out var errorEmail))
            errors.Add(errorEmail);

        if (errors.Count == 0
            && _authenticator.TryRegister(
                _tbUsername.Text,
                _tbPassword.Text,
                _tbFullName.Text,
                _tbEmail.Text,
                out var user,
                errors))
        {
            AuthenticatedUser = new UserViewModel(user);
            Close();
            return;
        }

        MessageBox.Show(
            string.Join(Environment.NewLine, errors), 
            "Invalid register", 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
    }
}
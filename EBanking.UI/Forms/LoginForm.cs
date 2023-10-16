using EBanking.Logic.Services;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

internal partial class LoginForm : Form
{
    private readonly IAuthenticator _authenticator;
    public UserViewModel? AuthenticatedUser { get; private set; }
    public bool DoOpenRegister { get; private set; }

    public LoginForm(IAuthenticator authenticator)
    {
        InitializeComponent();
        _authenticator = authenticator;
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        DoOpenRegister = true;
        Close();
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        if (_authenticator.TryLogin(_tbUsername.Text, _tbPassword.Text, out var user, out var error))
        {
            AuthenticatedUser = new UserViewModel(user);
            Close();
            return;
        }

        MessageBox.Show(
            error,
            "Invalid login",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}

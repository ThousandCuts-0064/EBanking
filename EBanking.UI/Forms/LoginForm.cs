using EBanking.Logic.Models;
using EBanking.Logic.Services;

namespace EBanking.UI.Forms;

public partial class LoginForm : Form
{
    private readonly IAuthenticator _authenticator;
    public IUserModel? AuthenticatedUser { get; private set; }
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
        if (_authenticator.TryLogin(_tbUsername.Text, _tbPassword.Text, out var user))
        {
            AuthenticatedUser = user;
            Close();
            return;
        }

        MessageBox.Show(
            "No Username and Password match found",
            "Invalid login",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}

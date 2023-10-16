using EBanking.Logic.Models;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

internal partial class CreateAccount : Form
{
    private readonly UserViewModel _user;

    public event Action<IUserAccountModel>? UserAccountCreated;

    public CreateAccount(UserViewModel user)
    {
        InitializeComponent();
        _user = user;
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
        if (_tbName.Text is "")
        {
            MessageBox.Show(
                "Account name cannot be empty!",
                "Invalid name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        if (_user.TryCreateUserAccount(_tbName.Text, out var userAccount, out var errorName))
        {
            Close();
            UserAccountCreated?.Invoke(userAccount);
            return;
        }

        MessageBox.Show(
            errorName,
            "Invalid name",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}

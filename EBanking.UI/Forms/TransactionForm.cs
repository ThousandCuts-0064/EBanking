using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

internal partial class TransactionForm : Form
{
    private readonly UserAccountViewModel[] _userAccountViewModels;
    private readonly UserViewModel _user;

    public TransactionForm(UserViewModel user)
    {
        InitializeComponent();
        _user = user;
        _userAccountViewModels = _user.UserAccounts.ToArray();
        _lbxAccounts.Items.AddRange(_userAccountViewModels);
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        if (_lbxAccounts.SelectedIndex == -1)
        {
            MessageBox.Show(
                "Please select an account form the list",
                "Account not selected!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        if (!decimal.TryParse(_tbAmount.Text, out var amount))
        {
            MessageBox.Show(
                "Amount is not a valid number",
                "Invalid Amount!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        if (!Guid.TryParse(_tbKey.Text, out var recieverKey))
        {
            MessageBox.Show(
                "Key is not in a valid format",
                "Invalid Key!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var errors = new List<string>();
        if (_userAccountViewModels[_lbxAccounts.SelectedIndex]
            .TryTransfer(recieverKey, amount, errors))
        {
            Close();
            return;
        }

        MessageBox.Show(
            string.Join(Environment.NewLine, errors),
            "Invalid Transaction!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}

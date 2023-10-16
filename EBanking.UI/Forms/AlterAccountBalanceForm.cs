using System.ComponentModel;
using System.Diagnostics;
using EBanking.Data.Entities;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

internal partial class AlterAccountBalanceForm : Form
{
    private readonly UserAccountViewModel[] _userAccountViewModels;
    private readonly UserViewModel _user;
    private readonly TransactionType _type;

    public AlterAccountBalanceForm(UserViewModel user, TransactionType type)
    {
        InitializeComponent();
        _user = user;
        _type = Enum.IsDefined(type)
            ? type
            : throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(TransactionType));

        Text = _type switch
        {
            TransactionType.Debit => "Withdraw",
            TransactionType.Credit => "Deposit",
            _ => throw new UnreachableException(),
        };

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

        var errors = new List<string>();
        if (_userAccountViewModels[_lbxAccounts.SelectedIndex]
            .TryAlterBalance(amount, _type, errors))
        {
            Close();
            return;
        }

        MessageBox.Show(
            string.Join(Environment.NewLine, errors),
            $"Invalid {Text}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
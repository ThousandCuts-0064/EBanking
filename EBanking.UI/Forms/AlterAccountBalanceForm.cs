using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using EBanking.Data.Entities;
using EBanking.Logic.Models;
using EBanking.Logic.Services;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

public partial class AlterAccountBalanceForm : Form
{
    private readonly UserAccountViewModel[] _userAccountViewModels;
    private readonly ITransactionService _transactionService;
    private readonly IUserModel _user;
    private readonly TransactionType _transactionType;

    public AlterAccountBalanceForm(ITransactionService transactionService, IUserModel user, TransactionType transactionType)
    {
        InitializeComponent();
        _transactionService = transactionService;
        _user = user;
        _transactionType = Enum.IsDefined(transactionType)
            ? transactionType
            : throw new InvalidEnumArgumentException(nameof(transactionType), (int)transactionType, typeof(TransactionType));

        Text = _transactionType switch
        {
            TransactionType.Debit => "Withdraw",
            TransactionType.Credit => "Deposit",
            _ => throw new UnreachableException(),
        };

        _userAccountViewModels = _user.UserAccounts
            .Select(ua => new UserAccountViewModel(ua))
            .ToArray();

        _lbxAccounts.Items.AddRange(_userAccountViewModels);
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();

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
            sb.AppendLine("Amount is not a valid number");

        else if (_transactionService.IsAmountValid(amount, out var errorAmount))
            sb.AppendLine(errorAmount);


        if (sb.Length == 0)
        {
            if (_userAccountViewModels[_lbxAccounts.SelectedIndex].UserAccount
                .TryAlterBalance(amount, _transactionType, out var errorAlter))
            {
                Close();
                return;
            }

            sb.AppendLine(errorAlter);
        }

        MessageBox.Show(
            sb.ToString(),
            $"Invalid {Text}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
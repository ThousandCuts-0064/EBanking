using System.ComponentModel;
using System.Data;
using System.Text;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.Wrappers;

namespace EBanking.UI.Forms;

public partial class UpdateAccount : Form
{
    private readonly UserAccountWrap[] _userAccountWrappers;
    private readonly IEbankingDbContext _dbContext;
    private readonly User _user;
    private readonly UpdateAccountOption _option;

    public UpdateAccount(IEbankingDbContext dbContext, User user, UpdateAccountOption option)
    {
        InitializeComponent();
        _dbContext = dbContext;
        _user = user;
        _option = Enum.IsDefined(option)
            ? option
            : throw new InvalidEnumArgumentException(nameof(option), (int)option, typeof(UpdateAccountOption));
        Text = $"{_user.FullName}: {_option}";
        _userAccountWrappers = _dbContext.UserAccounts.All
            .Where(uc => uc.UserId == _user.Id)
            .Select(uc => new UserAccountWrap(uc))
            .ToArray();
        _lbxAccounts.Items.AddRange(_userAccountWrappers);
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new();
        UserAccountWrap? userAccountVM = null;
        int sign = 1;

        if (_lbxAccounts.SelectedIndex == -1)
            sb.AppendLine("Please select an account form the list");
        else
            userAccountVM = _userAccountWrappers[_lbxAccounts.SelectedIndex];

        if (!decimal.TryParse(_tbAmount.Text, out decimal amount)
           || amount < 0
           || amount % 0.01m > 0)
        {
            sb.AppendLine("Amount must be a positive number with at most 2 fraction digits");
        }

        if (_option == UpdateAccountOption.Withdraw
            && userAccountVM is not null)
        {
            sign = -1;
            if (userAccountVM.Balance - amount < 0)
                sb.AppendLine("Insufficient amount");
        }

        string error = sb.ToString();

        if (error is "")
        {
            userAccountVM!.UserAccount.Balance += sign * amount;
            _dbContext.UserAccounts.Update(userAccountVM.UserAccount);
            Close();
        }
        else
        {
            MessageBox.Show(
                error,
                $"Invalid {_option}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
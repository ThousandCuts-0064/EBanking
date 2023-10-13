using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using EBanking.Data.Core;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

public partial class UpdateAccount : Form
{
    private readonly UserAccountVM[] _userAccountVMs;
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
        Text = _option.ToString();
        _userAccountVMs = _dbContext.UserAccounts.All
            .Where(ua => ua.UserId == _user.Id)
            .Select(ua => new UserAccountVM(ua))
            .ToArray();
        _lbxAccounts.Items.AddRange(_userAccountVMs);
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        UserAccountVM? userAccountVM = null;
        Transaction? transactionTax = null;
        TransactionType type = 0;
        var key = Guid.Empty;
        string? comment = null;
        var sign = 0;

        if (_lbxAccounts.SelectedIndex == -1)
            sb.AppendLine("Please select an account form the list");
        else
            userAccountVM = _userAccountVMs[_lbxAccounts.SelectedIndex];

        if (!decimal.TryParse(_tbAmount.Text, out var amount)
           || amount < 0
           || amount % 0.01m > 0)
        {
            sb.AppendLine("Amount must be a positive number with at most 2 fraction digits");
        }

        if (userAccountVM is not null)
        {
            if (_option == UpdateAccountOption.Withdraw)
            {
                sign = -1;
                var tax = Math.Max(
                    Math.Round(amount * 0.001m, 2, MidpointRounding.AwayFromZero),
                    0.10m);
                if (userAccountVM.Balance - amount - tax < 0)
                    sb.AppendLine("Insufficient amount");

                key = Guid.NewGuid();
                transactionTax = new()
                {
                    UserAccountId = userAccountVM!.Id,
                    Key = key,
                    Type = TransactionType.Debit,
                    Amount = tax,
                    EventDate = DateTime.Now,
                    SystemComment = $"Tax for withdrawing from {userAccountVM.FriendlyName}({userAccountVM.Key})"
                };
                userAccountVM.UserAccount.Balance -= tax;

                type = TransactionType.Debit;
                comment = $"Withdraw from {userAccountVM.FriendlyName}({userAccountVM.Key})";
            }
            else
            {
                sign = 1;
                type = TransactionType.Credit;
                comment = $"Deposit to {userAccountVM.FriendlyName}({userAccountVM.Key})";
            }
        }

        var error = sb.ToString();

        if (error is "")
        {
            var transaction = new Transaction()
            {
                UserAccountId = userAccountVM!.Id,
                Key = key.Equals(Guid.Empty) ? Guid.NewGuid() : key,
                Type = type,
                Amount = amount,
                EventDate = DateTime.Now,
                SystemComment = comment ?? throw new UnreachableException()
            };
            userAccountVM.UserAccount.Balance += sign * amount;
            using (var dbTransaction = _dbContext.StartDbTransaction())
            {
                _dbContext.UserAccounts.Update(userAccountVM.UserAccount);
                _dbContext.Transactions.Insert(transaction);
                if (transactionTax is not null)
                    _dbContext.Transactions.Insert(transactionTax);
                dbTransaction.Commit();
            }
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
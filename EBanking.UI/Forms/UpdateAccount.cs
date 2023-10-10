using System.ComponentModel;
using System.Text;
using EBanking.Data.Core;
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
        Text = _option.ToString();
        _userAccountWrappers = _dbContext.UserAccounts.All
            .Where(ua => ua.UserId == _user.Id)
            .Select(ua => new UserAccountWrap(ua))
            .ToArray();
        _lbxAccounts.Items.AddRange(_userAccountWrappers);
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new();
        UserAccountWrap? userAccountVM = null;
        Transaction? transactionTax = null;
        TransactionType type = 0;
        Guid guid = Guid.Empty;
        string comment = null!;
        int sign = 0;

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

        if (userAccountVM is not null)
        {
            if (_option == UpdateAccountOption.Withdraw)
            {
                sign = -1;
                decimal tax = Math.Max(amount * 0.001m, 0.10m);
                if (userAccountVM.Balance - amount - tax < 0)
                    sb.AppendLine("Insufficient amount");

                guid = Guid.NewGuid();
                transactionTax = new()
                {
                    UserAccountId = userAccountVM!.Id,
                    Key = guid,
                    Type = TransactionType.Credit,
                    Amount = tax,
                    EventDate = DateTime.Now,
                    SystemComment = $"Tax for withdrawing from {userAccountVM.Name}({userAccountVM.Guid})"
                };
                userAccountVM!.UserAccount.Balance -= tax;

                type = TransactionType.Credit;
                comment = $"Withdraw from {userAccountVM.Name}({userAccountVM.Guid})";
            }
            else
            {
                sign = 1;
                type = TransactionType.Debit;
                comment = $"Deposit to {userAccountVM.Name}({userAccountVM.Guid})";
            }
        }

        string error = sb.ToString();

        if (error is "")
        {
            Transaction transaction = new()
            {
                UserAccountId = userAccountVM!.Id,
                Key = guid.Equals(Guid.Empty) ? Guid.NewGuid() : guid,
                Type = type,
                Amount = amount,
                EventDate = DateTime.Now,
                SystemComment = comment
            };
            userAccountVM!.UserAccount.Balance += sign * amount;
            using (DbTransaction dbTransaction = _dbContext.StartDbTransaction())
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
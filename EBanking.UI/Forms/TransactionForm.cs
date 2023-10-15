using System.Text;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

public partial class TransactionForm : Form
{
    private readonly UserAccountViewModel[] _userAccountViewModels;
    private readonly IEbankingDbContext _dbContext;
    private readonly User _user;

    public TransactionForm(IEbankingDbContext dbContext, User user)
    {
        InitializeComponent();
        _dbContext = dbContext;
        _user = user;
        _userAccountViewModels = _dbContext.UserAccounts.All
            .Where(ua => ua.UserId == _user.Id)
            .Select(ua => new UserAccountViewModel(ua))
            .ToArray();
        _lbxAccounts.Items.AddRange(_userAccountViewModels);
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        UserAccountViewModel? thisUserAccountVM = null;

        if (_lbxAccounts.SelectedIndex == -1)
            sb.AppendLine("Please select an account form the list");
        else
            thisUserAccountVM = _userAccountViewModels[_lbxAccounts.SelectedIndex];

        if (_tbKey.Text is "")
            sb.AppendLine("Please enter the Guid of the other account");

        if (_tbAmount.Text is "")
            sb.AppendLine("Please enter the amount for the transaction");

        if (!decimal.TryParse(_tbAmount.Text, out var amount)
            || amount < 0
            || amount % 0.01m > 0)
        {
            sb.AppendLine("Amount must be a positive number with at most 2 fraction digits");
        }


        UserAccount? otherUserAccount = null;

        if (!Guid.TryParse(_tbKey.Text, out var guid))
            sb.AppendLine("Invalid Guid");

        else if (guid.Equals(thisUserAccountVM?.Key))
            sb.AppendLine("Please enter a Guid of another account");

        else
        {
            if (thisUserAccountVM?.Balance - amount < 0)
                sb.AppendLine("Insufficient amount");

            otherUserAccount = _dbContext.UserAccounts.All.FirstOrDefault(ua => ua.Key.Equals(guid));
            if (otherUserAccount is null)
                sb.AppendLine("Account with this Guid was not found");
        }

        var error = sb.ToString();
        if (error is "")
        {
            var transactionGuid = Guid.NewGuid();
            var systemComment = $"{thisUserAccountVM!.Name}({thisUserAccountVM.Key}) made a transaction to {otherUserAccount!.FriendlyName}({otherUserAccount.Key})";
            var transactionSender = new Transaction()
            {
                UserAccountId = thisUserAccountVM.Id,
                Key = transactionGuid,
                Type = TransactionType.Debit,
                Amount = amount,
                EventDate = DateTime.Now,
                SystemComment = systemComment
            };
            var transactionReciever = new Transaction()
            {
                UserAccountId = otherUserAccount.Id,
                Key = transactionGuid,
                Type = TransactionType.Credit,
                Amount = amount,
                EventDate = DateTime.Now,
                SystemComment = systemComment
            };
            thisUserAccountVM.UserAccount.Balance -= amount;
            otherUserAccount.Balance += amount;
            using (var dbTransaction = _dbContext.StartDbTransaction())
            {
                _dbContext.UserAccounts.Update(thisUserAccountVM.UserAccount);
                _dbContext.UserAccounts.Update(otherUserAccount);
                _dbContext.Transactions.Insert(transactionSender);
                _dbContext.Transactions.Insert(transactionReciever);
                dbTransaction.Commit();
            }
            Close();
        }
        else
        {
            MessageBox.Show(
                error,
                "Invalid Transaction!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}

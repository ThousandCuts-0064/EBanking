using System.Text;
using EBanking.Data.Core;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.Wrappers;

namespace EBanking.UI.Forms;
public partial class MakeTransaction : Form
{
    private readonly UserAccountWrap[] _userAccountWrappers;
    private readonly IEbankingDbContext _dbContext;
    private readonly User _user;

    public MakeTransaction(IEbankingDbContext dbContext, User user)
    {
        InitializeComponent();
        _dbContext = dbContext;
        _user = user;
        Text = $"{_user.FullName}: Transaction";
        _userAccountWrappers = _dbContext.UserAccounts.All
            .Where(uc => uc.UserId == _user.Id)
            .Select(uc => new UserAccountWrap(uc))
            .ToArray();
        _lbxAccounts.Items.AddRange(_userAccountWrappers);
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new();
        UserAccountWrap? thisUserAccountVM = null;

        if (_lbxAccounts.SelectedIndex == -1)
            sb.AppendLine("Please select an account form the list");
        else
            thisUserAccountVM = _userAccountWrappers[_lbxAccounts.SelectedIndex];

        if (_tbKey.Text is "")
            sb.AppendLine("Please enter the Guid of the other account");

        if (_tbAmount.Text is "")
            sb.AppendLine("Please enter the amount for the transaction");

        if (!decimal.TryParse(_tbAmount.Text, out decimal amount)
            || amount < 0
            || amount % 0.01m > 0)
        {
            sb.AppendLine("Amount must be a positive number with at most 2 fraction digits");
        }


        UserAccount? otherUserAccount = null;

        if (!Guid.TryParse(_tbKey.Text, out Guid guid))
            sb.AppendLine("Invalid Guid");

        else if (!guid.Equals(thisUserAccountVM?.Guid))
            sb.AppendLine("Please enter a Guid of another account");

        else
        {
            if (thisUserAccountVM.Balance - amount < 0)
                sb.AppendLine("Insufficient amount");

            otherUserAccount = _dbContext.UserAccounts.All.FirstOrDefault(uc => uc.Key.Equals(guid));
            if (otherUserAccount is null)
                sb.AppendLine("Account with this Guid was not found");
        }


        string error = sb.ToString();
        if (error is "")
        {
            Guid transactionGuid = Guid.NewGuid();
            string systemComment = $"{thisUserAccountVM!.Name}({thisUserAccountVM.Guid}) sent {amount} to {otherUserAccount!.FriendlyName}({otherUserAccount.Key})";
            Transaction transactionSender = new()
            {
                UserAccountId = thisUserAccountVM.Id,
                Key = transactionGuid,
                Type = TransactionType.Credit,
                Amount = amount,
                EventDate = DateTime.Now,
                SystemComment = systemComment
            };
            Transaction transactionReciever = new()
            {
                UserAccountId = otherUserAccount.Id,
                Key = transactionGuid,
                Type = TransactionType.Debit,
                Amount = amount,
                EventDate = DateTime.Now,
                SystemComment = systemComment
            };
            thisUserAccountVM.UserAccount.Balance -= amount;
            otherUserAccount.Balance += amount;
            using (DbTransaction dbTransaction = _dbContext.StartDbTransaction())
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

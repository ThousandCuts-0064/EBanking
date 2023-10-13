using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI.Forms;
public partial class UserForm : Form
{
    private readonly IEbankingDbContext _dbContext;
    private readonly User _user;

    public UserForm(IEbankingDbContext dbContext, User user)
    {
        InitializeComponent();
        _user = user;
        _dbContext = dbContext;
        Text = _user.FullName;
        //LoadAccounts();
    }

    private void BtnDeposit_Click(object sender, EventArgs e)
    {
        new UpdateAccount(_dbContext, _user, UpdateAccountOption.Deposit).ShowDialog();
        LoadAccounts();
    }

    private void BtnWithdraw_Click(object sender, EventArgs e)
    {
        new UpdateAccount(_dbContext, _user, UpdateAccountOption.Withdraw).ShowDialog();
        LoadAccounts();
    }

    private void BtnMakeTransaction_Click(object sender, EventArgs e)
    {
        new TransactionForm(_dbContext, _user).ShowDialog();
        LoadAccounts();
    }

    private void BtnTransactionHistory_Click(object sender, EventArgs e)
    {
        new TransactionHistory(_dbContext, _user).ShowDialog();
    }

    private void BtnCreateAccount_Click(object sender, EventArgs e)
    {
        var createAccount = new CreateAccount(_dbContext, _user.Id);
        createAccount.UserAccountCreated += _ => LoadAccounts();
        createAccount.ShowDialog();
    }

    private void LoadAccounts() => _dgvAccounts.DataSource =
        _dbContext.UserAccounts.All
        .Where(ua => ua.UserId == _user.Id)
        .Select(ua => new
        {
            Name = ua.FriendlyName, 
            Balance = ua.Balance.ToString("0.00"), 
            ua.Key
        })
        .ToList();

    private record UserAccountRecord(string Name, string Amount, Guid Key);
}

using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.Wrappers;

namespace EBanking.UI.Forms;
public partial class UserForm : App.Form
{
    private readonly IEbankingDbContext _dbContext;
    private readonly User _user;

    public UserForm(IEbankingDbContext dbContext, User user)
    {
        InitializeComponent();
        _user = user;
        _dbContext = dbContext;
        Text = _user.FullName;
        LoadAccounts();
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
        new MakeTransaction(_dbContext, _user).ShowDialog();
        LoadAccounts();
    }

    private void BtnTransactionHistory_Click(object sender, EventArgs e)
    {
        new TransactionHistory(_dbContext, _user).ShowDialog();
    }

    private void BtnCreateAccount_Click(object sender, EventArgs e)
    {
        CreateAccount createAccount = new(_dbContext, _user.Id);
        createAccount.UserAccountCreated += userAccount =>
        {
            _lbxAccounts.Items.Add(new UserAccountWrap(userAccount));
            _lbxAccounts.Refresh();
        };
        createAccount.ShowDialog();
    }

    private void LoadAccounts() =>
        _lbxAccounts.DataSource = _dbContext.UserAccounts.All
            .Where(uc => uc.UserId == _user.Id)
            .Select(uc => new UserAccountWrap(uc))
            .ToList();
}

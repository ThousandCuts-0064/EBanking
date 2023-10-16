using EBanking.Data.Entities;
using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;
internal partial class UserForm : Form
{
    private readonly UserViewModel _user;

    public UserForm(UserViewModel user)
    {
        InitializeComponent();
        _user = user;
        Text = _user.FullName;
        LoadAccounts();
    }

    private void BtnDeposit_Click(object sender, EventArgs e)
    {
        new AlterAccountBalanceForm(_user, TransactionType.Credit).ShowDialog();
        LoadAccounts();
    }

    private void BtnWithdraw_Click(object sender, EventArgs e)
    {
        new AlterAccountBalanceForm(_user, TransactionType.Debit).ShowDialog();
        LoadAccounts();
    }

    private void BtnMakeTransaction_Click(object sender, EventArgs e)
    {
        new TransactionForm(_user).ShowDialog();
        LoadAccounts();
    }

    private void BtnTransactionHistory_Click(object sender, EventArgs e)
    {
        new TransactionHistory(_user).ShowDialog();
    }

    private void BtnCreateAccount_Click(object sender, EventArgs e)
    {
        var createAccount = new CreateAccount(_user);
        createAccount.UserAccountCreated += _ => LoadAccounts();
        createAccount.ShowDialog();
    }

    private void LoadAccounts() => _dgvAccounts.DataSource =
        _user.UserAccounts
        .Select(ua => new
        {
            ua.Name,
            Balance = ua.Balance.ToString("0.00"),
            ua.Key
        })
        .ToList();
}

using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.Logic.Models;
using EBanking.Logic.Services;

namespace EBanking.UI.Forms;
public partial class UserForm : Form
{
    private readonly ITransactionService _transactionService;
    private readonly IUserModel _user;

    public UserForm(ITransactionService transactionService, IUserModel user)
    {
        InitializeComponent();
        _transactionService = transactionService;
        _user = user;
        Text = _user.FullName;
        LoadAccounts();
    }

    private void BtnDeposit_Click(object sender, EventArgs e)
    {
        new AlterAccountBalanceForm(_transactionService, _user, TransactionType.Credit).ShowDialog();
        LoadAccounts();
    }

    private void BtnWithdraw_Click(object sender, EventArgs e)
    {
        new AlterAccountBalanceForm(_transactionService, _user, TransactionType.Debit).ShowDialog();
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
        _user.UserAccounts
        .Select(ua => new
        {
            ua.Name, 
            Balance = ua.Balance.ToString("0.00"), 
            ua.Key
        })
        .ToList();
}

using EBanking.UI.ViewModels;

namespace EBanking.UI.Forms;

internal partial class TransactionHistory : Form
{
    private readonly UserViewModel _user;

    public TransactionHistory(UserViewModel user)
    {
        InitializeComponent();
        _user = user;
        Text = _user.FullName;
        _dgvMain.DataSource = _user.UserAccounts
            .SelectMany(ua => ua.Transactions)
            .Select(t => new
            {
                Account = t.UserAccount.Name,
                t.Type,
                Amount = t.Amount.ToString("0.00"),
                Date = t.EventDate
            })
            .ToList();
    }
}

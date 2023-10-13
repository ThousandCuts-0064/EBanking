using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI.Forms;

public partial class TransactionHistory : Form
{
    private readonly IEbankingDbContext _dbContext;
    private readonly User _user;

    public TransactionHistory(IEbankingDbContext dbContext, User user)
    {
        InitializeComponent();
        _dbContext = dbContext;
        _user = user;
        Text = _user.FullName;
        Dictionary<int, string> userAccounts = _dbContext.UserAccounts.All
            .Where(ua => ua.UserId == _user.Id)
            .ToDictionary(ua => ua.Id, ua => ua.FriendlyName);
        _dgvMain.DataSource = _dbContext.Transactions.All
            .Where(t => userAccounts.ContainsKey(t.UserAccountId))
            .Select(t => new
            {
                Account = userAccounts[t.UserAccountId],
                t.Type,
                Amount = t.Amount.ToString("0.00"),
                Date = t.EventDate
            })
            .ToList();
    }
}

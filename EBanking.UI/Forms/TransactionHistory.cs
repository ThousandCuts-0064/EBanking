using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.UserControls;

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
        _tlpTransactions.RowStyles.Clear();
        int i = 0;
        RowStyle rowStyle = new(SizeType.Percent, 20);
        HashSet<int> accountIds = _dbContext.UserAccounts.All
            .Where(uc => uc.UserId == _user.Id)
            .Select(uc => uc.Id)
            .ToHashSet();
        foreach (var transaction in _dbContext.Transactions.All
            .Where(t => accountIds.Contains(t.UserAccountId)))
        {
            _tlpTransactions.RowStyles.Add(rowStyle);
            _tlpTransactions.Controls.Add(new TransactionControl(_dbContext, transaction), 0, i++);
        }
    }
}

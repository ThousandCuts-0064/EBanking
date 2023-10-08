using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI.UserControls;

public partial class TransactionControl : UserControl
{
    private readonly IEbankingDbContext _dbContext;
    private readonly Transaction _transaction;

    public TransactionControl(IEbankingDbContext dbContext, Transaction transaction)
    {
        InitializeComponent();
        _dbContext = dbContext;
        _transaction = transaction;
        _lblAccount.Text = _dbContext.UserAccounts.All.First(uc => uc.Id == _transaction.UserAccountId).FriendlyName;
        _lblType.Text = _transaction.Type.ToString();
        _lblAmount.Text = _transaction.Amount.ToString();
        _lblDate.Text = _transaction.EventDate.ToString();
    }
}

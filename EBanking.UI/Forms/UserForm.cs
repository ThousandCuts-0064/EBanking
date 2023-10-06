using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.ViewModels;

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
        _lbxAccounts.Items.AddRange(
            _dbContext.UserAccounts.All
                .Where(uc => uc.UserId == _user.Id)
                .Select(uc => new UserAccountVM(uc))
                .ToArray());
    }

    private void BtnCreateAccount_Click(object sender, EventArgs e)
    {
        CreateAccount createAccount = new(_dbContext, _user.Id);
        createAccount.UserAccountCreated += userAccount =>
        {
            _lbxAccounts.Items.Add(new UserAccountVM(userAccount));
            _lbxAccounts.Refresh();
        };
        createAccount.ShowDialog();
    }
}

using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI.Forms;

public partial class CreateAccount : Form
{
    private readonly IEbankingDbContext _dbContext;
    private readonly int _userId;

    public event Action<UserAccount>? UserAccountCreated;

    public CreateAccount(IEbankingDbContext dbContext, int userId)
    {
        InitializeComponent();
        _dbContext = dbContext;
        _userId = userId;
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
        if (_tbName.Text is "")
        {
            MessageBox.Show(
                "Account name cannot be empty!",
                "Invalid name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        else if (_dbContext.UserAccounts.All
            .Select(ua => ua.FriendlyName)
            .Contains(_tbName.Text))
        {
            MessageBox.Show(
                $"Account with name {_tbName.Text} already exists!",
                "Invalid name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        else
        {
            UserAccount userAccount = new()
            {
                FriendlyName = _tbName.Text,
                UserId = _userId,
                Key = Guid.NewGuid(),
            };

            _dbContext.UserAccounts.Insert(userAccount);
            UserAccountCreated?.Invoke(userAccount);
            Close();
        }
    }
}

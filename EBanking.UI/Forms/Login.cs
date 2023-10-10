using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI.Forms;

public partial class Login : App.Form
{
    private readonly IEbankingDbContext _dbContext;

    public Login(IEbankingDbContext dbContext)
    {
        InitializeComponent();
        _dbContext = dbContext;
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        new Register(_dbContext).Show();
        Close();
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        User match = new()
        {
            Username = _tbUsername.Text,
            Password = Encryption.SHA512(_tbPassword.Text)
        };
        User? user = _dbContext.Users.All.FirstOrDefault(u => Comparers.UserLogin.Equals(match, u));

        if (user is null)
        {
            MessageBox.Show(
                "No Username and Password match found",
                "Invalid login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        else
        {
            new UserForm(_dbContext, user).Show();
            Close();
        }
    }
}

using System.Text;
using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI.Forms;

public partial class Login : Form
{
    private readonly IEbankingDbContext _dbContext;
    public User? AuthenticatedUser { get; private set; }
    public bool DoOpenRegister { get; private set; }

    public Login(IEbankingDbContext dbContext)
    {
        InitializeComponent();
        _dbContext = dbContext;
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        DoOpenRegister = true;
        Close();
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        var match = new User()
        {
            Username = _tbUsername.Text,
            Password = Encryption.SHA512(_tbPassword.Text)
        };
        var user = _dbContext.Users.All
            .FirstOrDefault(u => Comparers.UserLogin.Equals(match, u));

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
            AuthenticatedUser = user;
            Close();
        }
    }
}

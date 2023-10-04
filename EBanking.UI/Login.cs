using EBanking.Data.Interfaces;

namespace EBanking.UI;

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
        Register register = new(_dbContext);
        register.Show();
        register.Location = Location;
        Close();
    }
}

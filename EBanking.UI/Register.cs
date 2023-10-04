using EBanking.Data.Entities;
using EBanking.Data.Interfaces;

namespace EBanking.UI;

public partial class Register : App.Form
{
    private readonly IEbankingDbContext _dbContext;

    public Register(IEbankingDbContext dbContext)
    {
        InitializeComponent();
        _dbContext = dbContext;
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        User user = new()
        {
            Username = tbUsername.Text,
            Password = tbPassword.Text,
            FullName = tbName.Text,
            Email = tbEmail.Text,
            DateRegistered = DateTime.Now,
        };

        _dbContext.Users.Insert(user);
    }
}

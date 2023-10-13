using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.UI.Forms;

namespace EBanking.UI;

internal class EBankingContext : ApplicationContext
{
    private readonly IEbankingDbContext _dbContext;

    public EBankingContext(IEbankingDbContext dbContext)
        : base(new Login(dbContext)) =>
        _dbContext = dbContext;

    protected override void OnMainFormClosed(object? sender, EventArgs e)
    {
        if (sender is Login login)
        {
            if (login.DoOpenRegister)
                ChangeMainForm(new Register(_dbContext));

            else if (login.AuthenticatedUser is not null)
                ChangeMainForm(new UserForm(_dbContext, login.AuthenticatedUser));

            else
                base.OnMainFormClosed(sender, e);
        }
        else if (sender is Register register
            && register.AuthenticatedUser is not null)
        {
            ChangeMainForm(new UserForm(_dbContext, register.AuthenticatedUser));
        }
        else
            base.OnMainFormClosed(sender, e);
    }

    private void ChangeMainForm(Form form)
    {
        MainForm = form;
        form.Show();
    }
}

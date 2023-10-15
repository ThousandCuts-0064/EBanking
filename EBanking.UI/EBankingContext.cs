using EBanking.Data.Entities;
using EBanking.Data.Interfaces;
using EBanking.Logic.Services;
using EBanking.UI.Forms;

namespace EBanking.UI;

internal class EBankingContext : ApplicationContext
{
    private readonly IAuthenticator _authenticator;
    private readonly ITransactionService _transactionService;

    public EBankingContext(IAuthenticator authenticator, ITransactionService transactionService)
        : base(new LoginForm(authenticator))
    {
        _authenticator = authenticator;
        _transactionService = transactionService;
    }

    protected override void OnMainFormClosed(object? sender, EventArgs e)
    {
        if (sender is LoginForm login)
        {
            if (login.DoOpenRegister)
                ChangeMainForm(new RegisterForm(_authenticator));

            else if (login.AuthenticatedUser is not null)
                ChangeMainForm(new UserForm(_transactionService, login.AuthenticatedUser));

            else
                base.OnMainFormClosed(sender, e);
        }
        else if (sender is RegisterForm register
            && register.AuthenticatedUser is not null)
        {
            ChangeMainForm(new UserForm(_transactionService, register.AuthenticatedUser));
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

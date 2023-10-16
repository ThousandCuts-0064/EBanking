using EBanking.Logic.Services;
using EBanking.UI.Forms;

namespace EBanking.UI;

internal class EBankingAppContext : ApplicationContext
{
    private readonly IAuthenticator _authenticator;

    public EBankingAppContext(IAuthenticator authenticator)
        : base(new LoginForm(authenticator)) => 
        _authenticator = authenticator;

    protected override void OnMainFormClosed(object? sender, EventArgs e)
    {
        if (sender is LoginForm login)
        {
            if (login.DoOpenRegister)
                ChangeMainForm(new RegisterForm(_authenticator));

            else if (login.AuthenticatedUser is not null)
                ChangeMainForm(new UserForm(login.AuthenticatedUser));

            else
                base.OnMainFormClosed(sender, e);
        }
        else if (sender is RegisterForm register
            && register.AuthenticatedUser is not null)
        {
            ChangeMainForm(new UserForm(register.AuthenticatedUser));
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

namespace EBanking.UI;

public partial class Login : App.Form
{
    public Login()
    {
        InitializeComponent();
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        Register register = new();
        register.Show();
        register.Location = Location;
        Close();
    }
}

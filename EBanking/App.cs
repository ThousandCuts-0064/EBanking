namespace EBanking.UI;

public partial class App : Form
{
    private int _formCount;
    public static App Instance { get; } = new();

    private App() => InitializeComponent();

    protected override void OnLoad(EventArgs e) => new Login().Show();
    protected override void OnVisibleChanged(EventArgs e) => Hide();

    private void OnFormCreated() => _formCount++;

    private void OnFormClosed()
    {
        _formCount--;

        if (_formCount == 0)
            Instance.Close();
    }

    public class Form : System.Windows.Forms.Form
    {
        protected Form() => Instance.OnFormCreated();

        protected override void OnClosed(EventArgs e) => Instance.OnFormClosed();
    }
}

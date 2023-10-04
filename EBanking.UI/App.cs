using EBanking.Data;
using EBanking.Data.Interfaces;
using EBanking.UI.Properties;

namespace EBanking.UI;

public partial class App : Form
{
    private IEbankingDbContext _dbContext = null!;
    private int _formCount;
    public static App Instance { get; } = new();

    private App()
    {
        InitializeComponent();
    }

    public static void Initialize(IEbankingDbContext dbContext)
    {
        Instance._dbContext = dbContext;
    }

    protected override void OnLoad(EventArgs e)
    {
        if (_dbContext is null)
            throw new InvalidProgramException($"{nameof(App)}.{nameof(Initialize)} was not called");

        new Login(_dbContext).Show();
    }

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

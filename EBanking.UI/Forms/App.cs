using EBanking.Data.Interfaces;

namespace EBanking.UI.Forms;

public partial class App : Form
{
    private IEbankingDbContext _dbContext = null!;
    private int _formCount;
    public static App Instance { get; } = new();

    private App() => InitializeComponent();

    public static void Initialize(IEbankingDbContext dbContext) => Instance._dbContext = dbContext;

    protected override void OnLoad(EventArgs e)
    {
        if (_dbContext is null)
            throw new InvalidProgramException($"{nameof(App)}.{nameof(Initialize)} was not called");

        new Login(_dbContext).Show();
    }

    protected override void OnVisibleChanged(EventArgs e) => Hide();

    private void OnFormLoaded() => _formCount++;

    private void OnFormClosed()
    {
        _formCount--;

        if (_formCount == 0)
            Instance.Close();
    }

    public class Form : System.Windows.Forms.Form
    {
        protected override void OnLoad(EventArgs e) => Instance.OnFormLoaded(); // If this is in the constructor the designer will break

        protected override void OnClosed(EventArgs e) => Instance.OnFormClosed();
    }
}

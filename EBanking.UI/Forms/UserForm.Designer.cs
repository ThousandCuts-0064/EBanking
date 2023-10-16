namespace EBanking.UI.Forms;

partial class UserForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _btnCreateAccount = new Button();
        _btnMakeTransaction = new Button();
        _btnTransactionHistory = new Button();
        _btnDeposit = new Button();
        _btnWithdraw = new Button();
        _tlpButtons = new TableLayoutPanel();
        _dgvAccounts = new DataGridView();
        _tlpMain = new TableLayoutPanel();
        _tlpButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_dgvAccounts).BeginInit();
        _tlpMain.SuspendLayout();
        SuspendLayout();
        // 
        // _btnCreateAccount
        // 
        _btnCreateAccount.AutoSize = true;
        _btnCreateAccount.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnCreateAccount.Dock = DockStyle.Fill;
        _btnCreateAccount.Location = new Point(3, 223);
        _btnCreateAccount.Name = "_btnCreateAccount";
        _btnCreateAccount.Size = new Size(92, 49);
        _btnCreateAccount.TabIndex = 4;
        _btnCreateAccount.Text = "Create Account";
        _btnCreateAccount.UseVisualStyleBackColor = true;
        _btnCreateAccount.Click += BtnCreateAccount_Click;
        // 
        // _btnMakeTransaction
        // 
        _btnMakeTransaction.AutoSize = true;
        _btnMakeTransaction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnMakeTransaction.Dock = DockStyle.Fill;
        _btnMakeTransaction.Location = new Point(3, 113);
        _btnMakeTransaction.Name = "_btnMakeTransaction";
        _btnMakeTransaction.Size = new Size(92, 49);
        _btnMakeTransaction.TabIndex = 2;
        _btnMakeTransaction.Text = "Make Transaction";
        _btnMakeTransaction.UseVisualStyleBackColor = true;
        _btnMakeTransaction.Click += BtnMakeTransaction_Click;
        // 
        // _btnTransactionHistory
        // 
        _btnTransactionHistory.AutoSize = true;
        _btnTransactionHistory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnTransactionHistory.Dock = DockStyle.Fill;
        _btnTransactionHistory.Location = new Point(3, 168);
        _btnTransactionHistory.Name = "_btnTransactionHistory";
        _btnTransactionHistory.Size = new Size(92, 49);
        _btnTransactionHistory.TabIndex = 3;
        _btnTransactionHistory.Text = "Transaction History";
        _btnTransactionHistory.UseVisualStyleBackColor = true;
        _btnTransactionHistory.Click += BtnTransactionHistory_Click;
        // 
        // _btnDeposit
        // 
        _btnDeposit.AutoSize = true;
        _btnDeposit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnDeposit.Dock = DockStyle.Fill;
        _btnDeposit.Location = new Point(3, 3);
        _btnDeposit.Name = "_btnDeposit";
        _btnDeposit.Size = new Size(92, 49);
        _btnDeposit.TabIndex = 0;
        _btnDeposit.Text = "Deposit";
        _btnDeposit.UseVisualStyleBackColor = true;
        _btnDeposit.Click += BtnDeposit_Click;
        // 
        // _btnWithdraw
        // 
        _btnWithdraw.AutoSize = true;
        _btnWithdraw.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _btnWithdraw.Dock = DockStyle.Fill;
        _btnWithdraw.Location = new Point(3, 58);
        _btnWithdraw.Name = "_btnWithdraw";
        _btnWithdraw.Size = new Size(92, 49);
        _btnWithdraw.TabIndex = 1;
        _btnWithdraw.Text = "Withdraw";
        _btnWithdraw.UseVisualStyleBackColor = true;
        _btnWithdraw.Click += BtnWithdraw_Click;
        // 
        // _tlpButtons
        // 
        _tlpButtons.AutoSize = true;
        _tlpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _tlpButtons.ColumnCount = 1;
        _tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _tlpButtons.Controls.Add(_btnTransactionHistory, 0, 3);
        _tlpButtons.Controls.Add(_btnCreateAccount, 0, 4);
        _tlpButtons.Controls.Add(_btnWithdraw, 0, 1);
        _tlpButtons.Controls.Add(_btnMakeTransaction, 0, 2);
        _tlpButtons.Controls.Add(_btnDeposit, 0, 0);
        _tlpButtons.Dock = DockStyle.Fill;
        _tlpButtons.Location = new Point(3, 4);
        _tlpButtons.Margin = new Padding(3, 4, 3, 4);
        _tlpButtons.Name = "_tlpButtons";
        _tlpButtons.RowCount = 5;
        _tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        _tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        _tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        _tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        _tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        _tlpButtons.Size = new Size(98, 275);
        _tlpButtons.TabIndex = 6;
        // 
        // _dgvAccounts
        // 
        _dgvAccounts.AllowUserToAddRows = false;
        _dgvAccounts.AllowUserToDeleteRows = false;
        _dgvAccounts.AllowUserToResizeRows = false;
        _dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _dgvAccounts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        _dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _dgvAccounts.Dock = DockStyle.Fill;
        _dgvAccounts.Location = new Point(107, 3);
        _dgvAccounts.MultiSelect = false;
        _dgvAccounts.Name = "_dgvAccounts";
        _dgvAccounts.ReadOnly = true;
        _dgvAccounts.RowHeadersVisible = false;
        _dgvAccounts.RowHeadersWidth = 51;
        _dgvAccounts.RowTemplate.Height = 29;
        _dgvAccounts.RowTemplate.ReadOnly = true;
        _dgvAccounts.RowTemplate.Resizable = DataGridViewTriState.False;
        _dgvAccounts.SelectionMode = DataGridViewSelectionMode.CellSelect;
        _dgvAccounts.Size = new Size(412, 277);
        _dgvAccounts.TabIndex = 5;
        _dgvAccounts.VirtualMode = true;
        // 
        // _tlpMain
        // 
        _tlpMain.AutoSize = true;
        _tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _tlpMain.ColumnCount = 2;
        _tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        _tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
        _tlpMain.Controls.Add(_tlpButtons, 0, 0);
        _tlpMain.Controls.Add(_dgvAccounts, 1, 0);
        _tlpMain.Dock = DockStyle.Fill;
        _tlpMain.Location = new Point(0, 0);
        _tlpMain.Name = "_tlpMain";
        _tlpMain.RowCount = 1;
        _tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _tlpMain.Size = new Size(522, 283);
        _tlpMain.TabIndex = 8;
        // 
        // UserForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(522, 283);
        Controls.Add(_tlpMain);
        MinimumSize = new Size(540, 330);
        Name = "UserForm";
        SizeGripStyle = SizeGripStyle.Show;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FullName";
        _tlpButtons.ResumeLayout(false);
        _tlpButtons.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_dgvAccounts).EndInit();
        _tlpMain.ResumeLayout(false);
        _tlpMain.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button _btnCreateAccount;
    private Button _btnMakeTransaction;
    private Button _btnTransactionHistory;
    private Button _btnDeposit;
    private Button _btnWithdraw;
    private TableLayoutPanel _tlpButtons;
    private DataGridView _dgvAccounts;
    private TableLayoutPanel _tlpMain;
}
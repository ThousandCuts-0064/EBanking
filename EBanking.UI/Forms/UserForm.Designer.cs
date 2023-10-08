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
        _lbxAccounts = new ListBox();
        _btnMakeTransaction = new Button();
        _btnTransactionHistory = new Button();
        _btnDeposit = new Button();
        _btnWithdraw = new Button();
        tableLayoutPanel1 = new TableLayoutPanel();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // _btnCreateAccount
        // 
        _btnCreateAccount.Dock = DockStyle.Fill;
        _btnCreateAccount.Location = new Point(3, 266);
        _btnCreateAccount.Margin = new Padding(3, 2, 3, 2);
        _btnCreateAccount.Name = "_btnCreateAccount";
        _btnCreateAccount.Size = new Size(159, 65);
        _btnCreateAccount.TabIndex = 0;
        _btnCreateAccount.Text = "Create Account";
        _btnCreateAccount.UseVisualStyleBackColor = true;
        _btnCreateAccount.Click += BtnCreateAccount_Click;
        // 
        // _lbxAccounts
        // 
        _lbxAccounts.FormattingEnabled = true;
        _lbxAccounts.ItemHeight = 15;
        _lbxAccounts.Location = new Point(183, 14);
        _lbxAccounts.Margin = new Padding(3, 2, 3, 2);
        _lbxAccounts.Name = "_lbxAccounts";
        _lbxAccounts.Size = new Size(165, 334);
        _lbxAccounts.Sorted = true;
        _lbxAccounts.TabIndex = 1;
        // 
        // _btnMakeTransaction
        // 
        _btnMakeTransaction.Dock = DockStyle.Fill;
        _btnMakeTransaction.Location = new Point(3, 134);
        _btnMakeTransaction.Margin = new Padding(3, 2, 3, 2);
        _btnMakeTransaction.Name = "_btnMakeTransaction";
        _btnMakeTransaction.Size = new Size(159, 62);
        _btnMakeTransaction.TabIndex = 2;
        _btnMakeTransaction.Text = "Make Transaction";
        _btnMakeTransaction.UseVisualStyleBackColor = true;
        _btnMakeTransaction.Click += BtnMakeTransaction_Click;
        // 
        // _btnTransactionHistory
        // 
        _btnTransactionHistory.Dock = DockStyle.Fill;
        _btnTransactionHistory.Location = new Point(3, 200);
        _btnTransactionHistory.Margin = new Padding(3, 2, 3, 2);
        _btnTransactionHistory.Name = "_btnTransactionHistory";
        _btnTransactionHistory.Size = new Size(159, 62);
        _btnTransactionHistory.TabIndex = 3;
        _btnTransactionHistory.Text = "Transaction History";
        _btnTransactionHistory.UseVisualStyleBackColor = true;
        _btnTransactionHistory.Click += BtnTransactionHistory_Click;
        // 
        // _btnDeposit
        // 
        _btnDeposit.Dock = DockStyle.Fill;
        _btnDeposit.Location = new Point(3, 2);
        _btnDeposit.Margin = new Padding(3, 2, 3, 2);
        _btnDeposit.Name = "_btnDeposit";
        _btnDeposit.Size = new Size(159, 62);
        _btnDeposit.TabIndex = 4;
        _btnDeposit.Text = "Deposit";
        _btnDeposit.UseVisualStyleBackColor = true;
        _btnDeposit.Click += BtnDeposit_Click;
        // 
        // _btnWithdraw
        // 
        _btnWithdraw.Dock = DockStyle.Fill;
        _btnWithdraw.Location = new Point(3, 68);
        _btnWithdraw.Margin = new Padding(3, 2, 3, 2);
        _btnWithdraw.Name = "_btnWithdraw";
        _btnWithdraw.Size = new Size(159, 62);
        _btnWithdraw.TabIndex = 5;
        _btnWithdraw.Text = "Withdraw";
        _btnWithdraw.UseVisualStyleBackColor = true;
        _btnWithdraw.Click += BtnWithdraw_Click;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel1.Controls.Add(_btnDeposit, 0, 0);
        tableLayoutPanel1.Controls.Add(_btnTransactionHistory, 0, 3);
        tableLayoutPanel1.Controls.Add(_btnCreateAccount, 0, 4);
        tableLayoutPanel1.Controls.Add(_btnWithdraw, 0, 1);
        tableLayoutPanel1.Controls.Add(_btnMakeTransaction, 0, 2);
        tableLayoutPanel1.Location = new Point(12, 12);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 5;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.Size = new Size(165, 333);
        tableLayoutPanel1.TabIndex = 6;
        // 
        // UserForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(584, 356);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(_lbxAccounts);
        Margin = new Padding(3, 2, 3, 2);
        Name = "UserForm";
        Text = "FullName";
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Button _btnCreateAccount;
    private ListBox _lbxAccounts;
    private Button _btnMakeTransaction;
    private Button _btnTransactionHistory;
    private Button _btnDeposit;
    private Button _btnWithdraw;
    private TableLayoutPanel tableLayoutPanel1;
}
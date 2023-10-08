namespace EBanking.UI.Forms;

partial class TransactionHistory
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
        _tlpTransactions = new TableLayoutPanel();
        SuspendLayout();
        // 
        // _tlpTransactions
        // 
        _tlpTransactions.ColumnCount = 1;
        _tlpTransactions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.2935333F));
        _tlpTransactions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.7064667F));
        _tlpTransactions.Dock = DockStyle.Fill;
        _tlpTransactions.Location = new Point(0, 0);
        _tlpTransactions.Name = "_tlpTransactions";
        _tlpTransactions.RowCount = 2;
        _tlpTransactions.RowStyles.Add(new RowStyle(SizeType.Percent, 50.22222F));
        _tlpTransactions.RowStyles.Add(new RowStyle(SizeType.Percent, 49.77778F));
        _tlpTransactions.Size = new Size(384, 361);
        _tlpTransactions.TabIndex = 1;
        // 
        // TransactionHistory
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 361);
        Controls.Add(_tlpTransactions);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "TransactionHistory";
        Text = "Username";
        ResumeLayout(false);
    }

    #endregion
    private TableLayoutPanel _tlpTransactions;
}
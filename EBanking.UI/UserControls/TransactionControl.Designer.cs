namespace EBanking.UI.UserControls;

partial class TransactionControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _lblAccount = new Label();
        _lblType = new Label();
        _lblAmount = new Label();
        _lblDate = new Label();
        SuspendLayout();
        // 
        // _lblAccount
        // 
        _lblAccount.AutoSize = true;
        _lblAccount.Location = new Point(3, 0);
        _lblAccount.Name = "_lblAccount";
        _lblAccount.Size = new Size(52, 15);
        _lblAccount.TabIndex = 0;
        _lblAccount.Text = "Account";
        // 
        // _lblType
        // 
        _lblType.AutoSize = true;
        _lblType.Location = new Point(3, 15);
        _lblType.Name = "_lblType";
        _lblType.Size = new Size(31, 15);
        _lblType.TabIndex = 1;
        _lblType.Text = "Type";
        // 
        // _lblAmount
        // 
        _lblAmount.AutoSize = true;
        _lblAmount.Location = new Point(3, 30);
        _lblAmount.Name = "_lblAmount";
        _lblAmount.Size = new Size(51, 15);
        _lblAmount.TabIndex = 2;
        _lblAmount.Text = "Amount";
        // 
        // _lblDate
        // 
        _lblDate.AutoSize = true;
        _lblDate.Location = new Point(3, 45);
        _lblDate.Name = "_lblDate";
        _lblDate.Size = new Size(31, 15);
        _lblDate.TabIndex = 3;
        _lblDate.Text = "Date";
        // 
        // TransactionControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = SystemColors.ControlLight;
        Controls.Add(_lblDate);
        Controls.Add(_lblAmount);
        Controls.Add(_lblType);
        Controls.Add(_lblAccount);
        Name = "TransactionControl";
        Size = new Size(58, 60);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label _lblAccount;
    private Label _lblType;
    private Label _lblAmount;
    private Label _lblDate;
}

namespace EBanking.UI.Forms;

partial class UpdateAccount
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
        _lbxAccounts = new ListBox();
        _lblAmount = new Label();
        _btnConfirm = new Button();
        _tbAmount = new TextBox();
        SuspendLayout();
        // 
        // _lbxAccounts
        // 
        _lbxAccounts.FormattingEnabled = true;
        _lbxAccounts.ItemHeight = 15;
        _lbxAccounts.Location = new Point(12, 12);
        _lbxAccounts.Name = "_lbxAccounts";
        _lbxAccounts.Size = new Size(170, 79);
        _lbxAccounts.TabIndex = 0;
        // 
        // _lblAmount
        // 
        _lblAmount.AutoSize = true;
        _lblAmount.Location = new Point(188, 15);
        _lblAmount.Name = "_lblAmount";
        _lblAmount.Size = new Size(51, 15);
        _lblAmount.TabIndex = 7;
        _lblAmount.Text = "Amount";
        // 
        // _btnConfirm
        // 
        _btnConfirm.Location = new Point(188, 41);
        _btnConfirm.Name = "_btnConfirm";
        _btnConfirm.Size = new Size(184, 51);
        _btnConfirm.TabIndex = 6;
        _btnConfirm.Text = "Confirm";
        _btnConfirm.UseVisualStyleBackColor = true;
        _btnConfirm.Click += BtnConfirm_Click;
        // 
        // _tbAmount
        // 
        _tbAmount.Location = new Point(245, 12);
        _tbAmount.Name = "_tbAmount";
        _tbAmount.Size = new Size(127, 23);
        _tbAmount.TabIndex = 5;
        // 
        // UpdateAccount
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 104);
        Controls.Add(_lblAmount);
        Controls.Add(_btnConfirm);
        Controls.Add(_tbAmount);
        Controls.Add(_lbxAccounts);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "UpdateAccount";
        Text = "Username+UpdateAccountOption";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox _lbxAccounts;
    private Label _lblAmount;
    private Button _btnConfirm;
    private TextBox _tbAmount;
}
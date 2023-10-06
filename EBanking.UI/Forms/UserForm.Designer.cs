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
        SuspendLayout();
        // 
        // _btnCreateAccount
        // 
        _btnCreateAccount.Location = new Point(12, 318);
        _btnCreateAccount.Name = "_btnCreateAccount";
        _btnCreateAccount.Size = new Size(180, 120);
        _btnCreateAccount.TabIndex = 0;
        _btnCreateAccount.Text = "Create Account";
        _btnCreateAccount.UseVisualStyleBackColor = true;
        _btnCreateAccount.Click += BtnCreateAccount_Click;
        // 
        // _lbxAccounts
        // 
        _lbxAccounts.FormattingEnabled = true;
        _lbxAccounts.ItemHeight = 20;
        _lbxAccounts.Location = new Point(523, 78);
        _lbxAccounts.Name = "_lbxAccounts";
        _lbxAccounts.Size = new Size(108, 124);
        _lbxAccounts.TabIndex = 1;
        // 
        // UserForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_lbxAccounts);
        Controls.Add(_btnCreateAccount);
        Name = "UserForm";
        Text = "FullName";
        ResumeLayout(false);
    }

    #endregion

    private Button _btnCreateAccount;
    private ListBox _lbxAccounts;
}
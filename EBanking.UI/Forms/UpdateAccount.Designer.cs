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
        _lbxAccounts.ItemHeight = 20;
        _lbxAccounts.Location = new Point(14, 16);
        _lbxAccounts.Margin = new Padding(3, 4, 3, 4);
        _lbxAccounts.Name = "_lbxAccounts";
        _lbxAccounts.Size = new Size(194, 104);
        _lbxAccounts.TabIndex = 0;
        // 
        // _lblAmount
        // 
        _lblAmount.AutoSize = true;
        _lblAmount.Location = new Point(215, 20);
        _lblAmount.Name = "_lblAmount";
        _lblAmount.Size = new Size(62, 20);
        _lblAmount.TabIndex = 7;
        _lblAmount.Text = "Amount";
        // 
        // _btnConfirm
        // 
        _btnConfirm.Location = new Point(215, 55);
        _btnConfirm.Margin = new Padding(3, 4, 3, 4);
        _btnConfirm.Name = "_btnConfirm";
        _btnConfirm.Size = new Size(210, 68);
        _btnConfirm.TabIndex = 6;
        _btnConfirm.Text = "Confirm";
        _btnConfirm.UseVisualStyleBackColor = true;
        _btnConfirm.Click += BtnConfirm_Click;
        // 
        // _tbAmount
        // 
        _tbAmount.Location = new Point(280, 16);
        _tbAmount.Margin = new Padding(3, 4, 3, 4);
        _tbAmount.Name = "_tbAmount";
        _tbAmount.Size = new Size(145, 27);
        _tbAmount.TabIndex = 5;
        // 
        // UpdateAccount
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(439, 139);
        Controls.Add(_lblAmount);
        Controls.Add(_btnConfirm);
        Controls.Add(_tbAmount);
        Controls.Add(_lbxAccounts);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Margin = new Padding(3, 4, 3, 4);
        Name = "UpdateAccount";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "UpdateAccountOption";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox _lbxAccounts;
    private Label _lblAmount;
    private Button _btnConfirm;
    private TextBox _tbAmount;
}
namespace EBanking.UI.Forms;

partial class MakeTransaction
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
        _tbKey = new TextBox();
        _tbAmount = new TextBox();
        _btnConfirm = new Button();
        _lblKey = new Label();
        _lblAmount = new Label();
        SuspendLayout();
        // 
        // _lbxAccounts
        // 
        _lbxAccounts.FormattingEnabled = true;
        _lbxAccounts.ItemHeight = 15;
        _lbxAccounts.Location = new Point(12, 12);
        _lbxAccounts.Name = "_lbxAccounts";
        _lbxAccounts.Size = new Size(170, 109);
        _lbxAccounts.TabIndex = 0;
        // 
        // _tbKey
        // 
        _tbKey.Location = new Point(245, 12);
        _tbKey.Name = "_tbKey";
        _tbKey.Size = new Size(127, 23);
        _tbKey.TabIndex = 1;
        // 
        // _tbAmount
        // 
        _tbAmount.Location = new Point(245, 41);
        _tbAmount.Name = "_tbAmount";
        _tbAmount.Size = new Size(127, 23);
        _tbAmount.TabIndex = 2;
        // 
        // _btnConfirm
        // 
        _btnConfirm.Location = new Point(188, 70);
        _btnConfirm.Name = "_btnConfirm";
        _btnConfirm.Size = new Size(184, 51);
        _btnConfirm.TabIndex = 3;
        _btnConfirm.Text = "Confirm";
        _btnConfirm.UseVisualStyleBackColor = true;
        _btnConfirm.Click += BtnConfirm_Click;
        // 
        // _lblKey
        // 
        _lblKey.AutoSize = true;
        _lblKey.Location = new Point(188, 15);
        _lblKey.Name = "_lblKey";
        _lblKey.Size = new Size(26, 15);
        _lblKey.TabIndex = 4;
        _lblKey.Text = "Key";
        // 
        // _lblAmount
        // 
        _lblAmount.AutoSize = true;
        _lblAmount.Location = new Point(188, 44);
        _lblAmount.Name = "_lblAmount";
        _lblAmount.Size = new Size(51, 15);
        _lblAmount.TabIndex = 5;
        _lblAmount.Text = "Amount";
        // 
        // MakeTransaction
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 133);
        Controls.Add(_lblAmount);
        Controls.Add(_lblKey);
        Controls.Add(_btnConfirm);
        Controls.Add(_tbAmount);
        Controls.Add(_tbKey);
        Controls.Add(_lbxAccounts);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MakeTransaction";
        Text = "Username";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox _lbxAccounts;
    private TextBox _tbKey;
    private TextBox _tbAmount;
    private Button _btnConfirm;
    private Label _lblKey;
    private Label _lblAmount;
}
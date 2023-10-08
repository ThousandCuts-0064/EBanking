namespace EBanking.UI.Forms;

partial class Register
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
        _lblUserName = new Label();
        _lblPassword = new Label();
        _tbUsername = new TextBox();
        _tbPassword = new TextBox();
        _btnRegister = new Button();
        _lblEmail = new Label();
        _tbEmail = new TextBox();
        _tbName = new TextBox();
        _lblName = new Label();
        SuspendLayout();
        // 
        // _lblUserName
        // 
        _lblUserName.AutoSize = true;
        _lblUserName.Location = new Point(10, 11);
        _lblUserName.Name = "_lblUserName";
        _lblUserName.Size = new Size(60, 15);
        _lblUserName.TabIndex = 0;
        _lblUserName.Text = "Username";
        // 
        // _lblPassword
        // 
        _lblPassword.AutoSize = true;
        _lblPassword.Location = new Point(10, 36);
        _lblPassword.Name = "_lblPassword";
        _lblPassword.Size = new Size(57, 15);
        _lblPassword.TabIndex = 1;
        _lblPassword.Text = "Password";
        // 
        // _tbUsername
        // 
        _tbUsername.Location = new Point(81, 9);
        _tbUsername.Margin = new Padding(3, 2, 3, 2);
        _tbUsername.Name = "_tbUsername";
        _tbUsername.Size = new Size(147, 23);
        _tbUsername.TabIndex = 2;
        // 
        // _tbPassword
        // 
        _tbPassword.Location = new Point(81, 34);
        _tbPassword.Margin = new Padding(3, 2, 3, 2);
        _tbPassword.Name = "_tbPassword";
        _tbPassword.Size = new Size(147, 23);
        _tbPassword.TabIndex = 3;
        // 
        // _btnRegister
        // 
        _btnRegister.Location = new Point(10, 108);
        _btnRegister.Margin = new Padding(3, 2, 3, 2);
        _btnRegister.Name = "_btnRegister";
        _btnRegister.Size = new Size(218, 31);
        _btnRegister.TabIndex = 4;
        _btnRegister.Text = "Register";
        _btnRegister.UseVisualStyleBackColor = true;
        _btnRegister.Click += BtnRegister_Click;
        // 
        // _lblEmail
        // 
        _lblEmail.AutoSize = true;
        _lblEmail.Location = new Point(10, 86);
        _lblEmail.Name = "_lblEmail";
        _lblEmail.Size = new Size(36, 15);
        _lblEmail.TabIndex = 6;
        _lblEmail.Text = "Email";
        // 
        // _tbEmail
        // 
        _tbEmail.Location = new Point(81, 83);
        _tbEmail.Margin = new Padding(3, 2, 3, 2);
        _tbEmail.Name = "_tbEmail";
        _tbEmail.Size = new Size(147, 23);
        _tbEmail.TabIndex = 7;
        // 
        // _tbName
        // 
        _tbName.Location = new Point(81, 58);
        _tbName.Margin = new Padding(3, 2, 3, 2);
        _tbName.Name = "_tbName";
        _tbName.Size = new Size(147, 23);
        _tbName.TabIndex = 8;
        // 
        // _lblName
        // 
        _lblName.AutoSize = true;
        _lblName.Location = new Point(10, 61);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(39, 15);
        _lblName.TabIndex = 9;
        _lblName.Text = "Name";
        // 
        // Register
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(247, 148);
        Controls.Add(_lblName);
        Controls.Add(_tbName);
        Controls.Add(_tbEmail);
        Controls.Add(_lblEmail);
        Controls.Add(_btnRegister);
        Controls.Add(_tbPassword);
        Controls.Add(_tbUsername);
        Controls.Add(_lblPassword);
        Controls.Add(_lblUserName);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 2, 3, 2);
        Name = "Register";
        Text = "Register";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label _lblUserName;
    private Label _lblPassword;
    private TextBox _tbUsername;
    private TextBox _tbPassword;
    private Button _btnRegister;
    private Label _lblEmail;
    private TextBox _tbEmail;
    private TextBox _tbName;
    private Label _lblName;
}
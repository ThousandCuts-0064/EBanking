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
        _lblRepeatPassword = new Label();
        _tbRepeatPassword = new TextBox();
        SuspendLayout();
        // 
        // _lblUserName
        // 
        _lblUserName.AutoSize = true;
        _lblUserName.Location = new Point(11, 15);
        _lblUserName.Name = "_lblUserName";
        _lblUserName.Size = new Size(75, 20);
        _lblUserName.TabIndex = 0;
        _lblUserName.Text = "Username";
        // 
        // _lblPassword
        // 
        _lblPassword.AutoSize = true;
        _lblPassword.Location = new Point(11, 48);
        _lblPassword.Name = "_lblPassword";
        _lblPassword.Size = new Size(70, 20);
        _lblPassword.TabIndex = 0;
        _lblPassword.Text = "Password";
        // 
        // _tbUsername
        // 
        _tbUsername.Location = new Point(138, 12);
        _tbUsername.Name = "_tbUsername";
        _tbUsername.Size = new Size(167, 27);
        _tbUsername.TabIndex = 0;
        // 
        // _tbPassword
        // 
        _tbPassword.Location = new Point(138, 45);
        _tbPassword.Name = "_tbPassword";
        _tbPassword.PasswordChar = '*';
        _tbPassword.Size = new Size(167, 27);
        _tbPassword.TabIndex = 1;
        // 
        // _btnRegister
        // 
        _btnRegister.Location = new Point(12, 177);
        _btnRegister.Name = "_btnRegister";
        _btnRegister.Size = new Size(294, 41);
        _btnRegister.TabIndex = 5;
        _btnRegister.Text = "Register";
        _btnRegister.UseVisualStyleBackColor = true;
        _btnRegister.Click += BtnRegister_Click;
        // 
        // _lblEmail
        // 
        _lblEmail.AutoSize = true;
        _lblEmail.Location = new Point(11, 144);
        _lblEmail.Name = "_lblEmail";
        _lblEmail.Size = new Size(46, 20);
        _lblEmail.TabIndex = 0;
        _lblEmail.Text = "Email";
        // 
        // _tbEmail
        // 
        _tbEmail.Location = new Point(138, 144);
        _tbEmail.Name = "_tbEmail";
        _tbEmail.Size = new Size(167, 27);
        _tbEmail.TabIndex = 4;
        // 
        // _tbName
        // 
        _tbName.Location = new Point(138, 111);
        _tbName.Name = "_tbName";
        _tbName.Size = new Size(167, 27);
        _tbName.TabIndex = 3;
        // 
        // _lblName
        // 
        _lblName.AutoSize = true;
        _lblName.Location = new Point(11, 114);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(49, 20);
        _lblName.TabIndex = 0;
        _lblName.Text = "Name";
        // 
        // _lblRepeatPassword
        // 
        _lblRepeatPassword.AutoSize = true;
        _lblRepeatPassword.Location = new Point(11, 81);
        _lblRepeatPassword.Name = "_lblRepeatPassword";
        _lblRepeatPassword.Size = new Size(121, 20);
        _lblRepeatPassword.TabIndex = 0;
        _lblRepeatPassword.Text = "Repeat Password";
        // 
        // _tbRepeatPassword
        // 
        _tbRepeatPassword.Location = new Point(138, 78);
        _tbRepeatPassword.Name = "_tbRepeatPassword";
        _tbRepeatPassword.PasswordChar = '*';
        _tbRepeatPassword.Size = new Size(167, 27);
        _tbRepeatPassword.TabIndex = 2;
        // 
        // Register
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(318, 231);
        Controls.Add(_tbRepeatPassword);
        Controls.Add(_lblRepeatPassword);
        Controls.Add(_lblName);
        Controls.Add(_tbName);
        Controls.Add(_tbEmail);
        Controls.Add(_lblEmail);
        Controls.Add(_btnRegister);
        Controls.Add(_tbPassword);
        Controls.Add(_tbUsername);
        Controls.Add(_lblPassword);
        Controls.Add(_lblUserName);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Register";
        StartPosition = FormStartPosition.CenterScreen;
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
    private Label _lblRepeatPassword;
    private TextBox _tbRepeatPassword;
}
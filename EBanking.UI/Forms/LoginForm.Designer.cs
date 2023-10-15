namespace EBanking.UI.Forms;

partial class LoginForm
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
        _lblUsername = new Label();
        _lblPassword = new Label();
        _tbUsername = new TextBox();
        _tbPassword = new TextBox();
        _btnRegister = new Button();
        _btnLogin = new Button();
        SuspendLayout();
        // 
        // _lblUsername
        // 
        _lblUsername.AutoSize = true;
        _lblUsername.Location = new Point(11, 15);
        _lblUsername.Name = "_lblUsername";
        _lblUsername.Size = new Size(75, 20);
        _lblUsername.TabIndex = 0;
        _lblUsername.Text = "Username";
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
        _tbUsername.Location = new Point(96, 12);
        _tbUsername.Name = "_tbUsername";
        _tbUsername.Size = new Size(164, 27);
        _tbUsername.TabIndex = 0;
        // 
        // _tbPassword
        // 
        _tbPassword.Location = new Point(96, 45);
        _tbPassword.Name = "_tbPassword";
        _tbPassword.PasswordChar = '*';
        _tbPassword.Size = new Size(164, 27);
        _tbPassword.TabIndex = 1;
        // 
        // _btnRegister
        // 
        _btnRegister.Location = new Point(11, 81);
        _btnRegister.Name = "_btnRegister";
        _btnRegister.Size = new Size(121, 41);
        _btnRegister.TabIndex = 3;
        _btnRegister.Text = "Register";
        _btnRegister.UseVisualStyleBackColor = true;
        _btnRegister.Click += BtnRegister_Click;
        // 
        // _btnLogin
        // 
        _btnLogin.Location = new Point(139, 81);
        _btnLogin.Name = "_btnLogin";
        _btnLogin.Size = new Size(121, 41);
        _btnLogin.TabIndex = 2;
        _btnLogin.Text = "Login";
        _btnLogin.UseVisualStyleBackColor = true;
        _btnLogin.Click += BtnLogin_Click;
        // 
        // Login
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(272, 133);
        Controls.Add(_btnLogin);
        Controls.Add(_btnRegister);
        Controls.Add(_tbPassword);
        Controls.Add(_tbUsername);
        Controls.Add(_lblPassword);
        Controls.Add(_lblUsername);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Login";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Login";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label _lblUsername;
    private Label _lblPassword;
    private TextBox _tbUsername;
    private TextBox _tbPassword;
    private Button _btnRegister;
    private Button _btnLogin;
}
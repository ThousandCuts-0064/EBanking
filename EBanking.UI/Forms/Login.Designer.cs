namespace EBanking.UI.Forms;

partial class Login
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
        _lblUsername.Location = new Point(10, 11);
        _lblUsername.Name = "_lblUsername";
        _lblUsername.Size = new Size(60, 15);
        _lblUsername.TabIndex = 0;
        _lblUsername.Text = "Username";
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
        _tbUsername.Location = new Point(84, 9);
        _tbUsername.Margin = new Padding(3, 2, 3, 2);
        _tbUsername.Name = "_tbUsername";
        _tbUsername.Size = new Size(144, 23);
        _tbUsername.TabIndex = 2;
        // 
        // _tbPassword
        // 
        _tbPassword.Location = new Point(84, 34);
        _tbPassword.Margin = new Padding(3, 2, 3, 2);
        _tbPassword.Name = "_tbPassword";
        _tbPassword.Size = new Size(144, 23);
        _tbPassword.TabIndex = 3;
        // 
        // _btnRegister
        // 
        _btnRegister.Location = new Point(10, 61);
        _btnRegister.Margin = new Padding(3, 2, 3, 2);
        _btnRegister.Name = "_btnRegister";
        _btnRegister.Size = new Size(106, 31);
        _btnRegister.TabIndex = 4;
        _btnRegister.Text = "Register";
        _btnRegister.UseVisualStyleBackColor = true;
        _btnRegister.Click += BtnRegister_Click;
        // 
        // _btnLogin
        // 
        _btnLogin.Location = new Point(122, 61);
        _btnLogin.Margin = new Padding(3, 2, 3, 2);
        _btnLogin.Name = "_btnLogin";
        _btnLogin.Size = new Size(106, 31);
        _btnLogin.TabIndex = 5;
        _btnLogin.Text = "Login";
        _btnLogin.UseVisualStyleBackColor = true;
        _btnLogin.Click += BtnLogin_Click;
        // 
        // Login
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(238, 100);
        Controls.Add(_btnLogin);
        Controls.Add(_btnRegister);
        Controls.Add(_tbPassword);
        Controls.Add(_tbUsername);
        Controls.Add(_lblPassword);
        Controls.Add(_lblUsername);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 2, 3, 2);
        Name = "Login";
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
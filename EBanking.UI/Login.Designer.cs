namespace EBanking.UI;

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
        lblUsername = new Label();
        lblPassword = new Label();
        tbName = new TextBox();
        tbPassword = new TextBox();
        btnRegister = new Button();
        btnLogin = new Button();
        SuspendLayout();
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(12, 15);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(75, 20);
        lblUsername.TabIndex = 0;
        lblUsername.Text = "Username";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(12, 48);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(70, 20);
        lblPassword.TabIndex = 1;
        lblPassword.Text = "Password";
        // 
        // tbName
        // 
        tbName.Location = new Point(96, 12);
        tbName.Name = "tbName";
        tbName.Size = new Size(164, 27);
        tbName.TabIndex = 2;
        // 
        // tbPassword
        // 
        tbPassword.Location = new Point(96, 45);
        tbPassword.Name = "tbPassword";
        tbPassword.Size = new Size(164, 27);
        tbPassword.TabIndex = 3;
        // 
        // btnRegister
        // 
        btnRegister.Location = new Point(12, 78);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(121, 41);
        btnRegister.TabIndex = 4;
        btnRegister.Text = "Register";
        btnRegister.UseVisualStyleBackColor = true;
        btnRegister.Click += BtnRegister_Click;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(139, 78);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(121, 41);
        btnLogin.TabIndex = 5;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        // 
        // Login
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(282, 133);
        Controls.Add(btnLogin);
        Controls.Add(btnRegister);
        Controls.Add(tbPassword);
        Controls.Add(tbName);
        Controls.Add(lblPassword);
        Controls.Add(lblUsername);
        Name = "Login";
        Text = "Login";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblUsername;
    private Label lblPassword;
    private TextBox tbName;
    private TextBox tbPassword;
    private Button btnRegister;
    private Button btnLogin;
}
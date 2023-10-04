namespace EBanking.UI;

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
        lblUserName = new Label();
        lblPassword = new Label();
        tbUsername = new TextBox();
        tbPassword = new TextBox();
        btnRegister = new Button();
        lblEmail = new Label();
        tbEmail = new TextBox();
        tbName = new TextBox();
        lblName = new Label();
        SuspendLayout();
        // 
        // lblUserName
        // 
        lblUserName.AutoSize = true;
        lblUserName.Location = new Point(12, 15);
        lblUserName.Name = "lblUserName";
        lblUserName.Size = new Size(75, 20);
        lblUserName.TabIndex = 0;
        lblUserName.Text = "Username";
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
        // tbUsername
        // 
        tbUsername.Location = new Point(93, 12);
        tbUsername.Name = "tbUsername";
        tbUsername.Size = new Size(167, 27);
        tbUsername.TabIndex = 2;
        // 
        // tbPassword
        // 
        tbPassword.Location = new Point(93, 45);
        tbPassword.Name = "tbPassword";
        tbPassword.Size = new Size(167, 27);
        tbPassword.TabIndex = 3;
        // 
        // btnRegister
        // 
        btnRegister.Location = new Point(12, 144);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(248, 41);
        btnRegister.TabIndex = 4;
        btnRegister.Text = "Register";
        btnRegister.UseVisualStyleBackColor = true;
        btnRegister.Click += BtnRegister_Click;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(12, 114);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(46, 20);
        lblEmail.TabIndex = 6;
        lblEmail.Text = "Email";
        // 
        // tbEmail
        // 
        tbEmail.Location = new Point(93, 111);
        tbEmail.Name = "tbEmail";
        tbEmail.Size = new Size(167, 27);
        tbEmail.TabIndex = 7;
        // 
        // tbName
        // 
        tbName.Location = new Point(93, 78);
        tbName.Name = "tbName";
        tbName.Size = new Size(167, 27);
        tbName.TabIndex = 8;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(12, 81);
        lblName.Name = "lblName";
        lblName.Size = new Size(49, 20);
        lblName.TabIndex = 9;
        lblName.Text = "Name";
        // 
        // Register
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(282, 198);
        Controls.Add(lblName);
        Controls.Add(tbName);
        Controls.Add(tbEmail);
        Controls.Add(lblEmail);
        Controls.Add(btnRegister);
        Controls.Add(tbPassword);
        Controls.Add(tbUsername);
        Controls.Add(lblPassword);
        Controls.Add(lblUserName);
        Name = "Register";
        Text = "Register";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblUserName;
    private Label lblPassword;
    private TextBox tbUsername;
    private TextBox tbPassword;
    private Button btnRegister;
    private Label lblEmail;
    private TextBox tbEmail;
    private TextBox tbName;
    private Label lblName;
}
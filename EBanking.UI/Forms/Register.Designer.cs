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
        // lblUserName
        // 
        _lblUserName.AutoSize = true;
        _lblUserName.Location = new Point(12, 15);
        _lblUserName.Name = "lblUserName";
        _lblUserName.Size = new Size(75, 20);
        _lblUserName.TabIndex = 0;
        _lblUserName.Text = "Username";
        // 
        // lblPassword
        // 
        _lblPassword.AutoSize = true;
        _lblPassword.Location = new Point(12, 48);
        _lblPassword.Name = "lblPassword";
        _lblPassword.Size = new Size(70, 20);
        _lblPassword.TabIndex = 1;
        _lblPassword.Text = "Password";
        // 
        // tbUsername
        // 
        _tbUsername.Location = new Point(93, 12);
        _tbUsername.Name = "tbUsername";
        _tbUsername.Size = new Size(167, 27);
        _tbUsername.TabIndex = 2;
        // 
        // tbPassword
        // 
        _tbPassword.Location = new Point(93, 45);
        _tbPassword.Name = "tbPassword";
        _tbPassword.Size = new Size(167, 27);
        _tbPassword.TabIndex = 3;
        // 
        // btnRegister
        // 
        _btnRegister.Location = new Point(12, 144);
        _btnRegister.Name = "btnRegister";
        _btnRegister.Size = new Size(248, 41);
        _btnRegister.TabIndex = 4;
        _btnRegister.Text = "Register";
        _btnRegister.UseVisualStyleBackColor = true;
        _btnRegister.Click += BtnRegister_Click;
        // 
        // lblEmail
        // 
        _lblEmail.AutoSize = true;
        _lblEmail.Location = new Point(12, 114);
        _lblEmail.Name = "lblEmail";
        _lblEmail.Size = new Size(46, 20);
        _lblEmail.TabIndex = 6;
        _lblEmail.Text = "Email";
        // 
        // tbEmail
        // 
        _tbEmail.Location = new Point(93, 111);
        _tbEmail.Name = "tbEmail";
        _tbEmail.Size = new Size(167, 27);
        _tbEmail.TabIndex = 7;
        // 
        // tbName
        // 
        _tbName.Location = new Point(93, 78);
        _tbName.Name = "tbName";
        _tbName.Size = new Size(167, 27);
        _tbName.TabIndex = 8;
        // 
        // lblName
        // 
        _lblName.AutoSize = true;
        _lblName.Location = new Point(12, 81);
        _lblName.Name = "lblName";
        _lblName.Size = new Size(49, 20);
        _lblName.TabIndex = 9;
        _lblName.Text = "Name";
        // 
        // Register
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(282, 198);
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
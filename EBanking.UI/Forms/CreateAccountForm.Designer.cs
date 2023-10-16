namespace EBanking.UI.Forms;

partial class CreateAccount
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
        _lblName = new Label();
        _tbName = new TextBox();
        _btnOK = new Button();
        SuspendLayout();
        // 
        // _lblName
        // 
        _lblName.AutoSize = true;
        _lblName.Location = new Point(11, 15);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(49, 20);
        _lblName.TabIndex = 0;
        _lblName.Text = "Name";
        // 
        // _tbName
        // 
        _tbName.Location = new Point(67, 12);
        _tbName.Name = "_tbName";
        _tbName.Size = new Size(127, 27);
        _tbName.TabIndex = 0;
        // 
        // _btnOK
        // 
        _btnOK.Location = new Point(11, 45);
        _btnOK.Name = "_btnOK";
        _btnOK.Size = new Size(184, 29);
        _btnOK.TabIndex = 1;
        _btnOK.Text = "OK";
        _btnOK.UseVisualStyleBackColor = true;
        _btnOK.Click += BtnOK_Click;
        // 
        // CreateAccount
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(206, 85);
        Controls.Add(_btnOK);
        Controls.Add(_tbName);
        Controls.Add(_lblName);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "CreateAccount";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Create Account";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label _lblName;
    private TextBox _tbName;
    private Button _btnOK;
}
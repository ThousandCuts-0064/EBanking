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
        _lblName.Location = new Point(10, 11);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(39, 15);
        _lblName.TabIndex = 0;
        _lblName.Text = "Name";
        // 
        // _tbName
        // 
        _tbName.Location = new Point(59, 9);
        _tbName.Margin = new Padding(3, 2, 3, 2);
        _tbName.Name = "_tbName";
        _tbName.Size = new Size(112, 23);
        _tbName.TabIndex = 1;
        // 
        // _btnOK
        // 
        _btnOK.Location = new Point(10, 34);
        _btnOK.Margin = new Padding(3, 2, 3, 2);
        _btnOK.Name = "_btnOK";
        _btnOK.Size = new Size(161, 22);
        _btnOK.TabIndex = 2;
        _btnOK.Text = "OK";
        _btnOK.UseVisualStyleBackColor = true;
        _btnOK.Click += BtnOK_Click;
        // 
        // CreateAccount
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(180, 64);
        Controls.Add(_btnOK);
        Controls.Add(_tbName);
        Controls.Add(_lblName);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Margin = new Padding(3, 2, 3, 2);
        Name = "CreateAccount";
        Text = "Create Account";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label _lblName;
    private TextBox _tbName;
    private Button _btnOK;
}
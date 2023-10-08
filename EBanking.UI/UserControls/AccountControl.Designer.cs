namespace EBanking.UI.UserControls;

partial class AccountControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _lblName = new Label();
        _lblAmount = new Label();
        _lblKey = new Label();
        _lblNameValue = new Label();
        _lblAmountValue = new Label();
        _lblKeyValue = new Label();
        _tlp = new TableLayoutPanel();
        _tlp.SuspendLayout();
        SuspendLayout();
        // 
        // _lblName
        // 
        _lblName.AutoSize = true;
        _lblName.Dock = DockStyle.Fill;
        _lblName.Location = new Point(3, 0);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(69, 50);
        _lblName.TabIndex = 0;
        _lblName.Text = "Name";
        _lblName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _lblAmount
        // 
        _lblAmount.AutoSize = true;
        _lblAmount.Dock = DockStyle.Fill;
        _lblAmount.Location = new Point(3, 50);
        _lblAmount.Name = "_lblAmount";
        _lblAmount.Size = new Size(69, 50);
        _lblAmount.TabIndex = 1;
        _lblAmount.Text = "Amount";
        _lblAmount.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _lblKey
        // 
        _lblKey.AutoSize = true;
        _lblKey.Dock = DockStyle.Fill;
        _lblKey.Location = new Point(3, 100);
        _lblKey.Name = "_lblKey";
        _lblKey.Size = new Size(69, 50);
        _lblKey.TabIndex = 2;
        _lblKey.Text = "Key";
        _lblKey.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _lblNameValue
        // 
        _lblNameValue.AutoSize = true;
        _lblNameValue.Dock = DockStyle.Fill;
        _lblNameValue.Location = new Point(78, 0);
        _lblNameValue.Name = "_lblNameValue";
        _lblNameValue.Size = new Size(69, 50);
        _lblNameValue.TabIndex = 3;
        _lblNameValue.Text = "Value";
        _lblNameValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _lblAmountValue
        // 
        _lblAmountValue.AutoSize = true;
        _lblAmountValue.Dock = DockStyle.Fill;
        _lblAmountValue.Location = new Point(78, 50);
        _lblAmountValue.Name = "_lblAmountValue";
        _lblAmountValue.Size = new Size(69, 50);
        _lblAmountValue.TabIndex = 4;
        _lblAmountValue.Text = "Value";
        _lblAmountValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _lblKeyValue
        // 
        _lblKeyValue.AutoSize = true;
        _lblKeyValue.Dock = DockStyle.Fill;
        _lblKeyValue.Location = new Point(78, 100);
        _lblKeyValue.Name = "_lblKeyValue";
        _lblKeyValue.Size = new Size(69, 50);
        _lblKeyValue.TabIndex = 5;
        _lblKeyValue.Text = "Value";
        _lblKeyValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _tlp
        // 
        _tlp.AutoSize = true;
        _tlp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _tlp.ColumnCount = 2;
        _tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _tlp.Controls.Add(_lblName, 0, 0);
        _tlp.Controls.Add(_lblKeyValue, 1, 2);
        _tlp.Controls.Add(_lblAmount, 0, 1);
        _tlp.Controls.Add(_lblKey, 0, 2);
        _tlp.Controls.Add(_lblNameValue, 1, 0);
        _tlp.Controls.Add(_lblAmountValue, 1, 1);
        _tlp.Dock = DockStyle.Fill;
        _tlp.Location = new Point(0, 0);
        _tlp.Name = "_tlp";
        _tlp.RowCount = 3;
        _tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _tlp.Size = new Size(150, 150);
        _tlp.TabIndex = 6;
        // 
        // AccountControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        Controls.Add(_tlp);
        Name = "AccountControl";
        _tlp.ResumeLayout(false);
        _tlp.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label _lblName;
    private Label _lblAmount;
    private Label _lblKey;
    private Label _lblNameValue;
    private Label _lblAmountValue;
    private Label _lblKeyValue;
    private TableLayoutPanel _tlp;
}

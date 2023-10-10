namespace EBanking.UI.Forms;

partial class TransactionHistory
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
        _dgvMain = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)_dgvMain).BeginInit();
        SuspendLayout();
        // 
        // _dgvMain
        // 
        _dgvMain.AllowUserToAddRows = false;
        _dgvMain.AllowUserToDeleteRows = false;
        _dgvMain.AllowUserToResizeRows = false;
        _dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _dgvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        _dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _dgvMain.Dock = DockStyle.Fill;
        _dgvMain.Location = new Point(0, 0);
        _dgvMain.MultiSelect = false;
        _dgvMain.Name = "_dgvMain";
        _dgvMain.ReadOnly = true;
        _dgvMain.RowHeadersVisible = false;
        _dgvMain.RowHeadersWidth = 51;
        _dgvMain.RowTemplate.Height = 29;
        _dgvMain.RowTemplate.ReadOnly = true;
        _dgvMain.RowTemplate.Resizable = DataGridViewTriState.False;
        _dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;
        _dgvMain.Size = new Size(563, 308);
        _dgvMain.TabIndex = 0;
        _dgvMain.VirtualMode = true;
        // 
        // TransactionHistory
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(563, 308);
        Controls.Add(_dgvMain);
        Margin = new Padding(3, 4, 3, 4);
        Name = "TransactionHistory";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Transaction History";
        ((System.ComponentModel.ISupportInitialize)_dgvMain).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView _dgvMain;
}
namespace CentrumChlodnictwa
{
    partial class SklepyUstawieniaForm
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
            if(disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.mailDataGridView = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dodajSklepButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.zmienSklepButton = new System.Windows.Forms.Button();
            this.usunSklepButton = new System.Windows.Forms.Button();
            this.zmienMailButton = new System.Windows.Forms.Button();
            this.usunMailButton = new System.Windows.Forms.Button();
            this.dodajMailButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.archiwalneSklepyCB = new System.Windows.Forms.CheckBox();
            this.archiwalneMaileCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mailDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mailDataGridView
            // 
            this.mailDataGridView.AllowUserToAddRows = false;
            this.mailDataGridView.AllowUserToDeleteRows = false;
            this.mailDataGridView.AllowUserToResizeRows = false;
            this.mailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.mailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mailDataGridView.Location = new System.Drawing.Point(12, 12);
            this.mailDataGridView.Name = "mailDataGridView";
            this.mailDataGridView.RowHeadersVisible = false;
            this.mailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mailDataGridView.Size = new System.Drawing.Size(576, 315);
            this.mailDataGridView.TabIndex = 0;
            // 
            // dodajSklepButton
            // 
            this.dodajSklepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dodajSklepButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.dodaj;
            this.dodajSklepButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dodajSklepButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dodajSklepButton.Location = new System.Drawing.Point(12, 356);
            this.dodajSklepButton.Name = "dodajSklepButton";
            this.dodajSklepButton.Size = new System.Drawing.Size(32, 32);
            this.dodajSklepButton.TabIndex = 1;
            this.toolTip1.SetToolTip(this.dodajSklepButton, "Dodaj");
            this.dodajSklepButton.UseVisualStyleBackColor = true;
            this.dodajSklepButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.koniec_32x32;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(556, 356);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 32);
            this.closeButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.closeButton, "Zamknij");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // zmienSklepButton
            // 
            this.zmienSklepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zmienSklepButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.zmien;
            this.zmienSklepButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zmienSklepButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.zmienSklepButton.Enabled = false;
            this.zmienSklepButton.Location = new System.Drawing.Point(50, 356);
            this.zmienSklepButton.Name = "zmienSklepButton";
            this.zmienSklepButton.Size = new System.Drawing.Size(32, 32);
            this.zmienSklepButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.zmienSklepButton, "Zmień");
            this.zmienSklepButton.UseVisualStyleBackColor = true;
            this.zmienSklepButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // usunSklepButton
            // 
            this.usunSklepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.usunSklepButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.planowanieUsun_32x32;
            this.usunSklepButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usunSklepButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.usunSklepButton.Enabled = false;
            this.usunSklepButton.Location = new System.Drawing.Point(88, 356);
            this.usunSklepButton.Name = "usunSklepButton";
            this.usunSklepButton.Size = new System.Drawing.Size(32, 32);
            this.usunSklepButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.usunSklepButton, "Usuń");
            this.usunSklepButton.UseVisualStyleBackColor = true;
            this.usunSklepButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // zmienMailButton
            // 
            this.zmienMailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zmienMailButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.zmien;
            this.zmienMailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zmienMailButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.zmienMailButton.Enabled = false;
            this.zmienMailButton.Location = new System.Drawing.Point(364, 356);
            this.zmienMailButton.Name = "zmienMailButton";
            this.zmienMailButton.Size = new System.Drawing.Size(32, 32);
            this.zmienMailButton.TabIndex = 9;
            this.toolTip1.SetToolTip(this.zmienMailButton, "Zmień");
            this.zmienMailButton.UseVisualStyleBackColor = true;
            this.zmienMailButton.Click += new System.EventHandler(this.zmienMailButton_Click);
            // 
            // usunMailButton
            // 
            this.usunMailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.usunMailButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.planowanieUsun_32x32;
            this.usunMailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usunMailButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.usunMailButton.Enabled = false;
            this.usunMailButton.Location = new System.Drawing.Point(402, 356);
            this.usunMailButton.Name = "usunMailButton";
            this.usunMailButton.Size = new System.Drawing.Size(32, 32);
            this.usunMailButton.TabIndex = 10;
            this.toolTip1.SetToolTip(this.usunMailButton, "Usuń");
            this.usunMailButton.UseVisualStyleBackColor = true;
            this.usunMailButton.Click += new System.EventHandler(this.usunMailButton_Click);
            // 
            // dodajMailButton
            // 
            this.dodajMailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dodajMailButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.dodaj;
            this.dodajMailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dodajMailButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dodajMailButton.Location = new System.Drawing.Point(326, 356);
            this.dodajMailButton.Name = "dodajMailButton";
            this.dodajMailButton.Size = new System.Drawing.Size(32, 32);
            this.dodajMailButton.TabIndex = 8;
            this.toolTip1.SetToolTip(this.dodajMailButton, "Dodaj");
            this.dodajMailButton.UseVisualStyleBackColor = true;
            this.dodajMailButton.Click += new System.EventHandler(this.dodajMailButton_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.file_open;
            this.importButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.importButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.importButton.Location = new System.Drawing.Point(518, 356);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(32, 32);
            this.importButton.TabIndex = 11;
            this.toolTip1.SetToolTip(this.importButton, "Importuj adresy");
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // archiwalneSklepyCB
            // 
            this.archiwalneSklepyCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.archiwalneSklepyCB.AutoSize = true;
            this.archiwalneSklepyCB.Location = new System.Drawing.Point(12, 333);
            this.archiwalneSklepyCB.Name = "archiwalneSklepyCB";
            this.archiwalneSklepyCB.Size = new System.Drawing.Size(143, 17);
            this.archiwalneSklepyCB.TabIndex = 6;
            this.archiwalneSklepyCB.Text = "Pokaż archiwalne sklepy";
            this.archiwalneSklepyCB.UseVisualStyleBackColor = true;
            this.archiwalneSklepyCB.CheckedChanged += new System.EventHandler(this.archiwalneCB_CheckedChanged);
            // 
            // archiwalneMaileCB
            // 
            this.archiwalneMaileCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.archiwalneMaileCB.AutoSize = true;
            this.archiwalneMaileCB.Location = new System.Drawing.Point(326, 333);
            this.archiwalneMaileCB.Name = "archiwalneMaileCB";
            this.archiwalneMaileCB.Size = new System.Drawing.Size(171, 17);
            this.archiwalneMaileCB.TabIndex = 7;
            this.archiwalneMaileCB.Text = "Pokaż archiwalne adresy email";
            this.archiwalneMaileCB.UseVisualStyleBackColor = true;
            this.archiwalneMaileCB.CheckedChanged += new System.EventHandler(this.archiwalneMaileCB_CheckedChanged);
            // 
            // SklepyUstawieniaForm
            // 
            this.AcceptButton = this.dodajSklepButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.zmienMailButton);
            this.Controls.Add(this.usunMailButton);
            this.Controls.Add(this.dodajMailButton);
            this.Controls.Add(this.archiwalneMaileCB);
            this.Controls.Add(this.archiwalneSklepyCB);
            this.Controls.Add(this.zmienSklepButton);
            this.Controls.Add(this.usunSklepButton);
            this.Controls.Add(this.dodajSklepButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.mailDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SklepyUstawieniaForm";
            this.Text = "Ustawienia e-mail";
            this.Shown += new System.EventHandler(this.SklepyUstawieniaForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.mailDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mailDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button dodajSklepButton;
        private System.Windows.Forms.Button usunSklepButton;
        private System.Windows.Forms.Button zmienSklepButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox archiwalneSklepyCB;
        private System.Windows.Forms.CheckBox archiwalneMaileCB;
        private System.Windows.Forms.Button zmienMailButton;
        private System.Windows.Forms.Button usunMailButton;
        private System.Windows.Forms.Button dodajMailButton;
        private System.Windows.Forms.Button importButton;
    }
}
namespace CentrumChlodnictwa
{
    partial class LoadDataForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataOdczytuLabel = new System.Windows.Forms.Label();
            this.nazwaSklepuLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.savePDFButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(576, 338);
            this.dataGridView.TabIndex = 1;
            // 
            // dataOdczytuLabel
            // 
            this.dataOdczytuLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataOdczytuLabel.AutoSize = true;
            this.dataOdczytuLabel.Location = new System.Drawing.Point(12, 356);
            this.dataOdczytuLabel.Name = "dataOdczytuLabel";
            this.dataOdczytuLabel.Size = new System.Drawing.Size(73, 13);
            this.dataOdczytuLabel.TabIndex = 4;
            this.dataOdczytuLabel.Text = "Data odczytu:";
            this.dataOdczytuLabel.Click += new System.EventHandler(this.dataOdczytuLabel_Click);
            // 
            // nazwaSklepuLabel
            // 
            this.nazwaSklepuLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nazwaSklepuLabel.AutoSize = true;
            this.nazwaSklepuLabel.Location = new System.Drawing.Point(12, 378);
            this.nazwaSklepuLabel.Name = "nazwaSklepuLabel";
            this.nazwaSklepuLabel.Size = new System.Drawing.Size(37, 13);
            this.nazwaSklepuLabel.TabIndex = 5;
            this.nazwaSklepuLabel.Text = "Sklep:";
            this.nazwaSklepuLabel.Click += new System.EventHandler(this.nazwaSklepuLabel_Click);
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
            this.closeButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.closeButton, "Zamknij/Anuluj");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // savePDFButton
            // 
            this.savePDFButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePDFButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.pdf;
            this.savePDFButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.savePDFButton.Enabled = false;
            this.savePDFButton.Location = new System.Drawing.Point(480, 356);
            this.savePDFButton.Name = "savePDFButton";
            this.savePDFButton.Size = new System.Drawing.Size(32, 32);
            this.savePDFButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.savePDFButton, "Zapisz PDF");
            this.savePDFButton.UseVisualStyleBackColor = true;
            this.savePDFButton.Click += new System.EventHandler(this.savePDFButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.zapisz_32x32;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(442, 356);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(32, 32);
            this.saveButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.saveButton, "Zapisz");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.mail_32x32;
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(518, 356);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(32, 32);
            this.sendButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.sendButton, "Wyślij");
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.file_open;
            this.loadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.loadButton.Location = new System.Drawing.Point(404, 356);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(32, 32);
            this.loadButton.TabIndex = 0;
            this.toolTip1.SetToolTip(this.loadButton, "Wczytaj");
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // LoadDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.savePDFButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nazwaSklepuLabel);
            this.Controls.Add(this.dataOdczytuLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.loadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadDataForm";
            this.Text = "Dane z urządzenia";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label dataOdczytuLabel;
        private System.Windows.Forms.Label nazwaSklepuLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button savePDFButton;
    }
}
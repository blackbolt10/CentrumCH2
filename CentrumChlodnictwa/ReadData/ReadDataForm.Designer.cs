namespace CentrumChlodnictwa
{
    partial class ReadDataForm
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
            this.nazwaSklepuLabel = new System.Windows.Forms.Label();
            this.dataOdczytuLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sendingFormButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nazwaSklepuLabel
            // 
            this.nazwaSklepuLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nazwaSklepuLabel.AutoSize = true;
            this.nazwaSklepuLabel.Location = new System.Drawing.Point(12, 377);
            this.nazwaSklepuLabel.Name = "nazwaSklepuLabel";
            this.nazwaSklepuLabel.Size = new System.Drawing.Size(37, 13);
            this.nazwaSklepuLabel.TabIndex = 20;
            this.nazwaSklepuLabel.Text = "Sklep:";
            // 
            // dataOdczytuLabel
            // 
            this.dataOdczytuLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataOdczytuLabel.AutoSize = true;
            this.dataOdczytuLabel.Location = new System.Drawing.Point(12, 355);
            this.dataOdczytuLabel.Name = "dataOdczytuLabel";
            this.dataOdczytuLabel.Size = new System.Drawing.Size(73, 13);
            this.dataOdczytuLabel.TabIndex = 19;
            this.dataOdczytuLabel.Text = "Data odczytu:";
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
            this.dataGridView.Location = new System.Drawing.Point(12, 10);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(576, 338);
            this.dataGridView.TabIndex = 15;
            // 
            // sendingFormButton
            // 
            this.sendingFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendingFormButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.send;
            this.sendingFormButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendingFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sendingFormButton.Enabled = false;
            this.sendingFormButton.Location = new System.Drawing.Point(518, 355);
            this.sendingFormButton.Name = "sendingFormButton";
            this.sendingFormButton.Size = new System.Drawing.Size(32, 32);
            this.sendingFormButton.TabIndex = 21;
            this.sendingFormButton.UseVisualStyleBackColor = true;
            this.sendingFormButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.koniec_32x32;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(556, 355);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 32);
            this.closeButton.TabIndex = 18;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.file_open;
            this.loadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.loadButton.Location = new System.Drawing.Point(480, 355);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(32, 32);
            this.loadButton.TabIndex = 16;
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // ReadDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.sendingFormButton);
            this.Controls.Add(this.nazwaSklepuLabel);
            this.Controls.Add(this.dataOdczytuLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReadDataForm";
            this.Text = "Dane z urządzenia";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sendingFormButton;
        private System.Windows.Forms.Label nazwaSklepuLabel;
        private System.Windows.Forms.Label dataOdczytuLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}
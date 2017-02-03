namespace CentrumChlodnictwa
{
    partial class UrzadzeniaUstawieniaForm
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
            this.sklepCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.delButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.tempDataGridView = new System.Windows.Forms.DataGridView();
            this.archiwalneCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tempDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sklepCB
            // 
            this.sklepCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sklepCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sklepCB.FormattingEnabled = true;
            this.sklepCB.Location = new System.Drawing.Point(94, 363);
            this.sklepCB.Name = "sklepCB";
            this.sklepCB.Size = new System.Drawing.Size(200, 21);
            this.sklepCB.TabIndex = 0;
            this.sklepCB.SelectedIndexChanged += new System.EventHandler(this.sklepCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wybierz sklep:";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.koniec_32x32;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.Location = new System.Drawing.Point(556, 356);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 32);
            this.closeButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.closeButton, "Wyjście");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // delButton
            // 
            this.delButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.planowanieUsun_32x32;
            this.delButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delButton.Enabled = false;
            this.delButton.Location = new System.Drawing.Point(518, 356);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(32, 32);
            this.delButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.delButton, "Usuń");
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.dodaj;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Location = new System.Drawing.Point(442, 356);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 32);
            this.addButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.addButton, "Dodaj");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // modButton
            // 
            this.modButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.modButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.zmien;
            this.modButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.modButton.Enabled = false;
            this.modButton.Location = new System.Drawing.Point(480, 356);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(32, 32);
            this.modButton.TabIndex = 8;
            this.toolTip1.SetToolTip(this.modButton, "Zmień");
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // tempDataGridView
            // 
            this.tempDataGridView.AllowUserToAddRows = false;
            this.tempDataGridView.AllowUserToDeleteRows = false;
            this.tempDataGridView.AllowUserToResizeRows = false;
            this.tempDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tempDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tempDataGridView.Location = new System.Drawing.Point(15, 12);
            this.tempDataGridView.MultiSelect = false;
            this.tempDataGridView.Name = "tempDataGridView";
            this.tempDataGridView.RowHeadersVisible = false;
            this.tempDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tempDataGridView.Size = new System.Drawing.Size(573, 338);
            this.tempDataGridView.TabIndex = 6;
            // 
            // archiwalneCB
            // 
            this.archiwalneCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.archiwalneCB.AutoSize = true;
            this.archiwalneCB.Location = new System.Drawing.Point(300, 365);
            this.archiwalneCB.Name = "archiwalneCB";
            this.archiwalneCB.Size = new System.Drawing.Size(110, 17);
            this.archiwalneCB.TabIndex = 9;
            this.archiwalneCB.Text = "Pokaż archiwalne";
            this.archiwalneCB.UseVisualStyleBackColor = true;
            this.archiwalneCB.CheckedChanged += new System.EventHandler(this.archiwalneCB_CheckedChanged);
            // 
            // UrzadzeniaUstawieniaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.archiwalneCB);
            this.Controls.Add(this.modButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.tempDataGridView);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sklepCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UrzadzeniaUstawieniaForm";
            this.Text = "UrzadzeniaUstawieniaForm";
            this.Shown += new System.EventHandler(this.UrzadzeniaUstawieniaForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tempDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sklepCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.DataGridView tempDataGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.CheckBox archiwalneCB;
    }
}
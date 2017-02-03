namespace CentrumChlodnictwa
{
    partial class SklepyMailDodawanieForm
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
            this.sklepCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nazwaLabel = new System.Windows.Forms.Label();
            this.archiwalnyCB = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.mailLabel = new System.Windows.Forms.Label();
            this.nazwaCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // sklepCB
            // 
            this.sklepCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sklepCB.FormattingEnabled = true;
            this.sklepCB.Location = new System.Drawing.Point(55, 12);
            this.sklepCB.Name = "sklepCB";
            this.sklepCB.Size = new System.Drawing.Size(217, 21);
            this.sklepCB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sklep:";
            // 
            // nazwaLabel
            // 
            this.nazwaLabel.AutoSize = true;
            this.nazwaLabel.Location = new System.Drawing.Point(12, 42);
            this.nazwaLabel.Name = "nazwaLabel";
            this.nazwaLabel.Size = new System.Drawing.Size(31, 13);
            this.nazwaLabel.TabIndex = 2;
            this.nazwaLabel.Text = "Opis:";
            // 
            // archiwalnyCB
            // 
            this.archiwalnyCB.AutoSize = true;
            this.archiwalnyCB.Location = new System.Drawing.Point(12, 95);
            this.archiwalnyCB.Name = "archiwalnyCB";
            this.archiwalnyCB.Size = new System.Drawing.Size(77, 17);
            this.archiwalnyCB.TabIndex = 3;
            this.archiwalnyCB.Text = "Archiwalny";
            this.archiwalnyCB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(197, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "&Anuluj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.Location = new System.Drawing.Point(116, 91);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(75, 23);
            this.zapiszButton.TabIndex = 4;
            this.zapiszButton.Text = "&Zapisz";
            this.zapiszButton.UseVisualStyleBackColor = true;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(55, 65);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(217, 20);
            this.emailTB.TabIndex = 2;
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.Location = new System.Drawing.Point(12, 68);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(35, 13);
            this.mailLabel.TabIndex = 7;
            this.mailLabel.Text = "E-mail";
            // 
            // nazwaCB
            // 
            this.nazwaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nazwaCB.FormattingEnabled = true;
            this.nazwaCB.Items.AddRange(new object[] {
            "Biuro",
            "Centrala",
            "Sklep"});
            this.nazwaCB.Location = new System.Drawing.Point(55, 39);
            this.nazwaCB.Name = "nazwaCB";
            this.nazwaCB.Size = new System.Drawing.Size(217, 21);
            this.nazwaCB.TabIndex = 1;
            // 
            // SklepyMailDodawanieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(284, 124);
            this.Controls.Add(this.nazwaCB);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.archiwalnyCB);
            this.Controls.Add(this.nazwaLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sklepCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SklepyMailDodawanieForm";
            this.Text = "Nowy adres e-mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sklepCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nazwaLabel;
        private System.Windows.Forms.CheckBox archiwalnyCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.ComboBox nazwaCB;
    }
}
namespace CentrumChlodnictwa
{
    partial class UrzadzeniaDodawanieForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nazwaTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tempMaxTB = new System.Windows.Forms.TextBox();
            this.tempMinTB = new System.Windows.Forms.TextBox();
            this.modulTB = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.sklepCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.archiwalnyCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Moduł:";
            // 
            // nazwaTB
            // 
            this.nazwaTB.Location = new System.Drawing.Point(61, 39);
            this.nazwaTB.Name = "nazwaTB";
            this.nazwaTB.Size = new System.Drawing.Size(161, 20);
            this.nazwaTB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Temperatura min:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Temperatura max:";
            // 
            // tempMaxTB
            // 
            this.tempMaxTB.Location = new System.Drawing.Point(109, 117);
            this.tempMaxTB.Name = "tempMaxTB";
            this.tempMaxTB.Size = new System.Drawing.Size(113, 20);
            this.tempMaxTB.TabIndex = 4;
            this.tempMaxTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlyDecimalTextBox_KeyPress);
            // 
            // tempMinTB
            // 
            this.tempMinTB.Location = new System.Drawing.Point(109, 91);
            this.tempMinTB.Name = "tempMinTB";
            this.tempMinTB.Size = new System.Drawing.Size(113, 20);
            this.tempMinTB.TabIndex = 3;
            this.tempMinTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlyDecimalTextBox_KeyPress);
            // 
            // modulTB
            // 
            this.modulTB.Location = new System.Drawing.Point(61, 65);
            this.modulTB.Name = "modulTB";
            this.modulTB.Size = new System.Drawing.Size(161, 20);
            this.modulTB.TabIndex = 2;
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(147, 166);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "&Zamknij";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // sklepCB
            // 
            this.sklepCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sklepCB.FormattingEnabled = true;
            this.sklepCB.Location = new System.Drawing.Point(61, 12);
            this.sklepCB.Name = "sklepCB";
            this.sklepCB.Size = new System.Drawing.Size(161, 21);
            this.sklepCB.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sklep:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(61, 166);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // archiwalnyCB
            // 
            this.archiwalnyCB.AutoSize = true;
            this.archiwalnyCB.Location = new System.Drawing.Point(17, 143);
            this.archiwalnyCB.Name = "archiwalnyCB";
            this.archiwalnyCB.Size = new System.Drawing.Size(77, 17);
            this.archiwalnyCB.TabIndex = 5;
            this.archiwalnyCB.Text = "Archiwalny";
            this.archiwalnyCB.UseVisualStyleBackColor = true;
            // 
            // UrzadzeniaDodawanieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(229, 197);
            this.Controls.Add(this.archiwalnyCB);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sklepCB);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.modulTB);
            this.Controls.Add(this.tempMinTB);
            this.Controls.Add(this.tempMaxTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nazwaTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrzadzeniaDodawanieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nowe urządzenie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazwaTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tempMaxTB;
        private System.Windows.Forms.TextBox tempMinTB;
        private System.Windows.Forms.TextBox modulTB;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox sklepCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox archiwalnyCB;
    }
}
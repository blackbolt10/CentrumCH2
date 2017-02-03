namespace CentrumChlodnictwa
{
    partial class WysylanieDanychForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.sklepLabel = new System.Windows.Forms.Label();
            this.mailCLB = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cancelButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.formatCB = new System.Windows.Forms.ComboBox();
            this.zalacznikRB = new System.Windows.Forms.RadioButton();
            this.trescRB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.opisTSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.rapTempCB = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sklep:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(302, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data:";
            // 
            // dataLabel
            // 
            this.dataLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLabel.AutoSize = true;
            this.dataLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataLabel.Location = new System.Drawing.Point(347, 9);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(90, 16);
            this.dataLabel.TabIndex = 2;
            this.dataLabel.Text = "00.00.0000r.";
            this.toolTip1.SetToolTip(this.dataLabel, "Data wczytanego pliku");
            // 
            // sklepLabel
            // 
            this.sklepLabel.AutoSize = true;
            this.sklepLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sklepLabel.Location = new System.Drawing.Point(62, 9);
            this.sklepLabel.Name = "sklepLabel";
            this.sklepLabel.Size = new System.Drawing.Size(84, 16);
            this.sklepLabel.TabIndex = 3;
            this.sklepLabel.Text = "TuJestSklep";
            this.toolTip1.SetToolTip(this.sklepLabel, "Nazwa sklepu");
            // 
            // mailCLB
            // 
            this.mailCLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mailCLB.CheckOnClick = true;
            this.mailCLB.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.mailCLB.FormattingEnabled = true;
            this.mailCLB.Location = new System.Drawing.Point(12, 53);
            this.mailCLB.Name = "mailCLB";
            this.mailCLB.Size = new System.Drawing.Size(200, 184);
            this.mailCLB.TabIndex = 4;
            this.toolTip1.SetToolTip(this.mailCLB, "Wybierz adresy e-mail, na które ma zostać wysłany raport");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wybierz e-mail:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.koniec_32x32;
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(405, 228);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(32, 32);
            this.cancelButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cancelButton, "Zamknij");
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.BackgroundImage = global::CentrumChlodnictwa.Properties.Resources.mail_32x32;
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendButton.Location = new System.Drawing.Point(367, 228);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(32, 32);
            this.sendButton.TabIndex = 14;
            this.toolTip1.SetToolTip(this.sendButton, "Wyslij e-mail");
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // formatCB
            // 
            this.formatCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatCB.FormattingEnabled = true;
            this.formatCB.Items.AddRange(new object[] {
            ".pdf",
            ".html"});
            this.formatCB.Location = new System.Drawing.Point(371, 80);
            this.formatCB.Name = "formatCB";
            this.formatCB.Size = new System.Drawing.Size(66, 21);
            this.formatCB.TabIndex = 7;
            // 
            // zalacznikRB
            // 
            this.zalacznikRB.AutoSize = true;
            this.zalacznikRB.Checked = true;
            this.zalacznikRB.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.zalacznikRB.Location = new System.Drawing.Point(218, 79);
            this.zalacznikRB.Name = "zalacznikRB";
            this.zalacznikRB.Size = new System.Drawing.Size(147, 20);
            this.zalacznikRB.TabIndex = 9;
            this.zalacznikRB.TabStop = true;
            this.zalacznikRB.Text = "Załącznik w formacie";
            this.zalacznikRB.UseVisualStyleBackColor = true;
            // 
            // trescRB
            // 
            this.trescRB.AutoSize = true;
            this.trescRB.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.trescRB.Location = new System.Drawing.Point(218, 53);
            this.trescRB.Name = "trescRB";
            this.trescRB.Size = new System.Drawing.Size(144, 20);
            this.trescRB.TabIndex = 10;
            this.trescRB.Text = "W treści wiadomości";
            this.trescRB.UseVisualStyleBackColor = true;
            this.trescRB.CheckedChanged += new System.EventHandler(this.trescRB_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(218, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Format raportu:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.opisTSSL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 263);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(449, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 10;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // opisTSSL
            // 
            this.opisTSSL.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.opisTSSL.Name = "opisTSSL";
            this.opisTSSL.Size = new System.Drawing.Size(81, 17);
            this.opisTSSL.Text = "OpisOperacji";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // rapTempCB
            // 
            this.rapTempCB.AutoSize = true;
            this.rapTempCB.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.rapTempCB.Location = new System.Drawing.Point(218, 107);
            this.rapTempCB.Name = "rapTempCB";
            this.rapTempCB.Size = new System.Drawing.Size(172, 20);
            this.rapTempCB.TabIndex = 15;
            this.rapTempCB.Text = "Dołącz raport temperatur";
            this.rapTempCB.UseVisualStyleBackColor = true;
            // 
            // WysylanieDanychForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(449, 285);
            this.Controls.Add(this.rapTempCB);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trescRB);
            this.Controls.Add(this.zalacznikRB);
            this.Controls.Add(this.formatCB);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mailCLB);
            this.Controls.Add(this.sklepLabel);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WysylanieDanychForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wysyłanie raportu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WysylanieDanychForm_FormClosing);
            this.Shown += new System.EventHandler(this.WysylanieDanychForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.Label sklepLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckedListBox mailCLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox formatCB;
        private System.Windows.Forms.RadioButton zalacznikRB;
        private System.Windows.Forms.RadioButton trescRB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel opisTSSL;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox rapTempCB;
    }
}
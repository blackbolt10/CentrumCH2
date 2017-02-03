namespace CentrumChlodnictwa
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.formListCB = new System.Windows.Forms.ComboBox();
            this.changeFormLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.versionToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadDataRibbonButton = new System.Windows.Forms.RibbonButton();
            this.readDataRibbonButton = new System.Windows.Forms.RibbonButton();
            this.sklepyRibbonButton = new System.Windows.Forms.RibbonButton();
            this.urzadzeniaRibbonButton = new System.Windows.Forms.RibbonButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.BorderMode = System.Windows.Forms.RibbonWindowMode.InsideWindow;
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "CH";
            this.ribbon1.OrbVisible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(734, 150);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "System";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.loadDataRibbonButton);
            this.ribbonPanel1.Items.Add(this.readDataRibbonButton);
            this.ribbonPanel1.Text = "Dane";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Text = "Ustawienia";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.sklepyRibbonButton);
            this.ribbonPanel2.Items.Add(this.urzadzeniaRibbonButton);
            this.ribbonPanel2.Text = "Konfiguracja";
            // 
            // formListCB
            // 
            this.formListCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formListCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formListCB.FormattingEnabled = true;
            this.formListCB.Location = new System.Drawing.Point(559, 0);
            this.formListCB.Name = "formListCB";
            this.formListCB.Size = new System.Drawing.Size(175, 21);
            this.formListCB.TabIndex = 3;
            // 
            // changeFormLabel
            // 
            this.changeFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeFormLabel.AutoSize = true;
            this.changeFormLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.changeFormLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.changeFormLabel.Location = new System.Drawing.Point(487, 3);
            this.changeFormLabel.Name = "changeFormLabel";
            this.changeFormLabel.Size = new System.Drawing.Size(66, 13);
            this.changeFormLabel.TabIndex = 4;
            this.changeFormLabel.Text = "Zmień okno:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // versionToolStripStatusLabel1
            // 
            this.versionToolStripStatusLabel1.Name = "versionToolStripStatusLabel1";
            this.versionToolStripStatusLabel1.Size = new System.Drawing.Size(143, 17);
            this.versionToolStripStatusLabel1.Text = "TU ZNAJDUJE SIĘ WERSJA";
            // 
            // loadDataRibbonButton
            // 
            this.loadDataRibbonButton.Enabled = false;
            this.loadDataRibbonButton.Image = global::CentrumChlodnictwa.Properties.Resources.Grey_gradient;
            this.loadDataRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("loadDataRibbonButton.SmallImage")));
            this.loadDataRibbonButton.Text = "Wczytaj dane";
            this.loadDataRibbonButton.Click += new System.EventHandler(this.loadDataRibbonButton_Click);
            // 
            // readDataRibbonButton
            // 
            this.readDataRibbonButton.Image = global::CentrumChlodnictwa.Properties.Resources.Grey_gradient;
            this.readDataRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("readDataRibbonButton.SmallImage")));
            this.readDataRibbonButton.Text = "Wczytaj dane(BD)";
            this.readDataRibbonButton.Click += new System.EventHandler(this.readDataRibbonButton_Click);
            // 
            // sklepyRibbonButton
            // 
            this.sklepyRibbonButton.Image = global::CentrumChlodnictwa.Properties.Resources.Grey_gradient;
            this.sklepyRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("sklepyRibbonButton.SmallImage")));
            this.sklepyRibbonButton.Text = "Sklepy";
            this.sklepyRibbonButton.Click += new System.EventHandler(this.sklepyRibbonButton_Click);
            // 
            // urzadzeniaRibbonButton
            // 
            this.urzadzeniaRibbonButton.Image = global::CentrumChlodnictwa.Properties.Resources.Grey_gradient;
            this.urzadzeniaRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("urzadzeniaRibbonButton.SmallImage")));
            this.urzadzeniaRibbonButton.Text = "Urządzenia";
            this.urzadzeniaRibbonButton.Click += new System.EventHandler(this.urzadzeniaRibbonButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.changeFormLabel);
            this.Controls.Add(this.formListCB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centrum Chłodnictwa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton sklepyRibbonButton;
        private System.Windows.Forms.RibbonButton urzadzeniaRibbonButton;
        private System.Windows.Forms.RibbonButton loadDataRibbonButton;
        private System.Windows.Forms.RibbonButton readDataRibbonButton;
        private System.Windows.Forms.ComboBox formListCB;
        private System.Windows.Forms.Label changeFormLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel versionToolStripStatusLabel1;
    }
}


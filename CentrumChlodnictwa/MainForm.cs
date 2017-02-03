using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentrumChlodnictwa
{
    public partial class MainForm : Form
    { 
        private String sciezkaRejestru = "Software\\Galsoft\\Centrum_Chlodnictwa\\GlowneOkno";

        private List<Form> mdiChildFormList = new List<Form>();
        LoadDataForm loadDataForm;
        SklepyUstawieniaForm SklepyUstawieniaForm;
        UrzadzeniaUstawieniaForm UrzadzeniaUstawieniaForm;
        ReadDataForm ReadDataForm;


        public MainForm()
        {
            InitializeComponent();

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.versionToolStripStatusLabel1.Text = String.Format("Wersja {0}", version);

            aktualizujListeMdiChild();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DBRepository db = new DBRepository("polacz");

            if(!db.ConnectDataBase())
            {
                MessageBox.Show("Wystąpił błąd połączenia z bazą danych. Program zostanie zamknięty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

                SetDesktopLocation(Convert.ToInt16(key.GetValue("Location.X", Location.X.ToString())), Convert.ToInt16(key.GetValue("Location.Y", Location.Y.ToString())));
                Size = new Size(Convert.ToInt16(key.GetValue("Size.Width", Size.Width.ToString())), Convert.ToInt16(key.GetValue("Size.Height", Size.Height.ToString())));

                key.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

            if(WindowState != FormWindowState.Minimized)
            {
                key.SetValue("Location.X", Location.X.ToString());
                key.SetValue("Location.Y", Location.Y.ToString());

                // this.Size.Height .Width
                key.SetValue("Size.Width", Size.Width.ToString());
                key.SetValue("Size.Height", Size.Height.ToString());
            }
            key.Close();
        }
        public static void raportBledu(String modul, String blad)
        {
            blad = blad.Replace('\'', '*');
            String nazwaKompOper = Environment.MachineName + "\\" + Environment.UserName;
            DateTime dataKomp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

            try
            {
                DBRepository db = new DBRepository();
                String zapytanieString = "insert into GAL.Bledy values('" + dataKomp + "', '" + modul + "', '" + blad + "', '" + nazwaKompOper + "')";
                db.query(zapytanieString);
            }
            catch(Exception) { }
        }

        private void mdiChild_Activate(object sender, EventArgs e)
        {
            Form form = (Form)sender;

            if(mdiChildFormList.Contains(form))
            {
                mdiChildFormList.Remove(form);
            }

            mdiChildFormList.Add(form);
            aktualizujListeMdiChild();
        }

        private void mdiChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = (Form)sender;

            if(mdiChildFormList.Contains(form))
            {
                mdiChildFormList.Remove(form);
            }

            aktualizujListeMdiChild();
        }

        private void mdiChild_FormClosed(object sender, System.EventArgs e)
        {
            aktualizujListeMdiChild();
        }

        private void aktualizujListeMdiChild()
        {
            formListCB.Items.Clear();

            for(int i = 0; i < mdiChildFormList.Count; i++)
            {
                formListCB.Items.Add(mdiChildFormList[i].Text);
            }

            if(formListCB.Items.Count > 0)
            {
                mdiChildFormList[mdiChildFormList.Count - 1].Activate();
                formListCB.SelectedIndex = formListCB.Items.Count - 1;

                changeFormLabel.Visible = true;
                formListCB.Visible = true;
            }
            else
            {
                changeFormLabel.Visible = false;
                formListCB.Visible = false;
            }
        }

        private void loadDataRibbonButton_Click(object sender, EventArgs e)
        {
            if(loadDataForm == null || loadDataForm.IsDisposed)
            {
                loadDataForm = new LoadDataForm();
                loadDataForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                loadDataForm.Shown += new System.EventHandler(mdiChild_Activate);
                loadDataForm.MdiParent = this;
                loadDataForm.Dock = DockStyle.Fill;
                loadDataForm.Show();
            }
            else
            {
                loadDataForm.Activate();
            }
        }

        private void sklepyRibbonButton_Click(object sender, EventArgs e)
        {
            if(SklepyUstawieniaForm == null || SklepyUstawieniaForm.IsDisposed)
            {
                SklepyUstawieniaForm = new SklepyUstawieniaForm();
                SklepyUstawieniaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                SklepyUstawieniaForm.Shown += new System.EventHandler(mdiChild_Activate);
                SklepyUstawieniaForm.MdiParent = this;
                SklepyUstawieniaForm.Dock = DockStyle.Fill;
                SklepyUstawieniaForm.Show();
            }
            else
            {
                SklepyUstawieniaForm.Activate();
            }
        }

        private void urzadzeniaRibbonButton_Click(object sender, EventArgs e)
        {
            if(UrzadzeniaUstawieniaForm == null || UrzadzeniaUstawieniaForm.IsDisposed)
            {
                UrzadzeniaUstawieniaForm = new UrzadzeniaUstawieniaForm();
                UrzadzeniaUstawieniaForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                UrzadzeniaUstawieniaForm.Shown += new System.EventHandler(mdiChild_Activate);
                UrzadzeniaUstawieniaForm.MdiParent = this;
                UrzadzeniaUstawieniaForm.Dock = DockStyle.Fill;
                UrzadzeniaUstawieniaForm.Show();
            }
            else
            {
                UrzadzeniaUstawieniaForm.Activate();
            }
        }

        private void readDataRibbonButton_Click(object sender, EventArgs e)
        {
            if(ReadDataForm == null || ReadDataForm.IsDisposed)
            {
                ReadDataForm = new ReadDataForm();
                ReadDataForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(mdiChild_FormClosing);
                ReadDataForm.Shown += new System.EventHandler(mdiChild_Activate);
                ReadDataForm.MdiParent = this;
                ReadDataForm.Dock = DockStyle.Fill;
                ReadDataForm.Show();
            }
            else
            {
                ReadDataForm.Activate();
            }
        }
    }
}

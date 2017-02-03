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
    public partial class SklepyUstawieniaForm : Form
    {
        public SklepyUstawieniaForm()
        {
            InitializeComponent();
        }

        private void SklepyUstawieniaForm_Shown(object sender, EventArgs e)
        {
            ZaladujMailDataGridView();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //zamknięcie aktywnego okna
        {
            if(keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ZaladujMailDataGridView()
        {
            mailDataGridView.DataSource = null;
            mailDataGridView.Rows.Clear();
            mailDataGridView.Columns.Clear();
            delButton.Enabled = false;
            changeButton.Enabled = false;

            DBRepository db = new DBRepository();
            DataTable pomDataTable = db.SklepyUstawienia_ZaladujMailDatagridView(archiwalneCB.Checked);

            if(pomDataTable.Rows.Count > 0)
            {
                delButton.Enabled = true;
                changeButton.Enabled = true;
                mailDataGridView.DataSource = pomDataTable;
                mailDataGridView.Columns["Sklep_ID"].Visible = false;
                mailDataGridView.Columns["Sklep_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                mailDataGridView.Columns["Sklep_Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                mailDataGridView.Columns["Sklep_CentralaEmail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                mailDataGridView.Columns["Sklep_Archiwalny"].Visible = false;

                mailDataGridView.CurrentCell = mailDataGridView.Rows[0].Cells["Sklep_Nazwa"];
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if(mailDataGridView.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno skasować wiersz '" + mailDataGridView.CurrentRow.Cells["Sklep_Nazwa"].Value.ToString() + "'?", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(dialogResult == DialogResult.Yes)
                {
                    String result = "";
                    DBRepository db = new DBRepository();

                    if(db.SklepyUstawiania_DelShop(mailDataGridView.CurrentRow.Cells[0].Value.ToString(), ref result))
                    {
                        ZaladujMailDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd usuwania:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SklepyDodawanieForm sklepyDodawanie = new SklepyDodawanieForm();
            sklepyDodawanie.ShowDialog();

            if(sklepyDodawanie.czyDodano)
            {
                ZaladujMailDataGridView();
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if(mailDataGridView.CurrentCell != null)
            {
                String sklepID = mailDataGridView.CurrentRow.Cells["Sklep_ID"].Value.ToString();
                String nazwa = mailDataGridView.CurrentRow.Cells["Sklep_Nazwa"].Value.ToString();
                String sklepEmail = mailDataGridView.CurrentRow.Cells["Sklep_Email"].Value.ToString();
                String centralaEmail = mailDataGridView.CurrentRow.Cells["Sklep_CentralaEmail"].Value.ToString();
                String archiwalny = mailDataGridView.CurrentRow.Cells["Sklep_Archiwalny"].Value.ToString();


                SklepyDodawanieForm sklepyDodawanie = new SklepyDodawanieForm(sklepID, nazwa, sklepEmail, centralaEmail, archiwalny);
                sklepyDodawanie.ShowDialog();

                if(sklepyDodawanie.czyDodano)
                {
                    ZaladujMailDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano wiersza.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void archiwalneCB_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujMailDataGridView();
        }
    }
}
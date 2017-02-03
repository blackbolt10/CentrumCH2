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
            PokazPrzyciski(false);

            DataTable pomDataTable = new DataTable();
            String result = "";
            DBRepository db = new DBRepository();

            if(db.SklepyUstawienia_ZaladujMailDatagridView(archiwalneSklepyCB.Checked, archiwalneMaileCB.Checked, ref pomDataTable, ref result))
            {
                if(pomDataTable.Rows.Count > 0)
                {
                    PokazPrzyciski(true);

                    mailDataGridView.DataSource = pomDataTable;
                    mailDataGridView.Columns["SKL_SklId"].Visible = false;
                    mailDataGridView.Columns["SKL_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    mailDataGridView.Columns["SKL_Archiwalny"].Visible = false;
                    mailDataGridView.Columns["SKM_SkmID"].Visible = false;
                    mailDataGridView.Columns["SKM_SklID"].Visible = false;
                    mailDataGridView.Columns["SKM_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    mailDataGridView.Columns["SKM_Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    mailDataGridView.Columns["SKM_Archiwalny"].Visible = false;

                    mailDataGridView.CurrentCell = mailDataGridView.Rows[0].Cells["SKL_Nazwa"];
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd wczytywania listy sklepów:\n" + result, "BŁąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PokazPrzyciski(bool param)
        {
            zmienMailButton.Enabled = param;
            usunMailButton.Enabled = param;

            zmienSklepButton.Enabled = param; 
            usunSklepButton.Enabled = param;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if(mailDataGridView.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony sklep?\nOperacja jest nie odwracalna.", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                String sklepID = mailDataGridView.CurrentRow.Cells["SKL_SklId"].Value.ToString();
                String nazwa = mailDataGridView.CurrentRow.Cells["SKL_Nazwa"].Value.ToString();
                String archiwalny = mailDataGridView.CurrentRow.Cells["SKL_Archiwalny"].Value.ToString();

                SklepyDodawanieForm sklepyDodawanie = new SklepyDodawanieForm(sklepID, nazwa, archiwalny);
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

        private void archiwalneMaileCB_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujMailDataGridView();
        }

        private void dodajMailButton_Click(object sender, EventArgs e)
        {
            SklepyMailDodawanieForm sklepyMailDodawanie = new SklepyMailDodawanieForm(mailDataGridView.CurrentRow.Cells["SKL_SklId"].Value.ToString());
            sklepyMailDodawanie.ShowDialog();

            if(sklepyMailDodawanie.czyDodano)
            {
                ZaladujMailDataGridView();
            }
        }

        private void usunMailButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony adres email?\nOperacja jest nie odwracalna.", "Pytanie", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(dialogResult == DialogResult.OK)
            {
                if(mailDataGridView.CurrentCell != null)
                {
                    String SKM_SkmID = mailDataGridView.CurrentRow.Cells["SKM_SkmID"].Value.ToString();

                    if(SKM_SkmID != "" && SKM_SkmID != null && SKM_SkmID != "null")
                    {
                        String result = "";
                        DBRepository db = new DBRepository();

                        if(db.SklepyMailDodawanie_DelMail(SKM_SkmID, ref result))
                        {
                            ZaladujMailDataGridView();
                        }
                        else
                        {
                            MessageBox.Show(result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nie został wybrany żaden wiersz.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void zmienMailButton_Click(object sender, EventArgs e)
        {
            if(mailDataGridView.CurrentCell != null)
            {
                String SKM_SkmID = mailDataGridView.CurrentRow.Cells["SKM_SkmID"].Value.ToString();
                String SKL_SklID = mailDataGridView.CurrentRow.Cells["SKL_SklID"].Value.ToString();
                String SKM_Nazwa = mailDataGridView.CurrentRow.Cells["SKM_Nazwa"].Value.ToString();
                String SKM_Mail = mailDataGridView.CurrentRow.Cells["SKM_Mail"].Value.ToString();

                SklepyMailDodawanieForm sklepyMailDodawanie = new SklepyMailDodawanieForm(SKL_SklID, SKM_SkmID, SKM_Mail, SKM_Nazwa);
                sklepyMailDodawanie.StartPosition = FormStartPosition.CenterParent;
                sklepyMailDodawanie.ShowDialog();

                if(sklepyMailDodawanie.czyDodano)
                {
                    ZaladujMailDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Nie został wybrany żaden wiersz.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Pliki Excel|*.xls;*.xlsx|Wszystkie pliki|*.*";

            DialogResult dialogResult = openDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                if(CheckExcelExtension(openDialog.FileName))
                {
                    SklepyImportForm importForm = new SklepyImportForm(openDialog.FileName);
                    importForm.ShowDialog();

                    if(importForm.czyDodano)
                    {
                        ZaladujMailDataGridView();
                    }
                }
            }
        }
        private Boolean CheckExcelExtension(String fileName)
        {
            Boolean result = false;
            String[] fileNames = fileName.Split('.');

            switch(fileNames[fileNames.Length - 1])
            {
                case "xlsx":
                result = true;
                break;
                case "xls":
                result = true;
                break;
                default:
                MessageBox.Show("Wybrano plik nie obsługiwany przez program.\nProszę spróbować ponownie wybierając plik Excela.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
            }
            return result;
        }
    }
}
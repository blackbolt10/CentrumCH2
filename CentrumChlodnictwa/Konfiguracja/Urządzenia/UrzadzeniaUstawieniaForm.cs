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
    public partial class UrzadzeniaUstawieniaForm : Form
    {
        private DataTable sklepyDT;

        public UrzadzeniaUstawieniaForm()
        {
            InitializeComponent();
        }

        private void UrzadzeniaUstawieniaForm_Shown(object sender, EventArgs e)
        {
            zaladujSklepyDT();
        }

        private void zaladujSklepyDT()
        {
            sklepCB.Items.Clear();
            sklepyDT = new DataTable();
            String result = "";

            DBRepository db = new DBRepository();
            if(db.UrzadzeniaUstawienia_ZaladujSklepy(ref sklepyDT, ref result))
            {
                if(sklepyDT.Rows.Count > 0)
                {
                    for(int i = 0; i < sklepyDT.Rows.Count; i++)
                    {
                        sklepCB.Items.Add(sklepyDT.Rows[i]["SKL_Nazwa"]);
                    }

                    if(sklepCB.Items.Count>0)
                    {
                        sklepCB.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy sklepów:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sklepCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujTempDataGridView();
        }

        private void ZaladujTempDataGridView()
        {
            if(sklepCB.Items.Count > 0)
            {
                modButton.Enabled = false;
                delButton.Enabled = false;
                tempDataGridView.DataSource = null;
                tempDataGridView.Rows.Clear();
                tempDataGridView.Columns.Clear();
                String result = "";
                Int32 sklepID = Convert.ToInt32(sklepyDT.Rows[sklepCB.SelectedIndex]["SKL_SklId"].ToString());
                DataTable pomDataTable = new DataTable();

                DBRepository db = new DBRepository();

                if(db.UrzadzeniaUstawienia_ZaladujTempDataGridView(sklepID, archiwalneCB.Checked, ref pomDataTable, ref result))
                {
                    tempDataGridView.DataSource = pomDataTable;

                    if(tempDataGridView.Rows.Count>0)
                    {
                        modButton.Enabled = true;
                        delButton.Enabled = true;
                        tempDataGridView.CurrentCell = tempDataGridView.Rows[0].Cells["URZ_Nazwa"];
                    }

                    if(tempDataGridView.Columns.Count>0)
                    {
                        tempDataGridView.Columns["URZ_URZId"].Visible = false;
                        tempDataGridView.Columns["URZ_SklID"].Visible = false;
                        tempDataGridView.Columns["URZ_Nazwa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        tempDataGridView.Columns["URZ_Modul"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        tempDataGridView.Columns["URZ_TempMin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        tempDataGridView.Columns["URZ_TempMax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas wczytywania listy temperatur:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            UrzadzeniaDodawanieForm UrzadzeniaDodawanieForm = new UrzadzeniaDodawanieForm();
            UrzadzeniaDodawanieForm.ShowDialog();

            if(UrzadzeniaDodawanieForm.czyDodano)
            {
                ZaladujTempDataGridView();
            }
        }

        private void modButton_Click(object sender, EventArgs e)
        {
            if(tempDataGridView.CurrentCell != null)
            {
                String tempID = tempDataGridView.CurrentRow.Cells["URZ_URZId"].Value.ToString();
                String sklepID = tempDataGridView.CurrentRow.Cells["URZ_SklID"].Value.ToString();
                String nazwa = tempDataGridView.CurrentRow.Cells["URZ_Nazwa"].Value.ToString();
                String modul = tempDataGridView.CurrentRow.Cells["URZ_Modul"].Value.ToString();
                String tempMin = tempDataGridView.CurrentRow.Cells["URZ_TempMin"].Value.ToString();
                String tempMax = tempDataGridView.CurrentRow.Cells["URZ_TempMax"].Value.ToString();

                UrzadzeniaDodawanieForm UrzadzeniaDodawanieForm = new UrzadzeniaDodawanieForm(tempID, sklepID, nazwa, modul, tempMin, tempMax);
                UrzadzeniaDodawanieForm.ShowDialog();

                if(UrzadzeniaDodawanieForm.czyDodano)
                {
                    ZaladujTempDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano wiersza.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if(tempDataGridView.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno zarchiwizować wiersz '" + tempDataGridView.CurrentRow.Cells["URZ_Nazwa"].Value.ToString()+"-"+ tempDataGridView.CurrentRow.Cells["URZ_Modul"].Value.ToString() + "'?", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(dialogResult == DialogResult.Yes)
                {
                    String result = "";
                    DBRepository db = new DBRepository();

                    if(db.TempUstawiania_DelTemp(tempDataGridView.CurrentRow.Cells[0].Value.ToString(), ref result))
                    {
                        ZaladujTempDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd usuwania:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void archiwalneCB_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujTempDataGridView();
        }
    }
}

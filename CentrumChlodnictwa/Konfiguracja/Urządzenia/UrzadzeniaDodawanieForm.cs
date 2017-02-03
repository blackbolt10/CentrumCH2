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
    public partial class UrzadzeniaDodawanieForm : Form
    {
        public Boolean czyDodano = false;
        private String urzadzenieID;
        private String sklepID;
        private DataTable sklepyDT;

        public UrzadzeniaDodawanieForm()
        {
            InitializeComponent();
            zaladujSklepyDT();
        }

        public UrzadzeniaDodawanieForm(String _urzadzenieID, String _sklepID, String _nazwa, String _modul, String _tempMin, String _tempMax)
        {
            InitializeComponent();
            zaladujSklepyDT();

            nazwaTB.Text = _nazwa;
            modulTB.Text = _modul;
            tempMinTB.Text = _tempMin;
            tempMaxTB.Text = _tempMax;
            urzadzenieID = _urzadzenieID;
            sklepID = _sklepID;

            saveButton.Click -= saveButton_Click;
            saveButton.Click += modificationButton_Click;
            saveButton.Text = "Zmień";
            this.Text = "Zmień urządzenie";

            ustawSklep();
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

                    if(sklepCB.Items.Count > 0)
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificationButton_Click(object sender, EventArgs e)
        {
            if(CheckFormIsValid())
            {
                DBRepository db = new DBRepository();
                string result = "";
                sklepID = sklepyDT.Rows[sklepCB.SelectedIndex][0].ToString();

                string archiwalne = "0";
                if(archiwalnyCB.Checked)
                {
                    archiwalne = "1";
                }

                if(!db.UrzadzeniaDodawanie_ModMail(urzadzenieID, sklepID, nazwaTB.Text, modulTB.Text, tempMinTB.Text, tempMaxTB.Text, archiwalne, ref result))
                {
                    MessageBox.Show("Podczas modyfikacji wystapił błąd:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    czyDodano = true;
                    this.Close();
                }
            }
        }

        private void onlyDecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private Boolean CheckFormIsValid()
        {
            if(nazwaTB.Text == "")
            {
                MessageBox.Show("Nazwa urządzenia jest wymagana.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(modulTB.Text == "")
            {
                MessageBox.Show("Moduł urządzenia jest wymagany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else if(tempMinTB.Text == "" && tempMaxTB.Text =="")
            {
                MessageBox.Show("Minimum jedna temperatura jest wymagana.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return true;
            }
            return false;
        }

        private void ustawSklep()
        {
            int result = -1;
            for(int i = 0; i < sklepyDT.Rows.Count; i++)
            {
                if(sklepyDT.Rows[i][0].ToString() == sklepID)
                {
                    result = i;
                    break;
                }
            }

            if(result<sklepCB.Items.Count)
            {
                sklepCB.SelectedIndex = result;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(CheckFormIsValid())
            {
                DBRepository db = new DBRepository();
                string result = "";
                sklepID = sklepyDT.Rows[sklepCB.SelectedIndex][0].ToString();

                string archiwalne = "0";
                if(archiwalnyCB.Checked)
                {
                    archiwalne = "1";
                }

                if(!db.UrzadzeniaDodawanie_AddTemp(sklepID, nazwaTB.Text, modulTB.Text, tempMinTB.Text, tempMaxTB.Text, archiwalne, ref result))
                {
                    MessageBox.Show("Podczas dodawania wystapił błąd:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    czyDodano = true;
                    this.Close();
                }
            }
        }
    }
}

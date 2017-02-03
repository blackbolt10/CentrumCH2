using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentrumChlodnictwa
{
    public partial class SklepyDodawanieForm : Form
    {
        public Boolean czyDodano = false;
        private String SklepID;

        public SklepyDodawanieForm()
        {
            InitializeComponent();
        }

        public SklepyDodawanieForm(String sklepID, String nazwa, String archiwalny)
        {
            InitializeComponent();

            SklepID = sklepID;
            nazwaTB.Text = nazwa;

            if(archiwalny == "1")
            {
                archiwalnyCB.Checked = true;
            }

            zapiszButton.Text = "Zmień";
            zapiszButton.Click -= zapiszButton_Click;
            zapiszButton.Click += ModyfikujButton_Click;

            this.Text = "Zmień e-mail";
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

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            if(CheckFormIsValid())
            {
                DBRepository db = new DBRepository();
                string result = "";
                string wiadomosc = "";

                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(!db.SklepyDodawanie_AddShop(nazwaTB.Text, archiwalny, ref result, ref wiadomosc))
                {
                    MessageBox.Show("Podczas dodawania wystapił błąd:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(result != "-1")
                    {
                        czyDodano = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(wiadomosc, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ModyfikujButton_Click(object sender, EventArgs e)
        {
            if(CheckFormIsValid())
            {
                DBRepository db = new DBRepository();
                string result = "";

                String archiwalny = "0";

                if(archiwalnyCB.Checked)
                {
                    archiwalny = "1";
                }

                if(!db.SklepyDodawanie_ModShop(SklepID, nazwaTB.Text, archiwalny, ref result))
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

        private Boolean CheckFormIsValid()
        {
            if(nazwaTB.Text == "")
            {
                MessageBox.Show("Nazwa sklepu jest wymagana.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
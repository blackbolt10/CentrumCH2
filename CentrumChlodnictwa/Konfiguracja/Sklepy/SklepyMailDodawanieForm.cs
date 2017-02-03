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
    public partial class SklepyMailDodawanieForm : Form
    {
        private DataTable sklepyDT;
        private String SKL_SklID = "";
        private String SKM_SkmID = "";
        public Boolean czyDodano = false;

        public SklepyMailDodawanieForm(String _SKL_SklID)
        {
            InitializeComponent();

            ZaladujSklepyCB();
            nazwaCB.SelectedIndex = 0;

            SKL_SklID = _SKL_SklID;
            archiwalnyCB.Visible = false;
            UstawSklep();
        }

        public SklepyMailDodawanieForm(string _SKL_SklID, string _SKM_SkmID, string _SKM_Mail, string _SKM_Nazwa)
        {
            InitializeComponent();

            SKL_SklID = _SKL_SklID;
            SKM_SkmID = _SKM_SkmID;
            emailTB.Text = _SKM_Mail;

            ZaladujSklepyCB();
            UstawOpis(_SKM_Nazwa);
            UstawSklep();

            archiwalnyCB.Visible = false;

            zapiszButton.Click -= zapiszButton_Click;
            zapiszButton.Click += modyfkujButton_Click;
        }

        private void UstawOpis(string SKM_Nazwa)
        {
            if(SKM_Nazwa != "")
            {
                Int32 index = -1;

                for(int i = 0; i < nazwaCB.Items.Count; i++)
                {
                    if(nazwaCB.Items[i].ToString() == SKM_Nazwa)
                    {
                        index = i;
                        break;
                    }
                }
                if(nazwaCB.Items.Count > 0 && index < nazwaCB.Items.Count)
                {
                    nazwaCB.SelectedIndex = index;
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZaladujSklepyCB()
        {
            sklepCB.Items.Clear();
            sklepyDT = new DataTable();

            DBRepository db = new DBRepository();
            String result = "";

            if(db.SklepyMailDodawanie_ZaladujSklepy(ref sklepyDT, ref result))
            {
                if(sklepyDT.Rows.Count>0)
                {
                    for(int i = 0; i < sklepyDT.Rows.Count; i++)
                    {
                        sklepCB.Items.Add(sklepyDT.Rows[i]["SKL_Nazwa"].ToString());
                    }

                    UstawSklep();
                }
            }
            else
            {
                MessageBox.Show(result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UstawSklep()
        {
            if(SKL_SklID != "")
            {
                Int32 index = -1;

                for(int i = 0; i < sklepyDT.Rows.Count; i++)
                {
                    if(sklepyDT.Rows[i]["SKL_SklId"].ToString() == SKL_SklID)
                    {
                        index = i;
                        break;
                    }
                }
                if(sklepCB.Items.Count > 0 && index < sklepCB.Items.Count)
                {
                    sklepCB.SelectedIndex = index;
                }
            }
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            if(CheckFormIsValid())
            {
                DBRepository db = new DBRepository();
                string result = "";

                if(db.SklepyMailDodawanie_AddMail(SKL_SklID, emailTB.Text, nazwaCB.Items[nazwaCB.SelectedIndex].ToString(), ref result))
                {
                    czyDodano = true;
                    this.Close();}
                else
                {
                    MessageBox.Show("Podczas zapisu wystapił błąd:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void modyfkujButton_Click(object sender, EventArgs e)
        {
            if(CheckFormIsValid())
            {
                DBRepository db = new DBRepository();
                string result = "";

                if(db.SklepyMailDodawanie_ModMail(SKL_SklID, SKM_SkmID, emailTB.Text, nazwaCB.Items[nazwaCB.SelectedIndex].ToString(), ref result))
                {
                    czyDodano = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Podczas modyfikacji wystapił błąd:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckFormIsValid()
        {
            if(emailTB.Text == "")
            {
                MessageBox.Show("Nazwa e-mail jest wymagana.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(IsEmailInvalid(emailTB.Text))
            {
                MessageBox.Show("Podany e-mail jest nie poprawny.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(sklepCB.SelectedIndex == -1 || nazwaCB.SelectedIndex == -1)
            {
                MessageBox.Show("Sklep lub opis nie został wybrany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return true;
            }
            return false;
        }

        private Boolean IsEmailInvalid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return false;
            }
            catch(FormatException)
            {
                return true;
            }
        }
    }
}

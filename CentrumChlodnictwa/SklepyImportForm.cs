using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace CentrumChlodnictwa
{
    public partial class SklepyImportForm : Form
    {
        public Boolean czyDodano = false;
        private String fileName;
        
        public SklepyImportForm(String _fileName)
        {
            InitializeComponent();

            fileName = _fileName;
        }

        private void SklepyImportForm_Shown(object sender, EventArgs e)
        {
            LoadExcelFile();
            this.Close();
        }

        private void LoadExcelFile()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            
            opisLabel.Text += "\nOtwieranie pliku excel...";

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            if(rowCount > 5 && colCount > 2)
            {
                opisLabel.Text += "\nOdczytywanie informacji nagłówkowych...";
                object[,] values = (object[,])xlRange.Value2;
                
                opisLabel.Text += "\nPrzetwarzanie danych nagłówkowych...";

                DBRepository db = new DBRepository();

                progressBar.Maximum = rowCount;
                progressBar.Value = 0;
                
                opisLabel.Text += "\nOdczytywanie "+(rowCount-5)+" wierszy danych...";

                for(int i = 6; i <= rowCount; i++)
                {
                    String nazwaSklepu = values[i, 1].ToString();
                    String nazwaEmail = values[i, 2].ToString();
                    String email = values[i, 3].ToString();

                    String idSklepu = "";
                    String result = "";

                    if(db.SklepImport_AddSklep(nazwaSklepu, ref idSklepu, ref result))
                    {
                        if(db.SklepImport_AddMail(idSklepu, nazwaEmail, email, ref result))
                        {
                            czyDodano = true;
                        }
                        else
                        {
                            MessageBox.Show("Wystąpił błąd podczas dodawania adresu email '"+email+"' dla sklepu  '"+nazwaSklepu+"'" + nazwaSklepu + "':\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas dodawania sklepu '" + nazwaSklepu + "':\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    progressBar.Value++;
                }
            }
            else
            {
                MessageBox.Show("Wczytywany plik ma 0 wierszy lub 0 kolumn.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            opisLabel.Text += "\nZamykanie pliku excel...";
            
            xlWorkbook.Close(false, null, null);
            xlApp.Quit();
            
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }
}

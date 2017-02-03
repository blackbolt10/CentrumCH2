using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;


namespace CentrumChlodnictwa
{
    public partial class ReadDataForm : Form
    {
        private Int32 naglowekID = -1;
        private Int32 sklepID = -1;
        private String dataOdczytu = "";
        private String nazwaSklepu = "";
        private String fileName = "";
        private DataTable tempDataTable;

        private Panel panel;
        private Label postepLabel;
        private ProgressBar progressBar;
        

        public ReadDataForm()
        {
            InitializeComponent();
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

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Pliki Excel|*.xls;*.xlsx|Wszystkie pliki|*.*";

            DialogResult dialogResult = openDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                fileName = openDialog.FileName;
                if(CheckExcelExtension())
                {
                    LoadExcelFile(openDialog.FileName);

                    if(dataGridView.Rows.Count > 0)
                    {
                        sendingFormButton.Enabled = true;
                    }
                    else
                    {
                        sendingFormButton.Enabled = false;
                    }
                }
            }
        }

        private Boolean CheckExcelExtension()
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

        private void LoadExcelFile(string fileName)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            ShowLoadingScreen();
            ClearDataGridView();
            tempDataTable = new DataTable();

            postepLabel.Text += "\nOtwieranie pliku excel...";

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            if(rowCount > 0 && colCount > 0)
            {
                tempDataTable.Columns.Add("Name");
                tempDataTable.Columns.Add("Pos.");

                for(int i = 0; i <= colCount-3; i++)
                {
                    String czasPomiaru = "";
                    if(i < 10)
                    {
                        czasPomiaru = "0" + i + ":00";
                    }
                    else
                    {
                        czasPomiaru = i + ":00";
                    }

                    tempDataTable.Columns.Add(czasPomiaru);
                }
                
                tempDataTable.Columns.Add("Średnia arytmetyczna z odczytów");
                tempDataTable.Columns.Add("Wartość temperatury przy maksymalnym przekroczeniu dopuszczalnej temperatury");
                tempDataTable.Columns.Add("Czas trwania maksymalnego przekroczenia temperatury");
                tempDataTable.Columns.Add("Liczba wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury");
                tempDataTable.Columns.Add("Sumaryczny czas trwania wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury");
                tempDataTable.Columns.Add("Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur");
                tempDataTable.Columns.Add("Przekroczenie");
                tempDataTable.Columns.Add("Alarm");

                postepLabel.Text += "\nOdczytywanie informacji nagłówkowych...";                
                object[,] values = (object[,])xlRange.Value2;

                dataOdczytu = values[1, 1].ToString();
                String[] tempStringArray = dataOdczytu.Split(' ');
                dataOdczytu = tempStringArray[tempStringArray.Length - 1];

                nazwaSklepu = values[2, 1].ToString();
                tempStringArray = nazwaSklepu.Split(' ');
                nazwaSklepu = tempStringArray[tempStringArray.Length - 1];

                sklepID = -1;
                naglowekID = WygenerujNaglowek(ref sklepID);
                
                if(naglowekID >= 0 && sklepID >= 0)
                {
                    postepLabel.Text += "\nOdczytywanie danych...";
                    ShowProgressBar(rowCount);

                    for(int i = 7; i <= rowCount; i++)
                    {
                        String nazwaUrzadzenia = values[i, 1].ToString();
                        String modulUrzadzenia = values[i, 2].ToString();

                        tempDataTable.Rows.Add();
                        tempDataTable.Rows[i - 7][0] = nazwaUrzadzenia;
                        tempDataTable.Rows[i - 7][1] = modulUrzadzenia;

                        for(int j = 3; j <= colCount; j++)
                        {
                            String czasPomiaru = "";
                            if(j - 3 < 10)
                            {
                                czasPomiaru = "0" + (j-3) + ":00";
                            }
                            else
                            {
                                czasPomiaru = j - 3 + ":00";
                            }

                            String cellResult = values[i, j].ToString();
                            String stan = "";
                            Decimal? wartosc = 0;

                            if(cellResult[cellResult.Length - 1] == '!')
                            {
                                stan = "alarm";
                                cellResult = cellResult.Replace('!', '\0');
                            }


                            if(cellResult[cellResult.Length - 1] == '*')
                            {
                                stan = "defrost";
                                wartosc = null;
                            }
                            else
                            {
                                wartosc = Convert.ToDecimal(cellResult.Replace(',', '.'));
                            }

                            tempDataTable.Rows[i - 7][j-1] = cellResult;
                            ZapiszOdczyt(sklepID, naglowekID, nazwaUrzadzenia, modulUrzadzenia, czasPomiaru, wartosc, stan);
                        }

                        progressBar.Value++;
                    }
                }
                dataGridView.DataSource = tempDataTable;
            }
            else
            {
                MessageBox.Show("Wczytywany plik ma 0 wierszy lub 0 kolumn.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            postepLabel.Text += "\nZamykanie pliku excel...";

            ustawNazwy();
            xlWorkbook.Close(false, null, null);
            xlApp.Quit();

            panel.Dispose();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void ZapiszOdczyt(int sklepID, int nagID, string nazwaUrzadzenia, string modulUrzadzenia, string czasPomiaru, decimal? wartosc, string stan)
        {
            DBRepository db = new DBRepository();
            String result = "";
            if(!db.ReadDataForm_ZapiszOdczyt(sklepID, nagID, nazwaUrzadzenia, modulUrzadzenia, czasPomiaru, wartosc, stan, ref result))
            {
                MessageBox.Show(result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int WygenerujNaglowek(ref Int32 sklepID)
        {
            DBRepository db = new DBRepository();
            String result = "";
            Int32 wynik = -1;

            if(!db.ReadDataForm_GenerujNaglowek(nazwaSklepu, dataOdczytu, fileName, ref sklepID, ref wynik, ref result))
            {
                MessageBox.Show(result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return wynik;
        }

        private void ShowProgressBar(int rowCount)
        {
            progressBar = new ProgressBar();
            progressBar.Maximum = rowCount - 6;
            progressBar.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            panel.Controls.Add(progressBar);
            progressBar.Location = new Point(postepLabel.Location.X, panel.Size.Height - 35);
            progressBar.Size = new Size(panel.Size.Width - 15, 20);
            progressBar.BringToFront();
        }

        private void ShowLoadingScreen()
        {
            panel = new Panel();
            postepLabel = new Label();

            postepLabel.AutoSize = true;
            postepLabel.Location = new Point(10, 10);
            postepLabel.Text = "Odczytywanie danych w toku. Operacja w zależzności od ilości wierszy w pliku może zająć chwilę...";

            panel.Controls.Add(postepLabel);
            panel.Location = dataGridView.Location;
            panel.Size = dataGridView.Size;

            this.Controls.Add(panel);
            panel.BringToFront();
        }

        private void ClearDataGridView()
        {
            if(dataGridView.Rows.Count > 0 || dataGridView.Columns.Count > 0)
            {
                postepLabel.Text += "\nCzyszczenie poprzednich wpisów...";
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
        }

        private void ustawNazwy()
        {
            dataOdczytuLabel.Text = "Data odczytu: " + dataOdczytu;

            nazwaSklepuLabel.Text = "Nazwa sklepu: " + nazwaSklepu;
        }        

        private void saveButton_Click(object sender, EventArgs e)
        {
            WysylanieDanychForm wysylanieForm = new WysylanieDanychForm(sklepID, nazwaSklepu, dataOdczytu, tempDataTable);
            wysylanieForm.ShowDialog();

            wysylanieForm.Dispose();
        }
    }
}

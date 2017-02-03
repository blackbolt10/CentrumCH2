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
    public partial class LoadDataForm : Form
    {
        private String dataOdczytu = "";
        private String nazwaSklepu = "";
        private String fileName = "";


        private Panel panel;
        private Label postepLabel;
        private ProgressBar progressBar;

        public LoadDataForm()
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
                        saveButton.Enabled = true;
                        sendButton.Enabled = true;
                        savePDFButton.Enabled = true;
                    }
                    else
                    {
                        saveButton.Enabled = false;
                        sendButton.Enabled = false;
                        savePDFButton.Enabled = false;
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

            postepLabel.Text += "\nOtwieranie pliku excel...";

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            if(rowCount > 0 && colCount > 0)
            {
                postepLabel.Text += "\nOdczytywanie informacji nagłówkowych...";
                dataOdczytu = xlRange.Cells[1, 1].Value2.ToString();
                nazwaSklepu = xlRange.Cells[2, 1].Value2.ToString();

                DataTable tempDataTable = new DataTable();

                if(rowCount >= 6)
                {
                    for(int i = 1; i <= colCount; i++)
                    {
                        if(xlRange.Cells[6, i].Value2 != null)
                        {
                            String columnName = xlRange.Cells[6, i].Value2.ToString();
                            // dataGridView.Columns.Add(columnName, columnName);
                            tempDataTable.Columns.Add(columnName);
                        }
                        else
                        {
                            //dataGridView.Columns.Add("kolumna " + i, "kolumna " + i);
                            tempDataTable.Columns.Add("kolumna " + i);
                        }
                    }

                    tempDataTable.Columns.Add("Średnia arytmetyczna z odczytów");
                    tempDataTable.Columns.Add("Wartość temperatury przy maksymalnym przekroczeniu dopuszczalnej temperatury");
                    tempDataTable.Columns.Add("Czas trwania maksymalnego przekroczenia temperatury");
                    tempDataTable.Columns.Add("Liczba wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury");
                    tempDataTable.Columns.Add("Sumaryczny czas trwania wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury");
                    tempDataTable.Columns.Add("Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur");
                    tempDataTable.Columns.Add("Przekroczenie");
                    tempDataTable.Columns.Add("Alarm");

                    postepLabel.Text += "\nOdczytywanie danych...";
                    ShowProgressBar(rowCount);
                    for(int i = 7; i <= rowCount; i++)
                    {
                        Int32 sumaTEMP = 0;
                        Int32 liczbaElemSredniej = 0;
                        Int32 iloscPrzekroczen = 0; //w aktualnym przypadku tak samo jak czas przekroczeń

                        Int32 czasTrwaniaMaxPrzekr = 0;
                        Int32 czasTrwaniaAktPrzekr = 0;
                        Int32? wartoscMaxPrzekr = null;
                        
                        tempDataTable.Rows.Add();

                        for(int j = 1; j <= colCount; j++)
                        {
                            String cellResult = xlRange.Cells[i, j].Value2.ToString();
                            tempDataTable.Rows[i - 7][j - 1] = cellResult;

                            if(j > 2)
                            {
                                Int32? tempMin = null;
                                Int32? tempMax = null;
                                OdczytajDopTemp(tempDataTable.Rows[i - 7][0].ToString(), tempDataTable.Rows[i - 7][1].ToString(), ref tempMin, ref tempMax);

                                if(cellResult[cellResult.Length - 1] == '!') //liczenie alarmów
                                {
                                    tempDataTable.Rows[i - 7]["Alarm"] = "1";
                                    cellResult = cellResult.Replace('!', '\0');  
                                }

                                if(cellResult[cellResult.Length - 1] != '*')
                                {
                                    liczbaElemSredniej++;
                                    sumaTEMP += Convert.ToInt32(cellResult);

                                    int aktualnaWartosc = Convert.ToInt32(cellResult);
                                    int aktualnaWartoscPrzek = 0;
                                    Boolean przekroczenie = false;

                                    if(tempMin != null)
                                    {
                                        if(aktualnaWartosc < (int)tempMin)
                                        {
                                            //PRZEKROCZENIE MIN
                                            iloscPrzekroczen++;
                                            przekroczenie = true;
                                            aktualnaWartoscPrzek = Math.Abs(aktualnaWartosc)- Math.Abs((int)tempMin);
                                            tempDataTable.Rows[i - 7]["Przekroczenie"] = "1";
                                        }
                                    }

                                    if(tempMax != null)
                                    {
                                        if(aktualnaWartosc > (int)tempMax)
                                        {
                                            //PRZEKROCZENIE Max
                                            iloscPrzekroczen++;
                                            przekroczenie = true;
                                            aktualnaWartoscPrzek = Math.Abs(aktualnaWartosc) - Math.Abs((int)tempMax);
                                            tempDataTable.Rows[i - 7]["Przekroczenie"] = "1";
                                        }
                                    }

                                    if(j > 3 && przekroczenie) //obliczanie czasu trwania max przekroczenia
                                    {
                                        czasTrwaniaAktPrzekr++;

                                        if(czasTrwaniaAktPrzekr > czasTrwaniaMaxPrzekr)
                                        {
                                            czasTrwaniaMaxPrzekr = czasTrwaniaAktPrzekr;
                                        }
                                    }
                                    else
                                    {
                                        czasTrwaniaAktPrzekr = 0;
                                    }

                                    //obliczamy przekroczenie
                                    if(wartoscMaxPrzekr == null)
                                    {
                                        wartoscMaxPrzekr = 0;
                                    }

                                    if(wartoscMaxPrzekr < Math.Abs(aktualnaWartoscPrzek))
                                    {
                                        wartoscMaxPrzekr = Math.Abs(aktualnaWartoscPrzek);
                                    }
                                }
                                else if(cellResult[cellResult.Length - 1] == '*')
                                {
                                    // GWIAZDKI pomijamy?
                                }
                            }
                        }

                        UstawSredniaTemp(ref tempDataTable, i, sumaTEMP, liczbaElemSredniej);
                        UstawPrzekroczenia(ref tempDataTable, i, wartoscMaxPrzekr, czasTrwaniaMaxPrzekr, iloscPrzekroczen);


                        progressBar.Value++;
                    }
                    dataGridView.DataSource = tempDataTable;
                }
            }
            else
            {
                MessageBox.Show("Wczytywany plik ma 0 wierszy lub 0 kolumn.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ustawNazwy();
            xlWorkbook.Close(false, null, null);
            xlApp.Quit();

            panel.Dispose();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void UstawPrzekroczenia(ref DataTable tempDataTable, int rowID, int? maxPrzekroczenie, int czasTrwaniaPrzekroczenia, int liczbaPrzekroczen)
        {
            tempDataTable.Rows[rowID - 7]["Wartość temperatury przy maksymalnym przekroczeniu dopuszczalnej temperatury"] = ((int)maxPrzekroczenie).ToString();

            if(liczbaPrzekroczen != 0)
            {
                tempDataTable.Rows[rowID - 7]["Czas trwania maksymalnego przekroczenia temperatury"] = czasTrwaniaPrzekroczenia.ToString();
                tempDataTable.Rows[rowID - 7]["Liczba wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury"] = liczbaPrzekroczen.ToString();
                tempDataTable.Rows[rowID - 7]["Sumaryczny czas trwania wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury"] = liczbaPrzekroczen.ToString(); //w naszym przypadku czas i liczba jest ten sam ?
                tempDataTable.Rows[rowID - 7]["Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur"] = (Convert.ToDecimal(liczbaPrzekroczen) * 100 / 24).ToString("#.##") + "%";

                if(tempDataTable.Rows[rowID - 7]["Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur"].ToString() == "%")
                {
                    tempDataTable.Rows[rowID - 7]["Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur"] = "";
                }
            }
        }

        private void UstawSredniaTemp(ref DataTable tempDataTable, int rowID, int sumaTEMP, int liczbaElemSredniej)
        {
            try
            {
                double sred = Convert.ToDouble(sumaTEMP) / liczbaElemSredniej;
                String srednia = sred.ToString("#.#");
                if(srednia[0] == ',')
                {
                    tempDataTable.Rows[rowID - 7]["Średnia arytmetyczna z odczytów"] = "0"+srednia;
                }
                else
                {
                    tempDataTable.Rows[rowID - 7]["Średnia arytmetyczna z odczytów"] = srednia;
                }
            }
            catch(Exception)
            {
                tempDataTable.Rows[rowID - 7]["Średnia arytmetyczna z odczytów"] = "#";
            }
        }

        private void OdczytajDopTemp(String nazwa, String oznaczenie, ref Int32? tempMin, ref Int32? tempMax)
        {
            DBRepository db = new DBRepository();
            String result = "";

            if(db.LoadDataForm_OdczytajTemp(nazwa, oznaczenie, ref tempMin, ref tempMax, ref result))
            {
                
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas odczytywania dopuszczalnych temperatur:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            String[] tempStringArray = dataOdczytu.Split(' ');
            dataOdczytu = tempStringArray[tempStringArray.Length - 1];
            dataOdczytuLabel.Text = "Data odczytu: " + dataOdczytu;

            tempStringArray = nazwaSklepu.Split(' ');
            nazwaSklepu = tempStringArray[tempStringArray.Length - 1];
            nazwaSklepuLabel.Text = "Nazwa sklepu: " + nazwaSklepu;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            String[] fileNamePath = fileName.Split('\\');
            saveDialog.FileName = fileNamePath[fileNamePath.Length - 1] + ".html";
            saveDialog.Filter = "Pliki html|.htm;.html|Wszystkie pliki|*.*";

            DialogResult dialogResult = saveDialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                String result = "<html><head><meta http-equiv=Content-Type content=\"text/html; charset = utf-8\"><title>" + fileNamePath[fileNamePath.Length - 1] + "</title></head><body style=\"font - family: Tahoma, Verdana, Segoe, sans - serif; font-size:10px;\">";
                result += DodajDane();
                result += "</body></html>";

                ZapiszPlik(saveDialog.FileName, result);
            }
        }

        private string DodajDane(int borderWidth = 1, string borderStyle = "dotted")
        {
            String result = "<p><b>Market: </b><span>" + nazwaSklepu + "</span><br>";
            result += "<b>Data: </b><span>"+dataOdczytu+"</span></p>";

            result += "<table cellpadding=\"0px\"cellspacing=\"5px\" style=\"page-break-inside: avoid; margin:0; padding:0;border-collapse: collapse; text-align: center; border-style:solid; border-color: black; font-size:10px; width: 100%;\">";
            result += "<tr><td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Nazwa</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Moduł</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Średnia arytmetyczna z odczytów dokonywanych co pełną minutę w ciągu całej doby</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Wartość temperatury przy maksymalnym przekroczeniu dopuszczalnej temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Czas trwania maksymalnego przekroczenia temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Liczba wszystkich przypadków  przekroczenia maksymalnej dopuszczalnej temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Sumaryczny czas trwania wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\"><b>Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur Kolumna 5*100/24</b></td></tr>";

            for(int i = 0; i < dataGridView.Rows.Count; i++)
            {
                result += "<tr>";

                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells[0].Value.ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells[1].Value.ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells["Średnia arytmetyczna z odczytów"].Value.ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells["Wartość temperatury przy maksymalnym przekroczeniu dopuszczalnej temperatury"].Value.ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells["Czas trwania maksymalnego przekroczenia temperatury"].Value.ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells["Liczba wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury"].Value.ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells["Sumaryczny czas trwania wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury"].Value.ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle+"; border-width: "+borderWidth+"px;\">" + dataGridView.Rows[i].Cells["Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur"].Value.ToString() + "</td>";

                result += "</tr>";
            }
            result += "</table>";
            return result;
        }

        private void ZapiszPlik(string fileNameSave, string result)
        {
            using(FileStream fs = new FileStream(fileNameSave, FileMode.Create))
            {
                using(StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(result);
                }
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            String sklepEmail = "";
            String centralaEmail = "";
            String result = "";
            String kod = "";

            DBRepository db = new DBRepository();

            if(db.LoadDataForm_PobierzMaile(nazwaSklepu, ref sklepEmail, ref centralaEmail, ref result, ref kod))
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                desktopPath += "\\" + nazwaSklepu + "-" + dataOdczytu + ".pdf";

                result = "<html><head><meta http-equiv=Content-Type content=\"text/html; charset = utf-8\"><title>" + nazwaSklepu + "-" + dataOdczytu.Replace(".", "") + ".pdf" + "</title></head><body style=\"font - family: Tahoma, Verdana, Segoe, sans - serif; font - size:10px; page-break-inside: avoid;\">";
                result += DodajDane(1, "solid");
                result += "</body></html>";

                Byte[] bytes = PdfSharpConvert(result);

                var testFile = Path.GetFullPath(desktopPath);
                System.IO.File.WriteAllBytes(testFile, bytes);
                
                SendMail("", sklepEmail, desktopPath);
                SendMail("", centralaEmail, desktopPath);
            }
            else
            {
                if(kod == "1")
                {
                    MessageBox.Show("Sklep "+nazwaSklepu+" nie ma przypisanych adresów email. Proszę uzupełnić i ponowić wysyłanie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas próby pobrania adresów email:\n" + result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SendMail(String body, String mail, String attachmentFilename)
        {
            String e_mail_od = "rejestrator@frigocentrum.com";
            String haslo = "Frig@123";
            Int32 port = 587;
            String smtp = "poczta.superhost.pl";
            String e_mail_do = mail;

            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress(e_mail_od, e_mail_od);
            emailMessage.To.Add(new MailAddress(e_mail_do, e_mail_do));
            emailMessage.Subject = "Raport temperatur z dnia " + dataOdczytu + " z "+nazwaSklepu;
            emailMessage.IsBodyHtml = true;
            emailMessage.Body = body;
            emailMessage.Priority = MailPriority.Normal;
            SmtpClient MailClient = new SmtpClient(smtp, port);
            // MailClient.EnableSsl = true;
            MailClient.Credentials = new System.Net.NetworkCredential(e_mail_od, haslo);

            Attachment attachment = new Attachment(attachmentFilename, MediaTypeNames.Application.Octet);
            ContentDisposition disposition = attachment.ContentDisposition;
            disposition.CreationDate = File.GetCreationTime(attachmentFilename);
            disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
            disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
            disposition.FileName = Path.GetFileName(attachmentFilename);
            disposition.Size = new FileInfo(attachmentFilename).Length;
            disposition.DispositionType = DispositionTypeNames.Attachment;
            emailMessage.Attachments.Add(attachment);

            try
            {
                MailClient.Send(emailMessage);
                MessageBox.Show("Wysłano na adres " + mail + ".", "Potwierdzenie wysłania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void savePDFButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = nazwaSklepu+"-"+dataOdczytu.Replace(".", "") + ".pdf";
            saveDialog.Filter = "Pliki PDF|.pdf|Wszystkie pliki|*.*";

            DialogResult dialogResult = saveDialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                String result = "<html><head><meta http-equiv=Content-Type content=\"text/html; charset = utf-8\"><title>" + nazwaSklepu + "-" + dataOdczytu.Replace(".", "") + ".pdf" + "</title></head><body style=\"font - family: Tahoma, Verdana, Segoe, sans - serif; font - size:10px; page-break-inside: avoid;\">";
                result += DodajDane(1, "solid");
                result += "</body></html>";

                Byte[] bytes = PdfSharpConvert(result);
                
                var testFile = Path.GetFullPath(saveDialog.FileName);
                System.IO.File.WriteAllBytes(testFile, bytes);
            }
        }

        public static Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using(MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.PageLayout = PdfSharp.Pdf.PdfPageLayout.OneColumn;
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }

        private void dataOdczytuLabel_Click(object sender, EventArgs e)
        {

        }

        private void nazwaSklepuLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

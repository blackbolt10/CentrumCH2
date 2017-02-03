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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentrumChlodnictwa
{
    public partial class WysylanieDanychForm : Form
    {
        private DataTable mailDT;
        private DataTable daneWynikoweDT;
        private DataTable tempDT;

        private Int32 sklepID;

        private Thread thread;
        private Thread tempThread;

        private String fileName = "";
        private String tempFileName = "";
        private String danePDF = "";
        private String daneTemp = "";

        public WysylanieDanychForm(Int32 _sklepID, String _nazwaSklepu, String _dataOdczytu, DataTable _tempDT)
        {
            InitializeComponent();

            sklepID = _sklepID;
            sklepLabel.Text = _nazwaSklepu;
            dataLabel.Text = _dataOdczytu;
            tempDT = _tempDT;
            formatCB.SelectedIndex = 0;           
        }

        private void WysylanieDanychForm_Shown(object sender, EventArgs e)
        {
            UstawProgressBarValue(0);
            timer.Start();

            thread = new Thread(() => PobierzDaneWynikowe());
            thread.Start();

            tempThread = new Thread(() => PrzygotujRaportTemperatur());
            tempThread.Start();

            ZaladujAdresyMail();
        }

        private void PrzygotujRaportTemperatur()
        {
            if(tempDT != null)
            {
                daneTemp = "";
                int borderWidth = 1;
                string borderStyle = "dotted";

                daneTemp = " <html><head><meta http-equiv=Content-Type content=\text/html; charset=utf-8\"><title>" + sklepLabel.Text + "-" + dataLabel.Text.Replace(".", "") + ".pdf" + "</title></head><body style=\"font-family: Tahoma, Verdana, Segoe, sans-serif; font-size:10px; page-break-inside: avoid;\">";
                daneTemp += "<p><b>Market: </b><span>" + sklepLabel.Text + "</span><br>";
                daneTemp += "<b>Data: </b><span>" + dataLabel.Text + "</span></p>";

                daneTemp += "<table cellpadding=\"0px\" cellspacing=\"5px\" style=\"page-break-inside: avoid; margin:0; padding:0;border-collapse: collapse; text-align: center; border-style:solid; border-color: black; font-size:10px; width: 100%;\">";
                daneTemp += "<tr><td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Nazwa</b></td>";
                daneTemp += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Odczyt temperatury z godz. 01:00</b></td>";
                daneTemp += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Odczyt temperatury z godz. 05:00</b></td>";
                daneTemp += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Odczyt temperatury z godz. 09:00</b></td>";
                daneTemp += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Odczyt temperatury z godz. 13:00</b></td>";
                daneTemp += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Odczyt temperatury z godz. 17:00</b></td>";
                daneTemp += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Odczyt temperatury z godz. 21:00</b></td></tr>";

                for(int i = 0; i < tempDT.Rows.Count; i++)
                {
                    daneTemp += "<tr>";

                    daneTemp += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + tempDT.Rows[i]["Name"].ToString() + "</td>";
                    daneTemp += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + tempDT.Rows[i]["01:00"].ToString() + "</td>";
                    daneTemp += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + tempDT.Rows[i]["05:00"].ToString() + "</td>";
                    daneTemp += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + tempDT.Rows[i]["09:00"].ToString() + "</td>";
                    daneTemp += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + tempDT.Rows[i]["13:00"].ToString() + "</td>";
                    daneTemp += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + tempDT.Rows[i]["17:00"].ToString() + "</td>";
                    daneTemp += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + tempDT.Rows[i]["21:00"].ToString() + "</td>";

                    daneTemp += "</tr>";
                }
                daneTemp += "</table>";
                daneTemp += "</body></html>";

                tempFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                tempFileName += "\\Raport_temperatur_"+sklepLabel.Text + "-" + dataLabel.Text + ".pdf";
            }
        }

        private void PobierzDaneWynikowe()
        {
            UstawOpisOperacji("Pobieranie raportu...");

            DBRepository db = new DBRepository(1);
            String result = "";

            if(db.WysylanieDanych_GetRaportPomiarutemperatur(sklepID, dataLabel.Text, ref daneWynikoweDT, ref result))
            {
                PrzygotujDanePDF();
            }
            else
            {
                MessageBox.Show(result, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tempThread.Join();

            timer.Stop();
            UstawProgressBarValue(10);
            UstawOpisOperacji("Gotowy do wysyłania.");
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
        

        private void trescRB_CheckedChanged(object sender, EventArgs e)
        {
            formatCB.Enabled = !trescRB.Checked;
        }

        private void ZaladujAdresyMail()
        {
            mailCLB.Items.Clear();
            mailDT = new DataTable();
            sendButton.Enabled = false;

            DBRepository db = new DBRepository();
            String result = "";

            if(db.WysylanieDanych_GetMailList(sklepID, ref mailDT, ref result))
            {
                if(mailDT.Rows.Count>0)
                {
                    for(int i = 0; i < mailDT.Rows.Count; i++)
                    {
                        mailCLB.Items.Add(mailDT.Rows[i]["SKM_Mail"].ToString() + " ("+mailDT.Rows[i]["SKM_Nazwa"].ToString()+")");
                    }

                    sendButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(result, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            AktywujObiekty(false);

            timer.Start();

            thread.Join();
            thread = new Thread(() => WysylanieMaili());
            thread.Start();            
        }

        private void WysylanieMaili()
        {
            UstawOpisOperacji("Generowanie listy mailowej...");

            List<int> mailIndexList = new List<int>();

            for(int i = 0; i < mailCLB.Items.Count; i++)
            {
                if(mailCLB.GetItemChecked(i))
                {
                    mailIndexList.Add(i);
                }
            }

            if(mailIndexList.Count > 0)
            {
                if(zalacznikRB.Checked)
                {
                    switch(GetSelectedIndexFromCB(formatCB))
                    {
                        case 0:
                            WygenerujPlikPDF(danePDF, fileName);
                        break;

                        case 1:
                            WygenerujPlikHTML();
                        break;
                    }
                }

                if(rapTempCB.Checked)
                {
                    WygenerujPlikPDF(daneTemp, tempFileName);
                }

                SendMailsWithAtachement(mailIndexList);

                UstawOpisOperacji("Wysyłanie zakończone...");
                ZamknijOkno();
            }
            else
            {
                UstawOpisOperacji("Wysyłanie zatrzymane...");
                MessageBox.Show("Brak zaznaczonych adresów do wysłania.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                timer.Stop();
                UstawProgressBarValue(10);
                AktywujObiekty(true);
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void WygenerujPlikHTML()
        {
            UstawOpisOperacji("Generowanie pliku html...");

            fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileName += "\\" + sklepLabel.Text + "-" + dataLabel.Text + ".html";

            using(FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using(StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(danePDF);
                }
            }
        }

        private void SendMailsWithAtachement(List<int> mailIndexList)
        {
            for(int i = 0; i < mailIndexList.Count; i++)
            {
                UstawOpisOperacji("Wysyłanie maila " + (i + 1).ToString() + "/" + mailIndexList.Count + "...");

                SendMail("", mailDT.Rows[mailIndexList[i]]["SKM_Mail"].ToString(), fileName);
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
            emailMessage.Subject = "Raport temperatur z dnia " + dataLabel.Text + " z " + sklepLabel.Text;
            emailMessage.IsBodyHtml = true;
            emailMessage.Body = body;
            emailMessage.Priority = MailPriority.Normal;
            SmtpClient MailClient = new SmtpClient(smtp, port);
            // MailClient.EnableSsl = true;
            MailClient.Credentials = new System.Net.NetworkCredential(e_mail_od, haslo);

            if(zalacznikRB.Checked)
            {
                Attachment attachment = new Attachment(attachmentFilename, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(attachmentFilename);
                disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
                disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
                disposition.FileName = Path.GetFileName(attachmentFilename);
                disposition.Size = new FileInfo(attachmentFilename).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                emailMessage.Attachments.Add(attachment);
            }
            else
            {
                emailMessage.Body = "\n\n"+danePDF;
            }

            if(rapTempCB.Checked)
            {
                Attachment attachment = new Attachment(tempFileName, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(tempFileName);
                disposition.ModificationDate = File.GetLastWriteTime(tempFileName);
                disposition.ReadDate = File.GetLastAccessTime(tempFileName);
                disposition.FileName = Path.GetFileName(tempFileName);
                disposition.Size = new FileInfo(tempFileName).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                emailMessage.Attachments.Add(attachment);
            }

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

        private void PrzygotujDanePDF()
        {
            UstawOpisOperacji("Generowanie raportu...");

            danePDF = "<html><head><meta http-equiv=Content-Type content=\text/html; charset=utf-8\"><title>" + sklepLabel.Text + "-" + dataLabel.Text.Replace(".", "") + ".pdf" + "</title></head><body style=\"font - family: Tahoma, Verdana, Segoe, sans - serif; font - size:10px; page-break-inside: avoid;\">";
            danePDF += DodajDane(1, "solid");
            danePDF += "</body></html>";
        }

        private void UstawOpisOperacji(String text)
        {
            MethodInvoker inv = delegate
            {
                this.opisTSSL.Text = text;
            };

            this.Invoke(inv);
        }

        private void AktywujObiekty(Boolean param)
        {
            MethodInvoker inv = delegate
            {
                sendButton.Enabled = param;
                cancelButton.Enabled = param;
                mailCLB.Enabled = param;
                zalacznikRB.Enabled = param;
                formatCB.Enabled = param;
                trescRB.Enabled = param;
            };

            this.Invoke(inv);
        }

        private void UstawProgressBarValue(Int32 value)
        {
            MethodInvoker inv = delegate
            {
                this.toolStripProgressBar1.Value = value;
            };

            this.Invoke(inv);
        }

        private void ZamknijOkno()
        {
            MethodInvoker inv = delegate
            {
                this.timer.Stop();
                this.Close();
            };

            this.Invoke(inv);
        }

        private int GetSelectedIndexFromCB(ComboBox comboBox)
        {
            Int32 index = -1;
            MethodInvoker inv = delegate
            {
                index = comboBox.SelectedIndex;
            };

            this.Invoke(inv);
            return index;
        }

        private void WygenerujPlikPDF(String dane, String filenameString)
        {
            String[] nazwaArray = filenameString.Split('\\');
            UstawOpisOperacji(nazwaArray[nazwaArray.Length-1]);
            
            Byte[] bytes = PdfSharpConvert(dane);

            var file = Path.GetFullPath(filenameString);
            System.IO.File.WriteAllBytes(file, bytes);
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

        private string DodajDane(int borderWidth = 1, string borderStyle = "dotted")
        {
            String result = "<p><b>Market: </b><span>" + sklepLabel.Text + "</span><br>";
            result += "<b>Data: </b><span>" + dataLabel.Text + "</span></p>";

            result += "<table cellpadding=\"0px\"cellspacing=\"5px\" style=\"page-break-inside: avoid; margin:0; padding:0;border-collapse: collapse; text-align: center; border-style:solid; border-color: black; font-size:10px; width: 100%;\">";
            result += "<tr><td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Nazwa</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Średnia arytmetyczna z odczytów dokonywanych co pełną minutę w ciągu całej doby</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Wartość temperatury przy maksymalnym przekroczeniu dopuszczalnej temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Czas trwania maksymalnego przekroczenia temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Liczba wszystkich przypadków  przekroczenia maksymalnej dopuszczalnej temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Sumaryczny czas trwania wszystkich przypadków przekroczenia maksymalnej dopuszczalnej temperatury</b></td>";
            result += "<td style=\"border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\"><b>Procentowy udział czasu przechowywania środka spożywczego poza dopuszczalnym zakresem temperatur Kolumna 5*100/24</b></td></tr>";

            for(int i = 0; i < daneWynikoweDT.Rows.Count; i++)
            {
                result += "<tr>";

                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + daneWynikoweDT.Rows[i]["Urzadzenie"].ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + daneWynikoweDT.Rows[i]["Średnia arytm (1)"].ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + daneWynikoweDT.Rows[i]["MaxPrzekroczenie (2)"].ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + daneWynikoweDT.Rows[i]["Sumaryczny czas max przekroczenia (3)"].ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + daneWynikoweDT.Rows[i]["Liczba przypadków"].ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + daneWynikoweDT.Rows[i]["Czas trwania przekroczeń"].ToString() + "</td>";
                result += "<td style=\"page-break-inside: avoid; border-color: black; border-style: " + borderStyle + "; border-width: " + borderWidth + "px;\">" + daneWynikoweDT.Rows[i]["Procentowy udział"].ToString() + "</td>";

                result += "</tr>";
            }
            result += "</table>";

            fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileName += "\\" + sklepLabel.Text + "-" + dataLabel.Text + ".pdf";

            return result;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Int32 wartosc = -1;
            Int32 max = -1;

            MethodInvoker inv = delegate
            {
                wartosc = this.toolStripProgressBar1.Value;
                max = this.toolStripProgressBar1.Maximum;
            };
            this.Invoke(inv);

            if(wartosc<max)
            {
                wartosc++;
            }
            else
            {
                wartosc = 0;
            }

            UstawProgressBarValue(wartosc);
        }

        private void WysylanieDanychForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempThread.Abort();
            thread.Abort();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrumChlodnictwa
{
    class DBRepository
    {
        public static SqlConnection DBConnection;
        public static SqlConnection DBConnectionThread;
        private int Timeout = 240;


        public DBRepository(String connect)
        {
            DBConnection = null;
            ConnectDataBase();
        }

        public DBRepository()
        {
            if(DBConnection == null)
            {
                ConnectDataBase();
            }
        }

        public DBRepository(Int32 thread)
        {
            ConnectDataBaseThread();            
        }

        public Boolean ConnectDataBaseThread()
        {
            Boolean connectionResult = false;
            Passwords passwords = new Passwords();

            try
            {
                String DBLogin = passwords.GetInstanceUserName();
                String DBPassword = passwords.GetInstancePassword();
                String DBInstance = passwords.GetInstanceName();
                String DBName = passwords.GetDataBaseName();

                DBConnectionThread = new SqlConnection(@"user id=" + DBLogin + "; password=" + DBPassword + "; Data Source=" + DBInstance + "; Initial Catalog=" + DBName + ";");
                connectionResult = true;
            }
            catch(Exception) { }

            return connectionResult;
        }

        public DataTable queryThread(string queryString)
        {
            DBConnectionThread.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempDataTable = new DataTable();

            SqlCommand polecenieSQL = new SqlCommand(queryString);
            polecenieSQL.CommandTimeout = Timeout;
            polecenieSQL.Connection = DBConnection;
            da = new SqlDataAdapter(polecenieSQL);
            da.Fill(tempDataTable);

            DBConnectionThread.Close();

            return tempDataTable;
        }


        public Boolean ConnectDataBase()
        {
            Boolean connectionResult = false;
            Passwords passwords = new Passwords();

            try
            {
                String DBLogin = passwords.GetInstanceUserName();
                String DBPassword = passwords.GetInstancePassword();
                String DBInstance = passwords.GetInstanceName();
                String DBName = passwords.GetDataBaseName();

                DBConnection = new SqlConnection(@"user id=" + DBLogin + "; password=" + DBPassword + "; Data Source=" + DBInstance + "; Initial Catalog=" + DBName + ";");
                DBConnection.Open();
                connectionResult = true;
            }
            catch(Exception) { }

            return connectionResult;
        }

        public DataTable query(string queryString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempDataTable = new DataTable();

            SqlCommand polecenieSQL = new SqlCommand(queryString);
            polecenieSQL.CommandTimeout = Timeout;
            polecenieSQL.Connection = DBConnection;
            da = new SqlDataAdapter(polecenieSQL);
            da.Fill(tempDataTable);

            return tempDataTable;
        }

        public bool WysylanieDanych_GetMailList(int sklepID, ref DataTable mailDT, ref string result)
        {
            String zapytanie = "select * from gal.Sklepy join gal.Maile on skl_sklid = SKM_SklId where SKL_Archiwalny = 0 and SKM_Archiwalny = 0 and SKL_SklId = "+sklepID;

            try
            {
                mailDT = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("WysylanieDanych_GetMailList", result);
            }
            return false;
        }

        public bool UrzadzeniaUstawienia_ZaladujSklepy(ref DataTable sklepyDT, ref string result)
        {
            String zapytanie = "Select SKL_SklId, SKL_Nazwa from GAL.Sklepy";

            try
            {
                sklepyDT = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("UrzadzeniaUstawienia_ZaladujSklepy", result);
            }
            return false;
        }

        public bool GetDate(ref String result)
        {
            String zapytanie = "Select getdate()";

            try
            {
                DataTable pomDatatable = queryThread(zapytanie);
                
                if(pomDatatable.Rows.Count>0)
                {
                    result = pomDatatable.Rows[0][0].ToString();
                }
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("UrzadzeniaUstawienia_ZaladujSklepy", result);
            }
            return false;
        }

        public bool SklepImport_AddMail(string idSklepu, string nazwaEmail, string email, ref string result)
        {
            String zapytanie = "exec GAL.DodanieMaila 'add', '" + email + "', '" + nazwaEmail + "', " + idSklepu + ", null";
            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count > 0)
                {
                    if(pomDataTable.Rows[0][0].ToString() == "-1")
                    {
                        result = pomDataTable.Rows[0][1].ToString();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch(Exception exc)
            {
                MainForm.raportBledu("SklepImport_AddMail", exc.Message);
                result = exc.Message;

                return false;
            }
        }

        public bool WysylanieDanych_GetRaportPomiarutemperatur(int sklepID, string data, ref DataTable daneWynikoweDT, ref string result)
        {
            String zapytanie = "exec GAL.RaportPomiaruTemperatur " + sklepID + ", '" + data + "'";
            try
            {
                daneWynikoweDT = queryThread(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("WysylanieDanych_GetRaportPomiarutemperatur", result);
            }
            return false;
        }

        public bool SklepImport_AddSklep(string nazwaSklepu, ref string idSklepu, ref string result)
        {
            String zapytanie = "exec GAL.DodanieSklepu '"+nazwaSklepu+"'";
            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count > 0)
                {
                    result = pomDataTable.Rows[0][0].ToString();
                    idSklepu = pomDataTable.Rows[0][1].ToString();
                    return true;
                }
                else
                {
                    result = "Brak informacji zwrotnej z bazy danych";
                    MainForm.raportBledu("SklepImport_AddSklep", result);
                    return false;
                }
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("SklepImport_AddSklep", result);

                return false;
            }
        }

        public bool SklepyMailDodawanie_ZaladujSklepy(ref DataTable sklepyDT, ref string result)
        {
            String zapytanie = "Select SKL_SklId, SKL_Nazwa from GAL.Sklepy where SKL_Archiwalny <> 1";

            try
            {
                sklepyDT = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("SklepyMailDodawanie_ZaladujSklepy", result);
            }
            return false;
        }

        public bool UrzadzeniaDodawanie_AddTemp(string sklepID, string urzadzenieNazwa, string modul, string tempMin, string tempMax, string archiwalne, ref string result)
        {
            String zapytanie = "insert into GAL.Urzadzenia values(" + sklepID+", '" + urzadzenieNazwa + "', '" + modul + "', '" + tempMin + "', '" + tempMax + "', "+archiwalne+")";
            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                MainForm.raportBledu("UrzadzeniaDodawanie_AddTemp", exc.Message);
                result = exc.Message;

                return false;
            }
        }

        public bool SklepyMailDodawanie_AddMail(string SKL_SklID, string email, string nazwa, ref string result)
        {
            String zapytanie = "exec GAL.DodanieMaila 'add', '"+email+"', '"+nazwa+"', "+ SKL_SklID+", null";
            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count>0)
                {
                    if(pomDataTable.Rows[0][0].ToString() == "-1")
                    {
                        result = pomDataTable.Rows[0][1].ToString();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch(Exception exc)
            {
                MainForm.raportBledu("SklepyMailDodawanie_AddMail", exc.Message);
                result = exc.Message;

                return false;
            }
        }

        public bool SklepyMailDodawanie_ModMail(string SKL_SklID, string SKM_SkmID, string email, string nazwa, ref string result)
        {
            String zapytanie = "exec GAL.DodanieMaila 'mod', '" + email + "', '" + nazwa + "', " + SKL_SklID + ", "+ SKM_SkmID;
            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count > 0)
                {
                    if(pomDataTable.Rows[0][0].ToString() == "-1")
                    {
                        result = pomDataTable.Rows[0][1].ToString();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch(Exception exc)
            {
                MainForm.raportBledu("SklepyMailDodawanie_ModMail", exc.Message);
                result = exc.Message;

                return false;
            }
        }

        public bool SklepyMailDodawanie_DelMail(string sKM_SkmID, ref string result)
        {
            string zapytanie = "exec GAL.DodanieMaila 'del', null, null, null, "+ sKM_SkmID;

            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count > 0)
                {
                    if(pomDataTable.Rows[0][0].ToString() == "-1")
                    {
                        result = pomDataTable.Rows[0][1].ToString();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("SklepyMailDodawanie_DelMail", exc.Message);
                return false;
            }
        }

        public bool UrzadzeniaDodawanie_ModMail(string urzadzenieID, string sklepID, string urzadzenieNazwa, string modul, string tempMin, string tempMax, string archiwalne, ref string result)
        {
            String zapytanie = "UPDATE GAL.Urzadzenia SET URZ_SklID = " + sklepID + ", URZ_Nazwa = '" + urzadzenieNazwa + "', URZ_Modul = '" + modul + "', URZ_TempMin = '" + tempMin + "', URZ_TempMax = '" + tempMax + "', URZ_Archiwalne = "+archiwalne+" WHERE URZ_URZId = " + urzadzenieID;
            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                MainForm.raportBledu("UrzadzeniaDodawanie_ModMail", exc.Message);
                result = exc.Message;

                return false;
            }
        }

        public bool TempUstawiania_DelTemp(string rowID, ref string result)
        {
            string zapytanie = "UPDATE GAL.Urzadzenia SET URZ_Archiwalne = 1 WHERE URZ_URZId = " + rowID;

            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("TempUstawiania_DelTemp", exc.Message);
                return false;
            }
        }

        public Boolean SklepyUstawienia_ZaladujMailDatagridView(Boolean archiwalnySklep, Boolean archiwalnyMail, ref DataTable pomDataTable, ref String result)
        {
            string zapytanie = "select * from gal.Sklepy skl left outer join gal.Maile skm on skm.SKM_SklId = skl.SKL_SklId where 1=1 ";

            if(!archiwalnySklep)
            {
                zapytanie+= " and skl.SKL_Archiwalny = 0";
            }

            if(!archiwalnyMail)
            {
                zapytanie += " and (skm.SKM_Archiwalny = 0 or skm.SKM_Archiwalny is null)";
            }

            zapytanie += " order by skl.SKL_Nazwa asc, skm.SKM_Nazwa asc";


            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("SklepyUstawiania_DelShop", exc.Message);
                return false;
            }
        }

        public Boolean SklepyUstawiania_DelShop(string rowID, ref string result)
        {
            string zapytanie = "UPDATE GAL.Sklepy SET SKL_Archiwalny = 1 WHERE SKL_SklId =" + rowID;

            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("SklepyUstawiania_DelShop", exc.Message);
                return false;
            }
        }

        public bool ReadDataForm_GenerujNaglowek(string nazwaSklepu, string dataOdczytu, string zrodlo,ref int sklepID, ref int wynik, ref string result)
        {
            String zapytanie = "exec GAL.DodanieOdczytuNagl '" + nazwaSklepu+"', '"+ dataOdczytu + "', '"+ zrodlo + "'";
            try
            {
                DataTable pomDataTable = query(zapytanie);
                if(pomDataTable.Rows.Count == 1)
                {
                    wynik = Convert.ToInt32(pomDataTable.Rows[0][0].ToString());

                    if(wynik != -1)
                    {
                        sklepID = Convert.ToInt32(pomDataTable.Rows[0][1].ToString());
                    }
                    else
                    {
                        result = pomDataTable.Rows[0][1].ToString();
                        return false;
                    }
                }
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("ReadDataForm_GenerujNaglowek", result);
            }
            return false;
        }

        public Boolean ReadDataForm_ZapiszOdczyt(int sklepID, int nagID, string nazwaUrzadzenia, string modulUrzadzenia, string czasPomiaru, decimal? wartosc, string stan, ref string result)
        {
            String wartoscString = "null";

            if(wartosc.HasValue)
            {
                wartoscString = wartosc.ToString();
            }

            String zapytanie = "exec GAL.DodanieOdczytuElem " + sklepID + ", "+nagID+", '"+ nazwaUrzadzenia + "', '"+ modulUrzadzenia +" ', '"+czasPomiaru.Replace('-',':')+"', "+ wartoscString + ", '"+stan+"'";
            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("UrzadzeniaUstawienia_ZaladujTempDataGridView", result);
            }
            return false;
        }

        public bool UrzadzeniaUstawienia_ZaladujTempDataGridView(Int32 sklepID, Boolean archiwalne, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "Select * from GAL.Urzadzenia where URZ_SklID = " + sklepID;

            if(!archiwalne)
            {
                zapytanie += " and URZ_Archiwalne = 0";
            }

            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("UrzadzeniaUstawienia_ZaladujTempDataGridView",result);
            }

            return false;
        }

        public bool SklepyDodawanie_ModShop(string sklepID, string nazwa, string archiwalny, ref string result)
        {
            String zapytanie = "UPDATE GAL.Sklepy SET SKL_Nazwa = '"+ nazwa + "', SKL_Archiwalny = " + archiwalny + " WHERE SKL_SklId = "+sklepID;
            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                MainForm.raportBledu("SklepyDodawanie_ModShop", exc.Message);
                result = exc.Message;

                return false;
            }
        }

        public Boolean SklepyDodawanie_AddShop(string sklepNazwa, string archiwalny, ref string result, ref string wiadomosc)
        {
            String zapytanie = "exec GAL.DodanieSklepu '" + sklepNazwa + "', " + archiwalny;
            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count==1)
                {
                    if(pomDataTable.Rows[0][0].ToString() == "-1")
                    {
                        result = "-1";
                        wiadomosc = pomDataTable.Rows[0][1].ToString();
                    }
                    else
                    {
                        result = pomDataTable.Rows[0][0].ToString();
                    }
                }
                return true;
            }
            catch(Exception exc)
            {
                MainForm.raportBledu("SklepyDodawanie_AddShop", exc.Message);
                result = exc.Message;

                return false;
            }
        }

        public bool LoadDataForm_PobierzMaile(string nazwaSklepu, ref string sklepEmail, ref string centralaEmail, ref string result, ref String kod)
        {
            String zapytanie = "SELECT SKL_SklepMail, SKL_CentralaMail FROM GAL.Sklepy Where SKL_Nazwa = '"+ nazwaSklepu + "'";
            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count == 1)
                {
                    sklepEmail = pomDataTable.Rows[0]["SKL_SklepMail"].ToString();
                    centralaEmail = pomDataTable.Rows[0]["SKL_CentralaMail"].ToString();

                    return true;
                }
                else if(pomDataTable.Rows.Count == 0)
                {
                    kod = "1";
                }
                else
                {
                    result = "Pobrano więcej niż jeden wierz danych o nazwie sklepu '" + nazwaSklepu + "'. Proszę sprawdzić na liście, czy nie występują duplikaty.";
                }
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("LoadDataForm_PobierzMaile", result);
            }
            return false;
        }

        public bool LoadDataForm_OdczytajTemp(string nazwa, string modul, ref int? tempMin, ref int? tempMax, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL.Urzadzenia where URZ_Nazwa = '"+ nazwa + "' and URZ_Modul = '"+ modul+"'";

            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count==1)
                {
                    if(pomDataTable.Rows[0]["URZ_TempMin"].ToString() == "")
                    {
                        tempMin = null;
                    }
                    else
                    {
                        tempMin = ZwrocTemperature(pomDataTable.Rows[0]["URZ_TempMin"].ToString());
                    }

                    if(pomDataTable.Rows[0]["URZ_TempMax"].ToString() == "")
                    {
                        tempMax = null;
                    }
                    else
                    {
                        tempMax = ZwrocTemperature(pomDataTable.Rows[0]["URZ_TempMax"].ToString());
                    }
                     
                    return true;
                }
                else if(pomDataTable.Rows.Count>1)
                {
                    result = "Znaleziono więcej niż jedna dopuszczalna temperatura. Proszę sprawdzić listę temperatur pod względem zduplikowanych urządzeń.";
                    return false;
                }
                else if(pomDataTable.Rows.Count == 0)
                {
                    result = "Urządzenie '"+nazwa+"-"+modul+"' nie zostało znalezione.";
                    return false;
                }
                else
                {
                    result = "Nie mam pojęcia co tutaj nalezy napisac... Jak wystąpi ten błąd to... Poinformuj nas, że słońce się zatrzymało.";
                    return false;
                }
            }
            catch(Exception exc)
            {
                result = exc.Message;
                MainForm.raportBledu("LoadDataForm_OdczytajTemp", result);
            }


            return false;
        }

        private int? ZwrocTemperature(string v)
        {
            String temp = v.Replace('.', ',');
            Decimal tempWart = Convert.ToDecimal(temp);
            return Convert.ToInt32(tempWart); 
        }
    }
}

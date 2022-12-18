using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    public class VeterinariMazlickyPohledViewModel
    {
        public VeterinariMazlickyPohledViewModel() {
            LoadVeterinariMazlicky();
        }

        public ObservableCollection<VeterinariMazlickyPohled> VeterinariMazlicky {
            get;
            set;
        }

        public void LoadVeterinariMazlicky() {
            ObservableCollection<VeterinariMazlickyPohled> veterinariMazlicky = new ObservableCollection<VeterinariMazlickyPohled>();

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql1.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=IDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            MessageBox.Show("Connected to Oracle Database", con.ServerVersion);



            OracleCommand getView = new OracleCommand();
            getView.Connection = con;
            getView.CommandText = "SELECT JMENO_MAZLICEK, DRUH_ZVIRE, JMENO_MAJITEL, PRIJMENI_MAJITEL, TEL_CISLO, EMAIL, NAZEV_MESTA, NAZEV_ULICE, CISLO_ULICE, PSC_KOD, STAT, DATUM_NASTUPU, DATUM_PROPUSTENI, NAZEV_ODDELENI" +
                " FROM VETERINARI_MAZLICKY_VIEW";
            OracleDataReader readerView = getView.ExecuteReader();

            if (readerView.HasRows)
            {
                while (readerView.Read())
                {
                    veterinariMazlicky.Add(new VeterinariMazlickyPohled { 
                        Jmeno_mazlicek = readerView["JMENO_MAZLICEK"].ToString(),


                        Druh_zvire = readerView["DRUH_ZVIRE"].ToString(), 

                        //Druh_zvire = "Sobaka",

                        Jmeno_majitele = readerView["JMENO_MAJITEL"].ToString(),
                        Primeni_majitele = readerView["PRIJMENI_MAJITEL"].ToString(),
                        Tel_cislo = readerView["TEL_CISLO"].ToString(),


                        Emeil = readerView["EMAIL"].ToString(),
                        Nazev_mesta = readerView["NAZEV_MESTA"].ToString(),
                        Nazev_ulice = readerView["NAZEV_ULICE"].ToString(),
                        
                        
                        Cislo_ulice = int.Parse(readerView["CISLO_ULICE"].ToString()),

                        //Cislo_ulice = 6,

                        Psc_kod = readerView["PSC_KOD"].ToString(),
                        Stat = readerView["STAT"].ToString(),
                        //Datum_nastupu = DateTime.ParseExact(readerView["DATUM_NASTUPU"].ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                        ////Datum_propusteni = DateTime.ParseExact(readerView["DATUM_PROPUSTENI"].ToString(), "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AllowWhiteSpaces),

                        Datum_nastupu = new DateTime(2013, 6, 1, 12, 32, 30),
                        Datum_propusteni = new DateTime(2013, 6, 1, 12, 32, 30),

                        Nazev_oddeleni = readerView["NAZEV_ODDELENI"].ToString()


                    });
                    VeterinariMazlicky = veterinariMazlicky;

                    //MainListView.Items.Add(readerView["JMENO_MAZLICEK"].ToString());
                }
            }
            con.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.View;
using VetClinic.Model;
using VetClinic.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System.Windows;

namespace VetClinic
{
    public class FakturyWindowService : IWindowService
    {
        public void CreateWindow()
        {
            if (ListOfWindows.GetFakturyWindow() != null) {
                return;
            }
            FakturyWindow window = new FakturyWindow(); 
            window.Show();
            ListOfWindows.AddWindow(window);
        }

        public void AddFakturu() {
            // TODO FakturaWindow add logic
            var window = ListOfWindows.GetFakturyWindow();

            string jmenoMazlicka = "Arigol";
            string primeniMajitele = "Antonov";
            DateTime? dateTime = null;
            string konecnaCena = window.konecnaCena.Text;
            string nazevSluzby = window.jmenoMazlickaComboBox.SelectedItem.ToString();

            if (window.datumVystaveniDatePicker.SelectedDate.HasValue)
            {
                dateTime = window.datumVystaveniDatePicker.SelectedDate.Value;
            }

            bool canAdd = jmenoMazlicka != "" && primeniMajitele != "" 
                          && dateTime != null && konecnaCena != "" && nazevSluzby != "";

            if (canAdd)
            {
                string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                            "user id=st64150;password=vova0107;" +
                            "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

                OracleConnection con = new OracleConnection(constr);
                con.Open();
                //MessageBox.Show("Connected to Oracle Database From Tab1", con.ServerVersion);

                OracleCommand addFacturu = new OracleCommand("VLOZ_FAKTURU", con);
                addFacturu.CommandType = System.Data.CommandType.StoredProcedure;

                addFacturu.Parameters.Add("KON_CENA", OracleDbType.Int16).Value = konecnaCena;
                addFacturu.Parameters.Add("POPIS", OracleDbType.Varchar2).Value = "popis";
                addFacturu.Parameters.Add("DATUM_VYSTAVENI", OracleDbType.Date).Value = DateTime.Now;
                addFacturu.Parameters.Add("JMENO_MAZLICKA", OracleDbType.Varchar2).Value = jmenoMazlicka;
                addFacturu.Parameters.Add("PRIMENI_MAJITELE", OracleDbType.Varchar2).Value = primeniMajitele;
                addFacturu.Parameters.Add("NAZEV_SLUZBY", OracleDbType.Varchar2).Value = "Siti";

                OracleDataAdapter da = new OracleDataAdapter(addFacturu);
                addFacturu.ExecuteNonQuery();

                con.Close();
                CloseWindow();
            }
            else {
                MessageBox.Show("Špatný vstup.");
            }
        }



        public void CloseWindow()
        {
            var window = ListOfWindows.GetFakturyWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
        }

        
    }
}

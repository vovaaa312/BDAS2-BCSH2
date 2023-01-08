using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VetClinic.Model;
using VetClinic.View;

namespace VetClinic
{
    public class VysledekSluzbyWindowService : IWindowService
    {
        public void CreateWindow()
        {
            if (ListOfWindows.GetVysledekSluzbyWindow() != null)
            {
                return;
            }
            VysledekSluzbyWindow window = new VysledekSluzbyWindow();
            window.Show();
            ListOfWindows.AddWindow(window);
        }

        public void AddVysledek() 
        {
            var window = ListOfWindows.GetVysledekSluzbyWindow();

            string prijmeni_majitele = window.PrijmeniMajiteleComboBox.SelectedValue.ToString();
            string jmeno_mazlicka = window.JmenoMazlickaComboBox.SelectedValue.ToString();
            bool hotova = (bool)window.hotovaCheckBox.IsChecked;
            bool planovana = (bool)window.planovanaCheckBox.IsChecked;
            int rbc = Int16.Parse(window.RBClabel.Text);
            int hgb = Int16.Parse(window.HGBlabel.Text);
            int hct = Int16.Parse(window.HCTlabel.Text);
            int glukoza = Int16.Parse(window.Glukozalabel.Text);
            int bilkoviny = Int16.Parse(window.Bilkovinylabel.Text);
            int mocovina = Int16.Parse(window.Mocovinalabel.Text);
            int bilirubin = Int16.Parse(window.Bilirubinlabel.Text);
            DateTime? zacatek = null;
            DateTime? konec = null;

            if (window.ZacatekDatePicker.SelectedDate.HasValue) zacatek = window.ZacatekDatePicker.SelectedDate.Value;
            if(window.UkonceniDatePicker.SelectedDate.HasValue) konec = window.UkonceniDatePicker.SelectedDate.Value;

            bool correct = isDataCorrect(prijmeni_majitele, jmeno_mazlicka, rbc, hgb, hct, glukoza, bilkoviny , mocovina, bilirubin, zacatek, konec);
            if (correct) 
            {
                try
                {
                    string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
            "user id=st64150;password=vova0107;" +
            "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";
                    OracleConnection con = new OracleConnection(constr);
                    con.Open();
                    //MessageBox.Show("Connected to Oracle Database From Tab1", con.ServerVersion);


                    //Call procedure VLOZ_USER
                    OracleCommand vlozVysledek = new OracleCommand("VLOZ_VYSLEDKY", con);
                    vlozVysledek.CommandType = System.Data.CommandType.StoredProcedure;

                    vlozVysledek.Parameters.Add("RBC");
                }
                catch (Exception ex) 
                {
                }
            }
        }

        private bool isDataCorrect(string prijmeni_majitele, string jmeno_mazlicka, int rbc, int hgb, int hct, int glukoza, int bilkoviny, int mocovina, int bilirubin, DateTime? zacatek, DateTime? konec)
        {
            string wrongFields = "";
            if (prijmeni_majitele.Length == 0) wrongFields += "Prijmeni majitele\n";
            if (jmeno_mazlicka.Length == 0) wrongFields += "Jmeno mazlicka\n";
            if (rbc <= 0) wrongFields += "RBC\n";
            if (hct <= 0) wrongFields += "HCT\n";
            if (hgb <= 0) wrongFields += "HGB\n";
            if (glukoza <= 0) wrongFields += "Glukoza\n";
            if (bilkoviny <= 0) wrongFields += "Bilkoviny\n";
            if (mocovina <= 0) wrongFields += "Mocovina\n";
            if (bilirubin <= 0) wrongFields += "Bilirubin\n";
            if (zacatek == null) wrongFields += "Datum zacatku\n";
            if (zacatek > konec) wrongFields += "Datum zacatku nemuze byt pozdeji nez datum ukonceni\n";

            if (wrongFields != "") MessageBox.Show("Dalsi data byli zadane chybne: \n"+wrongFields);
            return wrongFields == "";
        }

        public void CloseWindow()
        {
            var window = ListOfWindows.GetVysledekSluzbyWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
        }

        
    }
}

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    public class VeterinariFakturyPoledViewModel
    {
        public VeterinariFakturyPoledViewModel() {
            LoadVeterinariFaktury();
        }

        public ObservableCollection<VeterinariFakturyPohled> VeterinariFaktury{ get;set; }

        public void LoadVeterinariFaktury(){
            ObservableCollection<VeterinariFakturyPohled> veterinariFaktury = new ObservableCollection<VeterinariFakturyPohled>();

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            //MessageBox.Show("Connected to Oracle Database From Tab2", con.ServerVersion);



            OracleCommand getView = new OracleCommand();
            getView.Connection = con;
            getView.CommandText = "SELECT NAZEV_SLUZBY, JMENO_MAZLICEK, DATUM_VYSTAVENI, KONECNA_CENA, NAZEV_ODDELENI" +
            " FROM VETERINARI_FAKTURY_VIEW";
            OracleDataReader readerView = getView.ExecuteReader();

            if (readerView.HasRows) {
                while (readerView.Read()) {
                    veterinariFaktury.Add(
                        new VeterinariFakturyPohled {
                            Nazev_sluzby = readerView["NAZEV_SLUZBY"].ToString(),
                            Jmeno_mazlicek = readerView["JMENO_MAZLICEK"].ToString(),
                            Datum_vystaveni = readerView["DATUM_VYSTAVENI"].ToString(),
                            Konecna_cena = float.Parse(readerView["KONECNA_CENA"].ToString()),
                            Nazev_oddeleni = readerView["NAZEV_ODDELENI"].ToString()
                        }
                        );
                    VeterinariFaktury = veterinariFaktury;
                }
            }
            con.Close();
        }
    }
}

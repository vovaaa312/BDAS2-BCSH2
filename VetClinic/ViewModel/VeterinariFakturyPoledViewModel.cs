using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VetClinic.Model;
using VetClinic.View;

namespace VetClinic.ViewModel
{
    public class VeterinariFakturyPoledViewModel
    {
        FakturyWindowService fws = new FakturyWindowService();  
        public VeterinariFakturyPoledViewModel() {
            LoadVeterinariFaktury();
        }

        public ObservableCollection<VeterinariFakturyPohled> VeterinariFaktury{ get;set; }

        private VeterinariFakturyPohled selectedItem;


        public VeterinariFakturyPohled SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
            }
        }

        private ICommand _addFakturuCommand;
        public ICommand AddFakturuCommand
        {
            get
            {
                return _addFakturuCommand ?? (_addFakturuCommand = new CommandHandler(() => AddFakturu(), true));
            }
        }



        private void AddFakturu()
        {
            fws.CreateWindow();
        }

        private ICommand _removeFakturuCommand;
        public ICommand RemoveFakturuCommand
        {
            get
            {
                return _removeFakturuCommand ?? (_removeFakturuCommand = new CommandHandler(() => RemoveFakturu(), true));
            }
        }



        private void RemoveFakturu()
        {
            // TODO remove fakturu from list and from database
            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                       "user id=st64150;password=vova0107;" +
                       "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            OracleCommand odeberFacturu = new OracleCommand("ODEBER_FAKTURU", con);
            odeberFacturu.CommandType = System.Data.CommandType.StoredProcedure;

            string jmenoMazlicku = selectedItem.Jmeno_mazlicek.ToString();
            string jmenoMajitel = selectedItem.Jmeno_majitele.ToString();

            odeberFacturu.Parameters.Add("KON_CENA", OracleDbType.Int16).Value = selectedItem.Konecna_cena;
            odeberFacturu.Parameters.Add("JMENO_MAZLICKA", OracleDbType.Varchar2).Value = "Arigol";
            odeberFacturu.Parameters.Add("PRIJMENI_MAJITEL", OracleDbType.Varchar2).Value = "Antonov";

            OracleDataAdapter da = new OracleDataAdapter(odeberFacturu);
            odeberFacturu.ExecuteNonQuery();

            con.Close();

            VeterinariFaktury.Remove(selectedItem);
        }


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
            getView.CommandText = "SELECT NAZEV_SLUZBY, JMENO_MAJITEL, PRIJMENI_MAJITEL, JMENO_MAZLICEK, DATUM_VYSTAVENI, KONECNA_CENA, NAZEV_ODDELENI" +
            " FROM VETERINARI_FAKTURY_VIEW";
            OracleDataReader readerView = getView.ExecuteReader();

            if (readerView.HasRows) {
                while (readerView.Read()) {
                    veterinariFaktury.Add(
                        new VeterinariFakturyPohled {
                            Nazev_sluzby = readerView["NAZEV_SLUZBY"].ToString(),
                            Jmeno_mazlicek = readerView["JMENO_MAZLICEK"].ToString(),
                            Jmeno_majitele = readerView["PRIJMENI_MAJITEL"].ToString(),
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

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VetClinic.Model;
using VetClinic.View;

namespace VetClinic
{
    public class RegistrationWindowService : IWindowService
    {
        
        public void CreateWindow()
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            ListOfWindows.AddWindow(registrationWindow);
        }


        public void ConfirmRegistr() 
        {
            string jmeno = ListOfWindows.getRegWindow().jmenoTextBox.Text;
            string primeni = ListOfWindows.getRegWindow().primeniTextBox.Text;
            string tel = ListOfWindows.getRegWindow().telCisloTextBox.Text;
            string datumNarozeni = ListOfWindows.getRegWindow().datumNarozeniDatePicker.Text;
            string email = ListOfWindows.getRegWindow().emailTextBox.Text;


            string stat = ListOfWindows.getRegWindow().statTextBox.Text;
            string mesto = ListOfWindows.getRegWindow().mestoTextBox.Text;
            string ulice = ListOfWindows.getRegWindow().uliceTextBox.Text;
            string cislo = ListOfWindows.getRegWindow().cisloTextBox.Text;
            string psc = ListOfWindows.getRegWindow().pscTextBox.Text;
            string heslo = ListOfWindows.getRegWindow().hesloTextBox.Text;

            OracleDataAdapter da = new OracleDataAdapter();

            ObservableCollection<VeterinariMazlickyPohled> veterinariMazlicky = new ObservableCollection<VeterinariMazlickyPohled>();

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            //MessageBox.Show("Connected to Oracle Database From Tab1", con.ServerVersion);



            OracleCommand regCom = new OracleCommand();
            regCom.Connection = con;
            //regCom.CommandText = String.Format("CALL VLOZ_USER({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14});", heslo, jmeno, primeni, tel, email, 27000, OracleDate.MinValue, OracleDate.MinValue, "Kastrator", "Chirurgie", mesto, ulice, cislo, psc, stat);
            regCom.CommandText = "CALL VLOZ_USER(123, 'DEBIL','DEBILOV', 228133714,'DEBILDEBILOV@SOSI.CHLEN', 14888, TO_DATE('15-01-2022', 'DD-MM-YYYY'),\r\nTO_DATE('01-09-1941', 'DD-MM-YYYY'), 'DALBAEB', 'Terapie', 'PGT','Pushkina', 47, 12221, 'Mordor');";

            regCom.ExecuteScalar();

            con.Close();
        }

        public void CloseWindow()
        {
            ListOfWindows.getRegWindow().Close();
        }





    }
}

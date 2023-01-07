using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //Check if window is already oppened (Maximum 1 window oppened)
            if (ListOfWindows.getRegWindow() != null)
            {
                return;
            }
            //If login window was oppened it will close
            if (ListOfWindows.getLoginWindow() != null) {
                LoginWindowService lw = new LoginWindowService();
                lw.CloseWindow();
            }

            
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            ListOfWindows.AddWindow(registrationWindow);
        }


        public void ConfirmRegistr() 
        {
            RegistrationWindow regWindow = ListOfWindows.getRegWindow();

            DateTime? datumNarozeni = null;

            string jmeno = regWindow.jmenoTextBox.Text;
            string primeni = regWindow.primeniTextBox.Text;
            string tel = regWindow.telCisloTextBox.Text;
            
            if (regWindow.datumNarozeniDatePicker.SelectedDate.HasValue) {
                datumNarozeni = regWindow.datumNarozeniDatePicker.SelectedDate.Value;
            }
            string email = regWindow.emailTextBox.Text;
            string stat = regWindow.statTextBox.Text;
            string mesto = regWindow.mestoTextBox.Text;
            string ulice = regWindow.uliceTextBox.Text;
            string cislo = regWindow.cisloTextBox.Text;
            string psc = regWindow.pscTextBox.Text;
            string heslo = regWindow.hesloTextBox.Text;


            //Checking input
            bool regIsAllowed = 
                jmeno != "" && primeni != "" && tel != "" 
                && IsDigitsOnly(tel) && regWindow.datumNarozeniDatePicker.SelectedDate.HasValue
                && IsValidEmail(email) && stat != "" && mesto != "" 
                && ulice != "" && IsDigitsOnly(cislo) && cislo != "" && IsDigitsOnly(psc)
                && psc != "" && heslo.Length > 4;

            if (regIsAllowed)
            {
                try {
                    string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                            "user id=st64150;password=vova0107;" +
                            "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

                    OracleConnection con = new OracleConnection(constr);
                    con.Open();
                    //MessageBox.Show("Connected to Oracle Database From Tab1", con.ServerVersion);


                    //Call procedure VLOZ_USER
                    OracleCommand regCom = new OracleCommand("VLOZ_USER", con);
                    regCom.CommandType = System.Data.CommandType.StoredProcedure;

                    regCom.Parameters.Add("HESLO", OracleDbType.Varchar2).Value = heslo;
                    regCom.Parameters.Add("JMENO", OracleDbType.Varchar2).Value = jmeno;
                    regCom.Parameters.Add("PRIMENI", OracleDbType.Varchar2).Value = primeni;
                    regCom.Parameters.Add("TEL_CISLO", OracleDbType.Varchar2).Value = tel;
                    regCom.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = email;
                    regCom.Parameters.Add("PLAT", OracleDbType.Int64).Value = 27000;

                    //TODO FIX Datetime.now to datumNarozeni

                    regCom.Parameters.Add("NASTUP", OracleDbType.Date).Value = DateTime.Now;
                    regCom.Parameters.Add("NAROZENI", OracleDbType.Date).Value = DateTime.Now;
                    regCom.Parameters.Add("SPECIALIZACE", OracleDbType.Varchar2).Value = "Kastrator";
                    regCom.Parameters.Add("ODDELENI ", OracleDbType.Varchar2).Value = "Chirurgie";
                    regCom.Parameters.Add("MESTO", OracleDbType.Varchar2).Value = mesto;
                    regCom.Parameters.Add("ULICE", OracleDbType.Varchar2).Value = ulice;
                    regCom.Parameters.Add("CISLO_ULICE", OracleDbType.Int64).Value = cislo;
                    regCom.Parameters.Add("PSC_KOD", OracleDbType.Int64).Value = psc;
                    regCom.Parameters.Add("STAT", OracleDbType.Varchar2).Value = stat;

                    //Prihlaseni
                    User user = new User{ 
                        Email = email,
                        Password = heslo,
                        IsAdmin = false
                    };

                    ActualUser.SetUser(user);


                    OracleDataAdapter da = new OracleDataAdapter(regCom);
                    regCom.ExecuteNonQuery();

                    con.Close();

                    CloseWindow();
                }
                catch (OracleException e) {
                    MessageBox.Show("Connect to database and reload the app");
                }
            }
            else 
            {
                MessageBox.Show("Špatný vstup.");
            }
        }

        public void CloseWindow()
        {
            var window = ListOfWindows.getRegWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
           
}


        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}

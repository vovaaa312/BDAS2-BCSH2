﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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
    public class PridaniNovePetkartyWindowService : IWindowService
    {

        public void CreateWindow()
        {
            if (ListOfWindows.GetPridaniNovePetkartyWindow() != null) { 
                return;
            }
            PridaniNovePetkartyWindow pw = new PridaniNovePetkartyWindow();
            pw.Show();
            ListOfWindows.AddWindow(pw);
        }

        public void AddPetcard() {
            // TODO add new Paceint card

            var window = ListOfWindows.GetPridaniNovePetkartyWindow();

            string jmeno_mazlicka = window.jmenoMazlickaTextBox.Text;
            string druh_zvire = null;
            string jmeno_majitele = window.jmenoMajiteleTextBox.Text;
            string prijmeni_majitele = window.primeniMajiteleTextBox.Text;
            string tel_cislo = window.telCisloTextBox.Text;
            string email = window.emailTextBox.Text;
            string mesto = window.mestoTextBox.Text;
            string ulice = window.uliceTextBox.Text;
            string cislo_ulice = window.cisloUliceTextBox.Text;
            string psc = window.pscTextBox.Text;
            string stat = window.statTextBox.Text;
            string nazev_oddeleni = null;
            DateTime? nastup = null;
            DateTime? propusteni = null;

            if (window.datumNarozeniDatePicker.SelectedDate.HasValue) nastup = window.datumNarozeniDatePicker.SelectedDate.Value;
            if (window.datumPropusteniDatePicker.SelectedDate.HasValue) propusteni = window.datumPropusteniDatePicker.SelectedDate.Value;
            if (window.druhZvire.SelectedValue!= null) druh_zvire = window.druhZvire.SelectedValue.ToString();
            if(window.nazevOddeleniComboBox.SelectedValue!=null)nazev_oddeleni = window.nazevOddeleniComboBox.SelectedValue.ToString();


            bool isCorrect = correctData(jmeno_mazlicka, druh_zvire, jmeno_majitele, prijmeni_majitele, tel_cislo, email, mesto, ulice, cislo_ulice,
                psc, stat, nazev_oddeleni, nastup, propusteni);

            if (isCorrect) 
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
                    OracleCommand novaPetKartaCom = new OracleCommand("ZAVEDNI_NOVE_PET_KARTY", con);
                    novaPetKartaCom.CommandType = System.Data.CommandType.StoredProcedure;

                    novaPetKartaCom.Parameters.Add("JMENO", OracleDbType.Varchar2).Value= jmeno_majitele;
                    novaPetKartaCom.Parameters.Add("PRIJMENI", OracleDbType.Varchar2).Value = prijmeni_majitele;
                    novaPetKartaCom.Parameters.Add("TEL_CISLO", OracleDbType.Varchar2).Value = tel_cislo;
                    novaPetKartaCom.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = email;
                    novaPetKartaCom.Parameters.Add("MESTO", OracleDbType.Varchar2).Value = mesto;
                    novaPetKartaCom.Parameters.Add("ULICE", OracleDbType.Varchar2).Value = ulice;
                    novaPetKartaCom.Parameters.Add("CISLO_ULICE", OracleDbType.Int16).Value = Int16.Parse(cislo_ulice);
                    novaPetKartaCom.Parameters.Add("PSC_KOD", OracleDbType.Varchar2).Value = psc;
                    novaPetKartaCom.Parameters.Add("STAT", OracleDbType.Varchar2).Value = stat;
                    novaPetKartaCom.Parameters.Add("JMENO_MAZLICKA", OracleDbType.Varchar2).Value = jmeno_mazlicka;
                    novaPetKartaCom.Parameters.Add("DRUH_ZVIRE", OracleDbType.Varchar2).Value = druh_zvire;
                    novaPetKartaCom.Parameters.Add("NAZEV_ODDELENI", OracleDbType.Varchar2).Value = nazev_oddeleni;
                    novaPetKartaCom.Parameters.Add("NASTUP", OracleDbType.Date).Value = nastup;
                    novaPetKartaCom.Parameters.Add("VYSTUP", OracleDbType.Date).Value = propusteni;

                    OracleDataAdapter da = new OracleDataAdapter(novaPetKartaCom);
                    novaPetKartaCom.ExecuteNonQuery();

                    con.Close();

                    CloseWindow();
                }
                catch (Exception ex) 
                {
                MessageBox.Show(ex.Message);
                }

            }
            
        }

        private bool correctData(string jmeno_mazlicka, string druh_zvire, string jmeno_majitele, string prijmeni_majitele, string tel_cislo,
            string email, string mesto, string ulice, string cislo_ulice, string psc, string stat, string nazev_oddeleni, DateTime? nastup, DateTime? propusteni) {
            string wrongFields = "";
            
            if (druh_zvire == null) wrongFields += "Druh zvire\n";
            if (jmeno_mazlicka.Length <= 0) wrongFields += "Jmeno mazlicka\n";
            if (prijmeni_majitele.Length <=0) wrongFields += "Prijmeni majitele\n";
            if (jmeno_majitele.Length <= 0) wrongFields += "Jmeno majitele\n";
            if (!IsDigitsOnly(tel_cislo) || tel_cislo.Length < 9) wrongFields += "Tel-cislo\n";
            if(!IsValidEmail(email))wrongFields+= "Email\n";
            if (mesto.Length <= 0) wrongFields += "Mesto\n";
            if (ulice.Length <= 0) wrongFields += "Nazev ulice\n";
            if (!IsDigitsOnly(cislo_ulice)) wrongFields += "Cislo ulice\n";
            if (!IsDigitsOnly(psc) || psc.ToString().Length != 5) wrongFields += "PSC\n";
            if (stat.Length <= 0) wrongFields += "Stat\n";
            if (nazev_oddeleni == null) wrongFields += "Oddeleni\n";
            if (nastup == null) wrongFields += "Datum nastupu\n";
            if (nastup > propusteni) wrongFields += "Datum nastup nemuze byt pozdeji datumu propusteni\n";

            if (wrongFields != "") MessageBox.Show("Dalsi data byli naplneny nespravne:\n" + wrongFields, "Spatny vstup");

            return wrongFields == "";
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

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public void CloseWindow()
        {
            var window = ListOfWindows.GetPridaniNovePetkartyWindow();

            if (window == null)
            {
                return;
            }
            window.Close();
            ListOfWindows.RemoveWindow(window);
        }
    }
}

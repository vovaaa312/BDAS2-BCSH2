﻿using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    public class VeterinariMazlickyPohledViewModel
    {
        PridaniNovePetkartyWindowService pnws = new PridaniNovePetkartyWindowService();
        public VeterinariMazlickyPohledViewModel() {
            LoadVeterinariMazlicky();
        }

        public ObservableCollection<VeterinariMazlickyPohled> VeterinariMazlicky {
            get;
            set;
        }

        private VeterinariMazlickyPohled selectedItem;

        
        public VeterinariMazlickyPohled SelectedItem
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

        private ICommand _addPetCard1Command;
        public ICommand AddPetCard1Command
        {
            get
            {
                return _addPetCard1Command ?? (_addPetCard1Command = new CommandHandler(() => AddPetCard1(), true));
            }
        }

 

        private void AddPetCard1()
        {
            pnws.CreateWindow();
        }

        private ICommand _deleteAnimalCommand;
        public ICommand DeleteAnimalCommand
        {
            get
            {
                return _deleteAnimalCommand ?? (_deleteAnimalCommand = new CommandHandler(() => DeleteAnimal(), true));
            }
        }

        private void DeleteAnimal()
        {
            
            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                       "user id=st64150;password=vova0107;" +
                       "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            OracleCommand odeberPetKartuCom = new OracleCommand("ODEBIRANI_PET_KARTY", con);
            odeberPetKartuCom.CommandType = System.Data.CommandType.StoredProcedure;

            //MAZLICEK, EMAIL, PRIJMENI

            string mazlicek = selectedItem.Jmeno_mazlicek.ToString();
            string prijmeni = selectedItem.Primeni_majitele.ToString();
            string email = selectedItem.Email.ToString();



            odeberPetKartuCom.Parameters.Add("MAZLICEK", OracleDbType.Varchar2).Value = mazlicek;
            odeberPetKartuCom.Parameters.Add("EMAIL",    OracleDbType.Varchar2).Value = email;
            odeberPetKartuCom.Parameters.Add("PRIJMENI", OracleDbType.Varchar2).Value = prijmeni;

            OracleDataAdapter da = new OracleDataAdapter(odeberPetKartuCom);
            odeberPetKartuCom.ExecuteNonQuery();

            con.Close(); 
            VeterinariMazlicky.Remove(selectedItem);

            //TODO Delete from database
        }


        public void LoadVeterinariMazlicky() {
            ObservableCollection<VeterinariMazlickyPohled> veterinariMazlicky = new ObservableCollection<VeterinariMazlickyPohled>();

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            //MessageBox.Show("Connected to Oracle Database From Tab1", con.ServerVersion);



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
                     
                     Jmeno_majitele = readerView["JMENO_MAJITEL"].ToString(),
                     Primeni_majitele = readerView["PRIJMENI_MAJITEL"].ToString(),
                     Tel_cislo = readerView["TEL_CISLO"].ToString(),
                     
                     Email = readerView["EMAIL"].ToString(),
                     Nazev_mesta = readerView["NAZEV_MESTA"].ToString(),
                     Nazev_ulice = readerView["NAZEV_ULICE"].ToString(),
                     
                     Cislo_ulice = int.Parse(readerView["CISLO_ULICE"].ToString()),
                     
                     Psc_kod = readerView["PSC_KOD"].ToString(),
                     Stat = readerView["STAT"].ToString(),
                     
                     
                     Datum_nastupu = readerView["DATUM_NASTUPU"].ToString(),
                     Datum_propusteni = readerView["DATUM_PROPUSTENI"].ToString(), 
                     
                     //Datum_nastupu = readerView.GetDateTime(11).ToString(),
                     //Datum_propusteni = readerView.GetDateTime(12).ToString(),
                     
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

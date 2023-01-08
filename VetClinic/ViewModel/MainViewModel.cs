using System.Collections.ObjectModel;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using VetClinic.Model;
using Oracle.ManagedDataAccess.Client;

namespace VetClinic.ViewModel
{
    public class MainViewModel
    {
        readonly FakturyWindowService fws = new FakturyWindowService();
        readonly VysledekSluzbyWindowService vsws = new VysledekSluzbyWindowService();
        readonly PridaniNovePetkartyBezMajiteleWindowService pnpbmw = new PridaniNovePetkartyBezMajiteleWindowService();
        readonly PridaniNovePetkartyWindowService pnpv = new PridaniNovePetkartyWindowService();
        readonly RegistrationWindowService wr = new RegistrationWindowService();
        readonly LoginWindowService lw = new LoginWindowService();


        public MainViewModel() {
            LoadOddeleni();
            LoadPosice();
            LoadDruhZvire();
        }



        public void onClosing(object sender, CancelEventArgs e)
        {
            wr.CloseWindow();
            lw.CloseWindow();
        }


        private ICommand _addNewResultsCommand;
        public ICommand AddNewResultsCommand
        {
            get
            {
                return _addNewResultsCommand ?? (_addNewResultsCommand = new CommandHandler(() => AddNewResults(), canExecute()));
            }
        }

        private void AddNewResults()
        {
            vsws.AddVysledek();
        }





        private ICommand _addNewFakturaCommand;
        public ICommand AddNewFakturaCommand
        {
            get
            {
                return _addNewFakturaCommand ?? (_addNewFakturaCommand = new CommandHandler(() => AddNewFaktura(), canExecute()));
            }
        }

        private void AddNewFaktura()
        {            
            fws.AddFakturu();
        }

        private ICommand _backToMainWindowFromFakturyCommand;
        public ICommand BackToMainWindowFromFakturyCommand
        {
            get
            {
                return _backToMainWindowFromFakturyCommand ?? (_backToMainWindowFromFakturyCommand = new CommandHandler(() => BackToMainWindowFromFaktury(), canExecute()));
            }
        }

        private void BackToMainWindowFromFaktury()
        {
            fws.CloseWindow();
        }

        private ICommand _addNewPetCard1Command;
        public ICommand AddNewPetCard1Command
        {
            get
            {
                return _addNewPetCard1Command ?? (_addNewPetCard1Command = new CommandHandler(() => AddNewPetCard1(), canExecute()));
            }
        }

        private void AddNewPetCard1()
        {
            pnpv.AddPetcard();
            new VeterinariMazlickyPohledViewModel().LoadVeterinariMazlicky();
        }


        private ICommand _backToMainWindowFromAddResultsCommand;
        public ICommand BackToMainWindowFromAddResultsCommand
        {
            get
            {
                return _backToMainWindowFromAddResultsCommand ?? (_backToMainWindowFromAddResultsCommand = new CommandHandler(() => BackToMainWindowFromAddResults(), canExecute()));
            }
        }

        private void BackToMainWindowFromAddResults()
        {
            vsws.CloseWindow();
        }



       

        private ICommand _confirmLoginCommand;
        public ICommand ConfirmLoginCommand
        {
            get
            {
                return _confirmLoginCommand ?? (_confirmLoginCommand = new CommandHandler(() => ConfirmLogin(), canExecute()));
            }
        }

        private void ConfirmLogin()
        {
            lw.Login();
        }


        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new CommandHandler(() => LoginUser(), canExecute()));
            }
        }



        private void LoginUser()
        {
            lw.CreateWindow();
        }


        private ICommand _registrationCommand;
        public ICommand RegistrationCommand
        {
            get
            {
                return _registrationCommand ?? (_registrationCommand = new CommandHandler(() => OpenRegWindow(), canExecute()));
            }
        }

        private void OpenRegWindow()
        {
            wr.CreateWindow();
        }



        private ICommand _backToMainWindowCommand;
        public ICommand BackToMainWindowCommand
        {
            get
            {
                return _backToMainWindowCommand ?? (_backToMainWindowCommand = new CommandHandler(() => BackToMainWindow(), canExecute()));
            }
        }

        private void BackToMainWindow()
        {
            wr.CloseWindow();
            lw.CloseWindow();
        }

        private ICommand _backToMainWindowFromAddPetCard1Command;
        public ICommand BackToMainWindowFromAddPetCard1Command
        {
            get
            {
                return _backToMainWindowFromAddPetCard1Command ?? (_backToMainWindowFromAddPetCard1Command = new CommandHandler(() => BackToMainWindowFromAddPetCard1(), canExecute()));
            }
        }

        private void BackToMainWindowFromAddPetCard1()
        {
            pnpv.CloseWindow();
        }




        private ICommand _confirmRegistrationCommand;
        public ICommand ConfirmRegistrationCommand
        {
            get
            {
                return _confirmRegistrationCommand ?? (_confirmRegistrationCommand = new CommandHandler(() => ConfirmRefistration(), canExecute()));
            }
        }


        private void ConfirmRefistration()
        {
            wr.ConfirmRegistr();
        }
        private ObservableCollection<String> _oddeleni;

        public ObservableCollection<String> Oddeleni
        {
            get { return _oddeleni; }
            set { _oddeleni = value; }
        }
        private String _soddeleni;

        public String SOddeleni
        {
            get { return _soddeleni; }
            set { _soddeleni = value; }
        }

        private ObservableCollection<String> _druhZvire;

        public ObservableCollection<String> DruhZvire 
        {
            get { return _druhZvire; }
            set { _druhZvire = value; }
        }

        private String _sdruhZvire;

        public String SdruhZvire
        {
            get { return _sdruhZvire; }
            set { _sdruhZvire = value; }
        }

        private void LoadDruhZvire() 
        {
            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();

            OracleCommand getAllZvire = new OracleCommand();
            getAllZvire.Connection = con;
            getAllZvire.CommandText = "SELECT NAZEV FROM ZVIRE";
            OracleDataReader reader = getAllZvire.ExecuteReader();


            ObservableCollection<String> tmp = new ObservableCollection<String>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Oddeleni odd = new Oddeleni { nazev = reader["NAZEV"].ToString() };

                    tmp.Add(odd.nazev);
                    DruhZvire = tmp;
                }
            }
            
            con.Close();
        }

        private void LoadPosice()
        {
            //TODO select all pozice, or do it with hands
        }

        private void LoadOddeleni()
        {
            // select all pozice, or do it with hands
            //_soddeleni

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();

            OracleCommand getAllOddeleni= new OracleCommand();
            getAllOddeleni.Connection = con;
            getAllOddeleni.CommandText = "SELECT NAZEV_ODDELENI FROM ODDELENI";
            OracleDataReader reader = getAllOddeleni.ExecuteReader();


            ObservableCollection<String> tmp = new ObservableCollection<String>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Oddeleni odd = new Oddeleni { nazev = reader["NAZEV_ODDELENI"].ToString() };
                    
                    tmp.Add(odd.nazev);
                    Oddeleni = tmp;
                }
            }

            con.Close();
        }

        private bool canExecute()
        {
            return true;
        }


    }


}

using System.Collections.ObjectModel;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    public class MainViewModel
    {
        readonly PridaniNovePetkartyBezMajiteleWindowService pnpbmw = new PridaniNovePetkartyBezMajiteleWindowService();
        readonly PridaniNovePetkartyWindowService pnpv = new PridaniNovePetkartyWindowService();
        readonly RegistrationWindowService wr = new RegistrationWindowService();
        readonly LoginWindowService lw = new LoginWindowService();


        public MainViewModel() {
            LoadOddeleni();
            LoadPosice();
        }

        

        public void onClosing(object sender, CancelEventArgs e)
        {
            wr.CloseWindow();
            lw.CloseWindow();
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
        }


        private ICommand _addResultsCommand;
        public ICommand AddResultsCommand
        {
            get
            {
                return _addResultsCommand ?? (_addResultsCommand = new CommandHandler(() => AddResults(), canExecute()));
            }
        }

        private void AddResults()
        {

        }

        

        private ICommand _closeResultsCommand;
        public ICommand CloseResultsCommand
        {
            get
            {
                return _closeResultsCommand ?? (_closeResultsCommand = new CommandHandler(() => CloseResults(), canExecute()));
            }
        }

        private void CloseResults()
        {

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
        private ObservableCollection<Oddeleni> _oddeleni;

        public ObservableCollection<Oddeleni> oddeleni
        {
            get { return _oddeleni; }
            set { _oddeleni = value; }
        }
        private Oddeleni _soddeleni;

        public Oddeleni SOddeleni
        {
            get { return _soddeleni; }
            set { _soddeleni = value; }
        }

        private void LoadPosice()
        {
            //TODO select all pozice, or do it with hands
        }

        private void LoadOddeleni()
        {
            //TODO select all pozice, or do it with hands
        }

        private bool canExecute()
        {
            return true;
        }


    }


}

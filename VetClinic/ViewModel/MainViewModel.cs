using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    public class MainViewModel
    {
        
        readonly RegistrationWindowService wr = new RegistrationWindowService();
        readonly LoginWindowService lw = new LoginWindowService();
        public MainViewModel() {
        }

        public void onClosing(object sender, CancelEventArgs e)
        {
            wr.CloseWindow();
            lw.CloseWindow();
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



        private bool canExecute()
        {
            return true;
        }


    }


}

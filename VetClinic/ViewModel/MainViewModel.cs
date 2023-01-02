using System.Windows;
using System.Windows.Input;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    public class MainViewModel
    {
        readonly RegistrationWindowService wr = new RegistrationWindowService();
        public MainViewModel() {
        }

        /*
         * Registration
         * 
         * TODO:
         * Opens modal window RegistrationWindow, freez main window
         * 
         */
        private ICommand _registrationCommand;
        public ICommand RegistrationCommand
        {
            get
            {
                return _registrationCommand ?? (_registrationCommand = new CommandHandler(() => OpenRegWindow(), canExecute()));
            }
        }

        private bool canExecute() {
            return true;
        }

        private void OpenRegWindow()
        {
            wr.CreateWindow();
        }

        /*
        * Back to main window
        * 
        * TODO:
        * Close modal window without saivind progress, unfreez main window
        * 
        */

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

        }


        /*
        * Confirm registration
        * 
        * TODO:
        * Check all data in modal window, create SQL string dotaz
        * 
        */

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
            BackToMainWindow();
        }



        


    }


}

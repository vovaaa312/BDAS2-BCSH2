using System.Windows;
using System.Windows.Input;

namespace VetClinic.ViewModel
{
    internal class MainViewModel
    {
        readonly WindowRegistration wr = new WindowRegistration();
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

        public bool canExecute() {
            return true;
        }

        private void OpenRegWindow()
        {
            wr.CreateWindow();
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

        }



    }


}

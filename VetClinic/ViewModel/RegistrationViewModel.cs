using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VetClinic.Model;

namespace VetClinic.ViewModel
{
    internal class RegistrationViewModel
    {

        WindowRegistration wr = new WindowRegistration();
        public RegistrationViewModel() {
            //RegistrationCommand = new Command(OpenRegWindow());
        }



        WindowRegistration windowReg = new WindowRegistration();

        

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
            MessageBox.Show("Hello world");
            wr.CreateWindow();
        }
    }

    
}

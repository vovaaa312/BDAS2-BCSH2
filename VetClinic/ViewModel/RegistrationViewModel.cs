using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VetClinic.ViewModel
{
    internal class RegistrationViewModel
    {
        public RegistrationViewModel() {
            RegistrationCommand = new Command(OpenRegWindow());
        }



        WindowRegistration windowReg = new WindowRegistration();

        public ICommand RegistrationCommand { get; set; }

        private object OpenRegWindow()
        {
            throw new NotImplementedException();
        }
    }
}

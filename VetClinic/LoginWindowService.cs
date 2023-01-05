using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Model;
using VetClinic.View;

namespace VetClinic
{
    public class LoginWindowService : IWindowService
    {
        public void CreateWindow()
        {
            if (ListOfWindows.getLoginWindow() != null)
            {
                return;
            }
            if (ListOfWindows.getRegWindow() != null)
            {
                RegistrationWindowService rw = new RegistrationWindowService();
                rw.CloseWindow();
            }
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            ListOfWindows.AddWindow(loginWindow);
        }

        public bool Login() {
            // TOTO check login and password with database 
            LoginWindow loginWindow = ListOfWindows.getLoginWindow();

            string login = loginWindow.login.Text;
            string password = loginWindow.password.Text;



            // ---

            return false;
        }

        public void CloseWindow()
        {
            if (ListOfWindows.getLoginWindow() == null) { 
                return;
            }

            ListOfWindows.getLoginWindow().Close();
            ListOfWindows.RemoveWindow(ListOfWindows.getLoginWindow());
            
        }

        
    }
}

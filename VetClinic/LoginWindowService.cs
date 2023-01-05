using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
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

            ObservableCollection<User> users = new ObservableCollection<User>();

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            //MessageBox.Show("Connected to Oracle Database From Tab3", con.ServerVersion);

            OracleCommand command = new OracleCommand();
            command.Connection = con;
            command.CommandText = "SELECT LOGIN, PASSWORD ISADMIN" +
                " FROM USERS_ST";

            OracleDataReader reader = command.ExecuteReader();
            // ---
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Email = reader["LOGIN"].ToString(),
                        Password = reader["PASSWORD"].ToString(),
                        IsAdmin = reader["ISADMIN"].ToString().Equals('1')
                    });
                }
            }
            con.Close();

            foreach (User user in users) {
                if (user.Email == login && user.Password == password) { 
                    ActualUser.SetUser(user);
                    return true;
                }
            }

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

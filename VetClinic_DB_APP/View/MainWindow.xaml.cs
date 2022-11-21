using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VetClinic_DB_APP.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            try
            {
                string connectionString = "User ID=st64150;Password=vova0107;Data Source=  (DESCRIPTION =\r\n    (ADDRESS = (PROTOCOL = TCP)(HOST = fei-sql1.upceucebny.cz)(PORT = 1521))\r\n    (CONNECT_DATA =\r\n      (SERVER = DEDICATED)\r\n      (SERVICE_NAME = orcl)\r\n    )\r\n  )";
                string conn = "data source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = fei-sql1.upceucebny.cz)(PORT = 1521)))(CONNECT_DATA =(SID = IDAS)));USER ID=st64150;PASSWORD=vova0107";
                using (OracleConnection connection = new OracleConnection(conn))
                {
                    connection.Open();
                    Console.WriteLine("ServerVersion: " + connection.ServerVersion
                        + "\nDataSource: " + connection.DataSource);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

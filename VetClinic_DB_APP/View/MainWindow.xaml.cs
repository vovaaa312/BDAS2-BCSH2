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
                OracleConnection connection = new OracleConnection();
                string connectStr = "User Id=st64150;Password=vova0107;Data Source=  (DESCRIPTION =\r\n    (ADDRESS = (PROTOCOL = TCP)(HOST = myserver.mycompany.com)(PORT = 1521))\r\n    (CONNECT_DATA =\r\n      (SERVER = DEDICATED)\r\n      (SERVICE_NAME = orcl)\r\n    )\r\n  )";
                connection.ConnectionString = connectStr;
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

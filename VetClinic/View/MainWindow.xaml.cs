
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
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

namespace VetClinic.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql1.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=IDAS)));" +
                        "user id=st64150;password=vova0107;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

            OracleConnection con = new OracleConnection(constr);
            con.Open();
            //MessageBox.Show("Connected to Oracle Database", con.ServerVersion);



            OracleCommand getAllTables = new OracleCommand();
            getAllTables.Connection = con;
            getAllTables.CommandText = "SELECT table_name FROM all_tables\r\nwhere owner = 'ST64150'";
            OracleDataReader reader = getAllTables.ExecuteReader();



            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TablesListView.Items.Add(reader["TABLE_NAME"].ToString());
                }
            }
            


        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(TablesListView.SelectedItem.ToString());
        }

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

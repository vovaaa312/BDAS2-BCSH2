using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPraceB_Makarneko
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void EmailTextBoox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBoox_TextChanged(object sender, EventArgs e)
        {

        }

        private void GuestButton_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Registr r = new Registr();
            this.Hide();
            r.ShowDialog();
            
        }
    }
}

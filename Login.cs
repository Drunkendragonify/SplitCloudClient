using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitCloudClient
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginUsername.Text == "admin")
            {
                if (LoginPassword.Text == "admin")
                {
                    MessageBox.Show("Correct credintials!");
                }
            }
            else
            {
                MessageBox.Show("Incorrect credentials... Please check and enter again");
            }
        }


        private void LoginPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

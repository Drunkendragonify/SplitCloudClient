using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SplitCloudClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)  //meant to exit window but doesnt work
        {
            Form2 upload = new Form2();
            upload.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //gets filename/filepath of selected file
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Pick a file to Upload";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                string name = Path.GetFileName(file.FileName);
                //MessageBox.Show(path,"Location of selected file");
                //MessageBox.Show(name, "Name of selected file");
            }
        }

        private void Button2_Click(object sender, EventArgs e) //will be button to upload
        {
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            //MessageBox.Show(externalip, strHostName);

            string encryptionlevel = trackBar2.Value.ToString();
            string splitlevel = trackBar1.Value.ToString();

            if (string.Equals(encryptionlevel, "0"))  //no encryption
            {
                //
            }

            if (string.Equals(encryptionlevel, "1"))  //weak encryption
            {
                File.Encrypt(path); //dunno how to make this variable found, i cant get it outta the other methord
                MessageBox.Show("encrypted", "encryption status"); //if it doesnt break, this should work
                                                                   //will be replaced with progress bar
            }

            if (string.Equals(encryptionlevel, "2"))  //strong encryption
            {
                //
            }
        }
    }
}

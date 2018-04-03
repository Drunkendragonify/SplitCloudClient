using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitCloudClient
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Upload upload = new Upload();
            upload.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream _chosenfile = openFileDialog1.OpenFile();
            }
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                //MessageBox.Show(path, caption: "Location of selected file");
            }
            path = file.FileName;
        }

        private void button2_Click(string path, object sender, EventArgs e)
        {
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            //MessageBox.Show(strHostName);

            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            string encryptionlevel = trackBar2.Value.ToString();
            string splitlevel = trackBar1.Value.ToString();

<<<<<<< HEAD
            if (string.Equals(encryptionlevel, "0"))  //no encryption
            {
                //
            }

            if (string.Equals(encryptionlevel, "1"))  //weak encryption
            {
                //
                try
                {
                    string password = externalip; //key here
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);

                    string cryptFile = path;
                    FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    CryptoStream cs = new CryptoStream(fsCrypt,
                        RMCrypto.CreateEncryptor(key, key),
                        CryptoStreamMode.Write);

                    FileStream fsIn = new FileStream(path, FileMode.Open);

                    int data;
                    while ((data = fsIn.ReadByte()) != -1)
                        cs.WriteByte((byte)data);

                    fsIn.Close();
                    cs.Close();
                    fsCrypt.Close();
                }
                catch
                {
                    MessageBox.Show("Encryption failed!", "Error");
                }
            }

            if (string.Equals(encryptionlevel, "2"))  //strong encryption
            {
                //
            }
=======
        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar5_Click(object sender, EventArgs e)
        {

>>>>>>> 5a8f4878acfe3ffe36b6bc8265a277c449ff41c2
        }
    }
}

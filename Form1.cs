using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitCloudClient
{
    public partial class SplitCloud : Form
    {
        public SplitCloud()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void SplitCloudClient_Load(object sender, EventArgs e)
        {
            uploadAFile1 = new UploadAFile();
            uploadAFile1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 upload = new Form2();
            upload.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 download = new Form3();
            download.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void uploadAFile1_Load_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
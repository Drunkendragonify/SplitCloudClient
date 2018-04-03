using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            textBox1.Text = "Not Encrypted";
            textBox2.Text = "File 0 of 0 Uploaded";
            textBox3.Text = "Total 0%";

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Upload upload = new Upload();
            upload.Hide();
        }
    }
}

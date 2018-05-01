using System;
using System.IO;
using System.Windows.Forms;

namespace SplitCloudClient
{
    public partial class SplitCloud : Form
    {
        public SplitCloud()
        {
            InitializeComponent();
            upload1.Hide();
            download1.Hide();
            Name.Text = "";

            string systemFolder = Environment.SpecialFolder.MyDocuments + "\\" + "Split_Cloud";

            if (!Directory.Exists(systemFolder))
                Directory.CreateDirectory(systemFolder);
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
        
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void SplitCloudClient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            download1.Hide();
            upload1.Show();
            Name.Text = "Upload";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            upload1.Hide();
            download1.Show();
            Name.Text = "Download";
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

        private void upload1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
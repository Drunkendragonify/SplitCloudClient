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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Selectfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Curseor Files|*.cur";
            openFileDialog1.Title = "Select a Cursor File";

            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }
    }
}
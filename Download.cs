using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SplitCloudClient
{
    public partial class Download : UserControl
    {
        public Download()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //doesnt work
        {
            try {
                string outPath = Environment.SpecialFolder.MyDocuments + ""; // Substitute this with your Input Folder 
                string[] tmpFiles = Directory.GetFiles(outPath, "*.tmp");
                FileStream outputFile = null;
                string prevFileName = "";

                foreach (string tempFile in tmpFiles)
                {

                    string fileName = Path.GetFileNameWithoutExtension(tempFile);
                    string baseFileName = fileName.Substring(0, fileName.IndexOf(Convert.ToChar(".")));
                    string extension = Path.GetExtension(fileName);

                    if (!prevFileName.Equals(baseFileName))
                    {
                        if (outputFile != null)
                        {
                            outputFile.Flush();
                            outputFile.Close();
                        }
                        outputFile = new FileStream(outPath + baseFileName + extension, FileMode.OpenOrCreate, FileAccess.Write);
                    }

                    int bytesRead = 0;
                    byte[] buffer = new byte[1024];
                    FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);

                    while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                        outputFile.Write(buffer, 0, bytesRead);

                    inputTempFile.Close();
                    File.Delete(tempFile);
                    prevFileName = baseFileName;
                }
            }
            catch
            {
                MessageBox.Show("Rebuilding Failed");
            }
        }    
    }
}

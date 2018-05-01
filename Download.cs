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
            try
            {
                bool MergeFile(string inputfoldername1)
                {
                    bool Output = false;

                    try
                    {
                        string[] tmpfiles = Directory.GetFiles(inputfoldername1, "*.tmp");

                        FileStream outPutFile = null;
                        string PrevFileName = "";

                        foreach (string tempFile in tmpfiles)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(tempFile);
                            string baseFileName = fileName.Substring(0, fileName.IndexOf(Convert.ToChar(".")));
                            string extension = Path.GetExtension(fileName);

                            if (!PrevFileName.Equals(baseFileName))
                            {
                                if (outPutFile != null)
                                {
                                    outPutFile.Flush();
                                    outPutFile.Close();
                                }
                                outPutFile = new FileStream(SaveFileFolder + "\\" + baseFileName + extension, FileMode.OpenOrCreate, FileAccess.Write);

                            }

                            int bytesRead = 0;
                            byte[] buffer = new byte[1024];
                            FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);

                            while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                                outPutFile.Write(buffer, 0, bytesRead);

                            inputTempFile.Close();
                            File.Delete(tempFile);
                            PrevFileName = baseFileName;

                        }

                        outPutFile.Close();
                        lblSendingResult.Text = "Files have been merged and saved at location C:\\";
                    }
                    catch
                    {

                    }

                    return Output;

                }
            
            }
            catch
            {
                MessageBox.Show("Rebuilding Failed");
            }
        }    
    }
}

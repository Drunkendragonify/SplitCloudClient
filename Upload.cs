using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SplitCloudClient
{
    public partial class Upload : UserControl
    {
        public Upload()
        {
            InitializeComponent();
            progressBar1.Maximum = 1;
        }

        public string path;
        public string SaveFileFolder = @"c:\";
        public string name;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Pick a file to Upload";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                string name = Path.GetFileName(file.FileName);
                //MessageBox.Show(path,"Location of selected file");
                //MessageBox.Show(name, "Name of selected file");
                int FileLength = path.Length / 1024;
                textBox1.Text = path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            //MessageBox.Show(externalip, strHostName);

            string encryptionlevel = trackBar2.Value.ToString();
            string splitlevel = trackBar1.Value.ToString();

            if (string.Equals(encryptionlevel, "0"))  //no encryption
            {
                //leave cos its not being encrypted (my OCD needed it here)
                progressBar1.Step = 1;
                progressBar1.PerformStep();
            }

            if (string.Equals(encryptionlevel, "1"))  //weak encryption
            {
                // add ehhh encryption
                progressBar1.Step = 1;
                progressBar1.PerformStep();
            }

            if (string.Equals(encryptionlevel, "2"))  //strong encryption
            {
                //need to have confusing/strong encryption added
                progressBar1.Step = 1;
                progressBar1.PerformStep();
            }

            if (string.Equals(splitlevel, "0")) //one file
            {
                //leave cos its one file (my OCD needed it here)
                progressBar2.Maximum = 1;
                progressBar2.Step = 1;
                progressBar2.PerformStep();
            }

            if (string.Equals(splitlevel, "1")) //light split //https://www.c-sharpcorner.com/uploadfile/a72401/split-and-merge-files-in-C-Sharp/
            {
                List<string> Packets = new List<string>();

                try
                {
                    {
                        SplitFile(path, Convert.ToInt32(5));
                        listBox1.Items.Add(Packets[0].ToString());
                        listBox1.Items.Add(Packets[1].ToString());
                        listBox1.Items.Add(Packets[2].ToString());
                        listBox1.Items.Add(Packets[3].ToString());
                        listBox1.Items.Add(Packets[4].ToString());
                    }
                }

                catch
                {
                    MessageBox.Show("Light Splitting Failed");
                }

                bool SplitFile(string SourceFile, int nNoofFiles)
                {

                    try
                    {
                        FileStream path = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                        int SizeofEachFile = (int)Math.Ceiling((double)path.Length / nNoofFiles);

                        for (int i = 0; i < nNoofFiles; i++)
                        {
                            string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                            string Extension = Path.GetExtension(SourceFile);

                            FileStream outputFile = new FileStream(path: Path.GetDirectoryName(SourceFile) + "\\" + baseFileName + "." + i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", mode: FileMode.Create, access: FileAccess.Write);

                            string mergeFolder = Path.GetDirectoryName(SourceFile);

                            int bytesRead = 0;
                            byte[] buffer = new byte[SizeofEachFile];

                            if ((bytesRead = path.Read(buffer, 0, SizeofEachFile)) > 0)
                            {
                                outputFile.Write(buffer, 0, bytesRead);
                                //outp.Write(buffer, 0, BytesRead);

                                string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                                Packets.Add(packet);
                            }

                            outputFile.Close();

                        }
                        path.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Failed");
                    }
                }
            }

            if (string.Equals(splitlevel, "2")) //heavy split //https://www.c-sharpcorner.com/uploadfile/a72401/split-and-merge-files-in-C-Sharp/
            {
                try
                {

                }

                catch
                {
                    MessageBox.Show("Heavy Splitting Failed");
                }
            }
        }
    }
}

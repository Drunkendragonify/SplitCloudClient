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
            this.Close();
        }

        public string path;

        private void button1_Click(object sender, EventArgs e) //gets filename/filepath of selected file
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Pick a file to Upload";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                string name = Path.GetFileName(file.FileName);
                //MessageBox.Show(path,"Location of selected file");
                //MessageBox.Show(name, "Name of selected file");
                textBox1.Text = path;
            }
        }

        private void Button2_Click(object sender, EventArgs e) //button to upload
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
            }

            if (string.Equals(encryptionlevel, "1"))  //weak encryption
            {
                try
                {
                    File.Encrypt(path); //dunno how to make this variable found, i cant get it outta the other methord
                    MessageBox.Show("Encrypted File"); //will be replaced with progress bar
                }
                catch
                {
                    MessageBox.Show("Encryption failed", "Error");
                }
            }

            if (string.Equals(encryptionlevel, "2"))  //strong encryption
            {
                //need to have confusing/strong encryption added
            }

            // taken from https://www.c-sharpcorner.com/UploadFile/a72401/split-and-merge-files-in-C-Sharp/
            //(need for merging files again)

            if (string.Equals(splitlevel, "0")) //one file
            {
                //leave cos its one file (my OCD needed it here)
            }

            if (string.Equals(splitlevel, "1")) //light split
            {
                string SourceFile = path; //will change to encrypted file when encryption finished
                int nNoofFiles = 10; //only difference between light split and heavy split
                try
                {
                    FileStream fs = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                    int SizeofEachFile = (int)Math.Ceiling((double)fs.Length / nNoofFiles);

                    for (int i = 0; i < nNoofFiles; i++)
                    {
                        string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                        string Extension = Path.GetExtension(SourceFile);

                        FileStream outputFile = new FileStream(Path.GetDirectoryName(SourceFile) + "\\" + baseFileName + "." +
                            i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);

                        string mergeFolder = Path.GetDirectoryName(SourceFile);

                        int bytesRead = 0;
                        byte[] buffer = new byte[SizeofEachFile];

                        if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                        {
                            outputFile.Write(buffer, 0, bytesRead);
                            //outp.Write(buffer, 0, BytesRead);

                            string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                        }

                        outputFile.Close();
                    }
                }


                catch (Exception)
                {
                    MessageBox.Show("Light splitting failed", "Error");
                }
            }

            if (string.Equals(splitlevel, "2")) //heavy split
            {
                string SourceFile = path; //will change to encrypted file when encryption finished
                int nNoofFiles = 30; //only difference between light split and heavy split
                try
                {
                    FileStream fs = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                    int SizeofEachFile = (int)Math.Ceiling((double)fs.Length / nNoofFiles);

                    for (int i = 0; i < nNoofFiles; i++)
                    {
                        string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                        string Extension = Path.GetExtension(SourceFile);

                        FileStream outputFile = new FileStream(Path.GetDirectoryName(SourceFile) + "\\" + baseFileName + "." +
                            i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);

                        string mergeFolder = Path.GetDirectoryName(SourceFile);

                        int bytesRead = 0;
                        byte[] buffer = new byte[SizeofEachFile];

                        if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                        {
                            outputFile.Write(buffer, 0, bytesRead);
                            //outp.Write(buffer, 0, BytesRead);

                            string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                        }

                        outputFile.Close();
                    }
                }


                catch (Exception)
                {
                    MessageBox.Show("Heavy splitting failed", "Error");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //i accidently clicked on it now everytime i delete it, everything breaks
        }
    }
}
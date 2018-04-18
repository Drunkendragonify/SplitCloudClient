using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

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

            if (string.Equals(splitlevel, "1")) //light split //http://codemaverick.blogspot.co.uk/2007/01/split-and-merge-file-in-c.html
            {
                try
                {
                    progressBar2.Maximum = 5;
                    progressBar2.Step = 1;
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    int numberOfFiles = 5;
                    int sizeOfEachFile = (int)Math.Ceiling((double)fs.Length / numberOfFiles);

                    for (int i = 1; i <= numberOfFiles; i++)
                    {
                        string baseFileName = Path.GetFileNameWithoutExtension(path);
                        string extension = Path.GetExtension(path);
                        FileStream outputFile = new FileStream(Path.GetDirectoryName(path) + "\\" + baseFileName + "." + i.ToString().PadLeft(5, Convert.ToChar("0")) + extension + ".tmp", FileMode.Create, FileAccess.Write);
                        int bytesRead = 0;
                        byte[] buffer = new byte[sizeOfEachFile];

                        if ((bytesRead = fs.Read(buffer, 0, sizeOfEachFile)) > 0)
                        {
                            outputFile.Write(buffer, 0, bytesRead);
                            progressBar2.PerformStep();
                        }
                        outputFile.Close();
                    }
                    fs.Close();
                    MessageBox.Show("Light Splitting Complete");
                }

                catch
                {
                    MessageBox.Show("Light Splitting Failed");
                }
            }

            if (string.Equals(splitlevel, "2")) //heavy split //http://codemaverick.blogspot.co.uk/2007/01/split-and-merge-file-in-c.html
            {
                try
                {
                    progressBar2.Maximum = 10;
                    progressBar2.Step = 1;
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    int numberOfFiles = 10;
                    int sizeOfEachFile = (int)Math.Ceiling((double)fs.Length / numberOfFiles);

                    for (int i = 1; i <= numberOfFiles; i++)
                    {
                        string baseFileName = Path.GetFileNameWithoutExtension(path);
                        string extension = Path.GetExtension(path);
                        FileStream outputFile = new FileStream(Path.GetDirectoryName(path) + "\\" + baseFileName + "." + i.ToString().PadLeft(5, Convert.ToChar("0")) + extension + ".tmp", FileMode.Create, FileAccess.Write);
                        int bytesRead = 0;
                        byte[] buffer = new byte[sizeOfEachFile];

                        if ((bytesRead = fs.Read(buffer, 0, sizeOfEachFile)) > 0)
                        {
                            outputFile.Write(buffer, 0, bytesRead);
                            progressBar2.PerformStep();
                        }
                        outputFile.Close();
                    }
                    fs.Close();
                    MessageBox.Show("Heavy Splitting Complete");
                }

                catch
                {
                    MessageBox.Show("Heavy Splitting Failed");
                }
            }
        }
    }
}

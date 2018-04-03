using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitCloudClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplitCloud());
        }

        public static IPAddress GetIpAddress(string hostName)
        {
            //Currently Broken
            var ping = new Ping();
            var replay = ping.Send(hostName);
            //Pings googles servers and gets hostname
            return replay != null && replay.Status == IPStatus.Success ? replay.Address : null;
        }

        public static void SetStartup()
        {
            /*
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string pathToSecCopy = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\" + AppDomain.CurrentDomain.FriendlyName;
            string pathToApp = Application.ExecutablePath;
            if (rkApp.GetValue(System.AppDomain.CurrentDomain.FriendlyName) == null)
            {
                rkApp.SetValue(System.AppDomain.CurrentDomain.FriendlyName, pathToSecCopy);
            }
            */
        }
    }
}
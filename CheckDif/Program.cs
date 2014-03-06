using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Configuration;

namespace CheckDif
{
    //public enum DbObjectType { Procedure};
    //public class DbObject
    //{

    //}

    public class Settings
    {
        private static string connStr = null;
        private static string winMergePath = null;

        public static string ConnStr {
            get { return connStr; }
        }

        static Settings() 
        {
            connStr = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            winMergePath = ConfigurationManager.AppSettings["WinMergePath"];
        }

        public static string WinMergePath
        {
            get { return winMergePath; }
        }
    }


    static class Program
    {
        private static void ShowForm() 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmMain());
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ShowForm();
        }
    }
}

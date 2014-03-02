using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CheckDif
{
    //public enum DbObjectType { Procedure};
    //public class DbObject
    //{

    //}

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

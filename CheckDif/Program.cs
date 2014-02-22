using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CheckDif
{
    public class DbObjects
    {
        private String cnnStr = @"Server=(localdb)\v11.0;Database=master;Integrated Security=true;";

        //public string Key {get; set; }
        //private string curKey;
        private string lastKey;
               
        //private List<String> objectsCache = null;
        //current objects
        private List<String> objects = null;

        public List<String> Objects()
        {
            return objects;
        }

        private void SearchObjects(string key)
        {
            //Thread.Sleep(10000);
            /*
            */
            bool lSearchInDb = false;
            //if (objects == null) 
            lSearchInDb = true;
            if (lSearchInDb)
            {
                SearchObjectsInDb(key);
            }
            lastKey = key;
        }

        private void SearchObjectsInCache(string key)
        {
        }

        private void SearchObjectsInDb(string key)
        {
            if (objects == null) objects = new List<string>();
            else objects.Clear();

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();
                String cmdStr = "select name from dbo.GetObjectsByName(@name)";
                using (SqlCommand cmd = new SqlCommand(cmdStr, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", key);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            //objectsCache.Add(rd["name"].ToString());
                            objects.Add(rd["name"].ToString());
                        }
                    }
                }
            }
        }

        public async Task<int> SearchAsync(string key)
        {            
            await Task.Run(() => {
                Search(key);
            });
            return 0;
        }

        public void Search(string key)
        {
            if ((key == null) || (key.Length < 3)) return;
            SearchObjects(key);
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

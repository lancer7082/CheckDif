using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace CheckDif
{
	//Поиск объектов в БД (процедуры и функции) по части названия
    public class DbObjects
    {
        private const String cnnStr =
            //@"Data Source=(localdb)\v11.0;Initial Catalog=master;Integrated Security=true;";
            @"Server=(localdb)\v11.0;Database=master;Integrated Security=true;";

        //public string Key {get; set; }
        //private string curKey;
        private string lastKey;

        //private List<string> objectsCache = null;
        //current objects
        private List<string> objects = null;

        public List<string> Objects()
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

        public static string GetObjectText(string objectName)
        {
            string text = null;
            if (String.IsNullOrEmpty(objectName)) return null;

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();
                String cmdStr = "GetObjectText";
                using (SqlCommand cmd = new SqlCommand(cmdStr, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@objectName", objectName);
                    SqlParameter p = cmd.Parameters.Add("@text", SqlDbType.NVarChar, -1);
                    p.Direction = ParameterDirection.Output;
                    
                    cmd.ExecuteNonQuery();
                    text = cmd.Parameters["@text"].Value.ToString();
                }
            }

            return text;
        }

        public async Task<int> SearchAsync(string key)
        {
            await Task.Run(() =>
            {
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

    public class FileWithObjects
    {
        public string FileName { get; set; }
        public List<string> objects;
        public FileWithObjects(string fileName, List<string> objects)
        {
            FileName = fileName;
            this.objects = objects;
        }
    }

    //Поиск файлов в папке, в которых содержится определение объекта
    public class FileObjects
    {
        private List<FileWithObjects> files = null;
        public List<FileWithObjects> Files { 
            get { return files; }
        }

        private bool IsMatch(string objectNameFromFile, string objectName)
        {
            return objectNameFromFile.Equals(objectName);
        }

        private void ClearList()
        {
            if (files != null) files.Clear();
        }

        private bool SearchFiles(string path)
        {
            if (String.IsNullOrEmpty(path)) return false;

            if (files == null) files = new List<FileWithObjects>();
            else ClearList();

            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] filesInFolder = d.GetFiles("*.sql");
            List<string> l;
            foreach (FileInfo f in filesInFolder)
            {
                //System.Console.WriteLine(f.Name);
                l = SearchObjectsInFile(path + @"\" + f.Name);
			    files.Add(new FileWithObjects(f.Name, l));
            }

            return true;
        }

        private List<string> SearchObjectsInFile(string fileName)
        {
            StreamReader reader = File.OpenText(fileName);
            string line;
            char[] delimiters = { ' ', ',', /*'.',*/ '\t', '\n' };
            List<string> objects = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                if (
                    (line.ToUpper().IndexOf("ALTER") >= 0) ||
                    (line.ToUpper().IndexOf("CREATE") >= 0)
                   )
                {
                    string[] items = line.Split(delimiters);
                    string item;
                    for (int i = 0; i < items.Length; i++)
                    {
                        item = items[i];
                        //System.Console.WriteLine(item);
                        if (
                            (item.ToUpper() == "ALTER") ||
                            (item.ToUpper() == "CREATE")
                           )
                        {
                            if ((i++ < item.Length) && 
                                (
                                    (items[i].ToUpper() == "PROCEDURE") ||
                                    (items[i].ToUpper() == "FUNCTION")
                                ))
                            {
                                if (i++ < item.Length)
                                    objects.Add(items[i]);
                            }
                        }
                    }
                }
            }
            return objects;
        }

        private List<FileWithObjects> FilterFiles(string objectName)
        {
            if (files == null) return null;
            List<FileWithObjects> list = new List<FileWithObjects>();
            foreach (FileWithObjects f in files)
            {
                if (f.objects != null)
                {
                    foreach (String s in f.objects)
                    {
                        if (IsMatch(s, objectName)) list.Add(f);
                    }
                }
            }
            return list;
        }

        public async Task<bool> ListAsync(string path)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = List(path);
            });
            return result;
        }

        //Получение списка файлов с объектами в каталоге
        public bool List(string path)
        {
            if (String.IsNullOrEmpty(path)) return false;
            return SearchFiles(path);
        }

        public async Task<List<FileWithObjects>> FilterAsync(string objectName)
        {
            List<FileWithObjects> result = null;
            await Task.Run(() =>
            {
                result = Filter(objectName);
            });
            return result;
        }

        //поиск файлов, содержащих объект objectName
        public List<FileWithObjects> Filter(string objectName)
        {
            if (String.IsNullOrEmpty(objectName)) return null;
            return FilterFiles(objectName);
        }
    }
}
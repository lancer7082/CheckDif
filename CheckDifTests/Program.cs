using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDif
{
    class TestDb
    {
        public async void TestGetObjects()
        {
            DbObjects dbo = new DbObjects();
            Console.WriteLine("Starting search...");

            Task searchTask = dbo.SearchAsync("1");
            await searchTask;

            Console.WriteLine("After search");
        }
    }

    class Program
    {
        private static List<String> GetObjectsFromFile(string fileName)
        {
            StreamReader reader = File.OpenText(fileName);
            string line;
            char[] delimiters = { ' ', ',', /*'.',*/ '\t', '\n' };
            List<String> objects = new List<String>();
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
                    //break;
                }
                //tokens.AddRange(items);
            }
            return objects;
        }

        public static void TestFiles()
        {
            string path = @"f:\Temp\Files";
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*.sql");
            List<String> objects;
            foreach (FileInfo f in files)
            {
                System.Console.WriteLine(f.Name);
                objects = GetObjectsFromFile(path + @"\" + f.Name);
                foreach (String s in objects) System.Console.WriteLine(s);
                //break;
            }
        }

        static void Main(string[] args)
        {
            TestFiles();
            /*
            TestDb t = new TestDb();
            t.TestGetObjects();
            */
            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}

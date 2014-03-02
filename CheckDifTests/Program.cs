using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CheckDif
{
    class Program
    {

        public static async void TestGetObjects()
        {
            DbObjects dbo = new DbObjects();
            Console.WriteLine("Starting search...");

            Task searchTask = dbo.SearchAsync("1");
            await searchTask;

            Console.WriteLine("After search");
        }

        public static async void TestFiles()
        {
            FileObjects dbo = new FileObjects();
            Console.WriteLine("Starting search...");

            /*
            //Поиск файлов, в которых содержится определение объекта
            Task searchTask = dbo.SearchAsync(@"f:\Temp\Files", 
                //"[sys].[sp_add_agent_parameter]"
                "[sys].[sp_add_agent_profile]"
                );
            await searchTask;

            Console.WriteLine("After search");

            List<string> files = dbo.Files;
            if (files != null)
            {
                foreach (String s in files)
                    Console.WriteLine(s);
            }
            */

        }

        static void Main(string[] args)
        {
            //string filePathWinMerge = @"c:\""Program Files (x86)""\WinMerge\WinMergeU.exe";
            string fileName = "sp3.sql";
            string path = @"f:\Temp\Files";
            string objectName = "[sys].[sp_add_data_file_recover_suspect_db]";
            //TestFiles();
            string text = DbObjects.GetObjectText(objectName);
            string filePathDb = path + @"\" + objectName + ".sql.db";
            using (StreamWriter writer = new StreamWriter(filePathDb))
            {
                writer.Write(text);
            }
            String command = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) +
                @"\WinMerge\WinMergeU.exe";
            Console.WriteLine(command);
            Process.Start(command, path + @"\" + fileName + " " + filePathDb);
                
            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}

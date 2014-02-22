using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            TestDb t = new TestDb();
            t.TestGetObjects();
            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}

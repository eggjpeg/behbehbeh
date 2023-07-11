using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behbehbeh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter database name: ");
            string fileName = "ExampleDatabase.txt";
            string dbName = Console.ReadLine();
            Database db = new Database(dbName);
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.ReadLine();
        }
    }
}

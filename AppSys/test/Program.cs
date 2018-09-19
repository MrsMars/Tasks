using System;
using System.Linq;
using System.Xml.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            XDocument xdoc = XDocument.Load("db.xml");

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            do
            {
                Console.Clear();
                Console.WriteLine("*** *** *** Welcome to StudentBase! *** *** ***\n");
                Console.WriteLine("Please press '1' to continue or '0' to close it\n");

                choice = int.Parse(Console.ReadLine());
            }
            while (choice != 0 & choice != 1);

            Console.Clear();

            if (choice == 0) { goto l_end; }


l_end:
            return;
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string University { get; set; }
    }
    class Faculty
    {
        public string Name { get; set; }
        public string University { get; set; }
        public string Code { get; set; }
    }
    class University
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}


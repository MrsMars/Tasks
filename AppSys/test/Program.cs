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

l_main:
            Console.Clear();
            Console.WriteLine("*** Main ***");
            Console.WriteLine("Prease, chose what you want to do:\n");
            Console.WriteLine("Press '1' to see all the students and info about them");
            Console.WriteLine("Press '2' to see all the universities");
            Console.WriteLine("Press '3' to find all students on chosen faculty and chosen university");

            Console.Write("\nPlease, choose someone: ");

            do { choice = int.Parse(Console.ReadLine()); }
            while (choice != 0 & choice != 1 & choice != 2 & choice != 3 & choice != 4 & choice != 5 & choice != 6 & choice != 7 & choice != 8 & choice != 9);

            Console.Clear();

            switch (choice)
            {
                case 0: goto l_end;
                case 1:
                    ShowAllStudents(xdoc);
                    break;
                case 2:
                    ShowAllUniversities(xdoc);
                    break;
                case 3:
                    FindSometh(xdoc);
                    break;
            }

            Console.WriteLine("\nPress '1' to back to the main or '0' to end:");

            do { choice = int.Parse(Console.ReadLine()); }
            while (choice != 0 & choice != 1);

            if (choice == 1) { goto l_main; }
            else { goto l_end; }
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


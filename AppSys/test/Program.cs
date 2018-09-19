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

        public static void ShowAllStudents(XDocument xdoc)
        {
            var items = from xStudent in xdoc.Element("db").Elements("students").Elements("student")
                        join xFaculty in xdoc.Element("db").Elements("faculties").Elements("faculty") on xStudent.Element("facultyCode").Value equals xFaculty.Element("code").Value
                        join xUniversity in xdoc.Element("db").Elements("universities").Elements("university") on xStudent.Element("universityCode").Value equals xUniversity.Element("code").Value
                        select new Student
                        {
                            FirstName = xStudent.Element("firstName").Value,
                            LastName = xStudent.Element("lastName").Value,
                            Faculty = xFaculty.Element("name").Value,
                            University = xUniversity.Element("name").Value
                        };
            foreach (var item in items) { Console.WriteLine("{0} {1}\nUniversity: {2}\nFaculty: {3}\n", item.FirstName, item.LastName, item.University, item.Faculty); }
        }
        public static void ShowAllUniversities(XDocument xdoc)
        {
            var items = from xUniversity in xdoc.Element("db").Elements("universities").Elements("university")
                        select xUniversity.Element("name").Value;
            foreach (var item in items) { Console.WriteLine(item); }
        }
        public static void FindSometh(XDocument xdoc)
        {
            int choice;

l_uiversity:
            int i;

            Console.Clear();
            Console.WriteLine("*** Main >> Universities ***");
            Console.WriteLine("There are all the universities:\n");

            var itemsU = from xUniversity in xdoc.Element("db").Elements("universities").Elements("university")
                         select new University
                         {
                             Name = xUniversity.Element("name").Value,
                             Code = xUniversity.Element("code").Value
                         };
            i = 0;
            foreach (var item in itemsU) { Console.WriteLine("{0} - {1}", ++i, item.Name); }

            Console.Write("\nPlease, choose someone: ");

            do { choice = int.Parse(Console.ReadLine()); }
            while (choice > itemsU.Count());

            var university = itemsU.ToArray()[choice - 1];

l_faculty:
            Console.Clear();
            Console.WriteLine("*** Main >> University >> Faculties ***");
            Console.WriteLine("*** {0} ***", university.Name);
            Console.WriteLine("There are all the faculties:\n");

            var itemsF = from xFaculties in xdoc.Element("db").Elements("faculties").Elements("faculty")
                         where xFaculties.Element("uiversity").Value == university.Name
                         select new Faculty
                         {
                             Name = xFaculties.Element("name").Value,
                             University = university.Name,
                             Code = xFaculties.Element("code").Value
                         };
            i = 0;
            foreach (var item in itemsF) { Console.WriteLine("{0} - {1}", ++i, item.Name); }

            Console.Write("\nPlease, choose someone");
            Console.Write("\nPress '0' to change your choice: ");

            do { choice = int.Parse(Console.ReadLine()); }
            while (choice > itemsF.Count());
            if (choice <= 0) { goto l_uiversity; }

            var faculty = itemsF.ToArray()[choice - 1];

            // students
            Console.Clear();
            Console.WriteLine("*** Main >> University >> Faculty >> Students ***");
            Console.WriteLine("*** {0} ***", university.Name);
            Console.WriteLine(" *  {0}  * ", faculty.Name);
            Console.WriteLine("There are all the students:\n");

            var itemsS = from xStudent in xdoc.Element("db").Elements("students").Elements("student")
                         where xStudent.Element("facultyCode").Value == faculty.Code && xStudent.Element("universityCode").Value == university.Code
                         select new Student
                         {
                             FirstName = xStudent.Element("firstName").Value,
                             LastName = xStudent.Element("lastName").Value,
                             Faculty = faculty.Name,
                             University = university.Name
                         };
            i = 0;
            foreach (var item in itemsS) { Console.WriteLine("{0} - {1} {2}", ++i, item.FirstName, item.LastName); }

            Console.Write("\nPress '0' to change your choice or '1' to continue: ");

            do { choice = int.Parse(Console.ReadLine()); }
            while (choice != 0 & choice != 1);

            if (choice == 0) { goto l_faculty; }
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


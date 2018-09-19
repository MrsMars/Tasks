using System;
using System.Linq;
using System.Xml.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            
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


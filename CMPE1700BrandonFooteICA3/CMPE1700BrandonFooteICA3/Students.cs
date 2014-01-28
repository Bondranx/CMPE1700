using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteICA3
{
    class Students
    {
        public static double GPA(List<double> Grades)
        {
            double GPA = 0;
            double GradesTotal = 0;
            for (int count = 0; count < Grades.Count; count++)
            {
                GradesTotal += Grades[count];
            }
            GPA = GradesTotal / Grades.Count;

            return GPA;
        }


        public struct Student
        {
            public string _studentName;
            public string _IDNumber;
            public List<double> _Grades;

            public Student(string StudentName, string IDNumber, List<double> Grades)
            {
                _studentName = StudentName;
                _IDNumber = IDNumber;
                _Grades = Grades;
            }

            public override string ToString()
            {
                return string.Format("{0} ({1}) GPA:{2:F1}", _studentName, _IDNumber, GPA(_Grades));
            }
        }
        static void Main(string[] args)
        {
            StreamReader inputFile;
            
            string input = "";
            Console.WriteLine("Enter the name of the file you would like to read from: ");
            input = Console.ReadLine();
            try
            {
                inputFile = new StreamReader(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}

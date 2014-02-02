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
            int newGrade = 0;
            int counter = 0;
            string inputHolder = "";
            string[] holder = null;
            List<int> gradeHolder = new List<int>();
            
            string input = "";
            Console.Write("Enter the name of the file you would like to read from: ");
            input = Console.ReadLine();
            try
            {
                inputFile = new StreamReader(input);
                while (inputFile.ReadLine() != null)
                inputHolder = inputFile.ReadLine();
                {
                    holder = input.Split(' ', ',');
                    for (int count = 2; count < holder.Length - 1; count++)
                    {
                        int.TryParse(holder[count], out newGrade);
                        gradeHolder.Add(newGrade);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}

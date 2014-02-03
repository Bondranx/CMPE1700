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
            double newGrade = 0;
            double GPAnew = 0;
            string studentName = "";
            string IDNum = "";
            string inputHolder = "";
            string[] holder = null;
            List<double> gradeHolder;
            List<Student> studentList = new List<Student>();
            
            string input = "";
            Console.Write("Enter the name of the file you would like to read from: ");
            input = Console.ReadLine();
            try
            {
                inputFile = new StreamReader(input);
                while (inputHolder != null)
                {
                    gradeHolder = new List<double>();
                    inputHolder = inputFile.ReadLine();
                    if (inputHolder != null)
                    {
                    holder = inputHolder.Split(new char[] {',', ' '},  StringSplitOptions.RemoveEmptyEntries);
                    studentName = holder[1] + " " + holder[0];
                    IDNum = holder[2];
                    for (int count = 3; count <= holder.Length - 1; count++)
                    {
                        newGrade = double.Parse(holder[count]);
                        gradeHolder.Add(newGrade);
                    }
                    Console.WriteLine(inputHolder);
                    Student newStudent = new Student(studentName, IDNum, gradeHolder);
                    studentList.Add(newStudent);
                    
                    }   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (Student student in studentList)
            {
                Console.WriteLine(student);
            }
            for (int count = 0; count <= studentList.Count-1; count++)
            {
                GPAnew += GPA(studentList[count]._Grades);
            }
            Console.WriteLine("Class GPA: " + (GPAnew / studentList.Count));

            Console.ReadKey();

        }
    }
}

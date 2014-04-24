using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteICA10
{
    class Dictionary
    {
        public struct Marks
        {
            public double _Value;
            public double _OutOf;
            public double _Weight;
            public int _ID;

            public Marks(double Value, double OutOf, double Weight, int ID)
            {
                _Value = Value;
                _OutOf = OutOf;
                _Weight = Weight;
                _ID = ID;
            }
        }

        public struct StudentData
        {
            public String _LastName;
            public String _Firstname;
            public int _StudentID;
            public List<Marks> _Markslist;

            public StudentData(String LastName, String FirstName, int StudentID, List<Marks> MarksList)
            {
                _LastName = LastName;
                _Firstname = FirstName;
                _StudentID = StudentID;
                _Markslist = MarksList;
            }
            public override string ToString()
            {
                return string.Format("{0}, {1} = {2} \n Marks \n", _LastName, _Firstname, _StudentID.ToString());
            }
        }

        static void Main(string[] args)
        {
            ConsoleKey Confirm;
            ConsoleKey input;
            String LineRead;
            String[] temp = null;
            int ID = 0;
            int count = 0;
            StreamReader newStreamReader;
            StreamReader marksReader;
            Dictionary<int, StudentData> myDictionary = new Dictionary<int, StudentData>();
            List<Marks> newList = new List<Marks>();
            List<Marks> secondList = new List<Marks>();

            try
            {
                newStreamReader = new StreamReader("Students.txt");
                try
                {
                    while ((LineRead = newStreamReader.ReadLine()) != null)
                    {
                        temp = LineRead.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        int.TryParse(temp[2], out ID);
                        StudentData newStudent = new StudentData(temp[0], temp[1], ID, newList);
                        myDictionary.Add(ID, newStudent);
                        count++;
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    newStreamReader.Close();
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                marksReader = new StreamReader("Marks.txt");
                try
                {
                    while ((LineRead = marksReader.ReadLine()) != null)
                    {
                        double Value, OutOf, Weight;
                        temp = LineRead.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        double.TryParse(temp[1], out Value);
                        double.TryParse(temp[2], out OutOf);
                        double.TryParse(temp[3], out Weight);
                        int.TryParse(temp[0], out ID);
                        Marks newMark = new Marks(Value, OutOf, Weight, ID);
                        secondList.Add(newMark);
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    marksReader.Close();
                }
            }
            catch (Exception e)
            {
            }

            foreach (Marks i in secondList)
            {
                myDictionary[i._ID]._Markslist.Add(i);
            }

            do
            {
                Console.WriteLine("{0} Student Records found", myDictionary.Count);
                Console.WriteLine("");
                Console.WriteLine("A - Add new student");
                Console.WriteLine("M - Add new mark");
                Console.WriteLine("L - List all records (Alphabetical Order)");
                Console.WriteLine("S - Search by student ID");
                Console.WriteLine("N - Search by last name");
                Console.WriteLine("Q - Quit");
                Console.WriteLine("X - Quit and save to disk");
                Console.WriteLine("");
                Console.Write("Your choice? ");

                input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.A:
                        AddStudent(myDictionary);
                        break;
                    case ConsoleKey.M:
                        Addmark(myDictionary);
                        break;
                    case ConsoleKey.L:
                        ListAll(myDictionary);
                        break;
                    case ConsoleKey.S:
                        SearchByID(myDictionary);
                        break;
                    case ConsoleKey.N:
                        SearchByLastName(myDictionary);
                        break;
                    case ConsoleKey.Q:
                        input = QuitConfirm(input);
                        break;
                }
            }
            while (input != ConsoleKey.Q);
        }

        public static void ListAll(Dictionary<int, StudentData> newDict)
        {
            string temp = "";
            int count = 0;
            List<String> templist = new List<string>();
            Dictionary<String, StudentData> tempDict = new Dictionary<string, StudentData>();
            foreach (KeyValuePair<int, StudentData> e in newDict)
            {
                if (tempDict.ContainsKey(e.Value._LastName))
                {
                    temp = e.Value._LastName + count.ToString();
                    tempDict.Add(temp, e.Value);
                    templist.Add(temp);
                }
                else
                {
                    tempDict.Add(e.Value._LastName, e.Value);
                    templist.Add(e.Value._LastName);
                }

            }

            templist.Sort();
            Console.WriteLine("\n");
            foreach (String i in templist)
            {
                Console.WriteLine(tempDict[i]);
                foreach (Marks l in tempDict[i]._Markslist)
                {
                    Console.WriteLine("Mark: {0}, OutOf: {1}, Weight {2}", l._Value, l._OutOf, l._Weight);
                }
            }
            Console.WriteLine("");
        }

        public static void SearchByID(Dictionary<int, StudentData> newDict)
        {
            int SearchID;
            bool success;
            Console.WriteLine("\n");
            do
            {
                Console.Write("What ID would you like to search for?: ");
                success = int.TryParse(Console.ReadLine(), out SearchID);
            }
            while (success == false || SearchID > 999999 || SearchID < 100000);
            if (newDict.ContainsKey(SearchID))
            {
                Console.WriteLine(newDict[SearchID]);
            }
            else
            {
                Console.WriteLine("There is no student with that ID");
            }
        }

        public static void SearchByLastName(Dictionary<int, StudentData> newDict)
        {
            string nameInput = "";
            int count = 0;
            Console.WriteLine("\n");
            Console.WriteLine("What last name would like records for?: ");
            nameInput = Console.ReadLine().ToUpper();

            foreach (KeyValuePair<int, StudentData> e in newDict)
            {
                if (e.Value._LastName.ToUpper() == nameInput)
                {
                    Console.WriteLine(e.Value);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("no records with that name found.\n");
            }
            else
            {
                Console.WriteLine("");
            }
        }

        public static Dictionary<int, StudentData> AddStudent(Dictionary<int, StudentData> newDict)
        {
            int ID;
            string FirstName;
            string Surname;
            StudentData newData = new StudentData();
            List<Marks> newList = new List<Marks>();

            Console.Write("Please enter the Student ID: ");
            int.TryParse(Console.ReadLine(), out ID);
            Console.Write("\nPlease enter the student's last name: ");
            Surname = Console.ReadLine();
            Console.Write("\nPlease enter the student's first name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("");

            newData._StudentID = ID;
            newData._LastName = Surname;
            newData._Firstname = FirstName;
            newData._Markslist = newList;

            newDict.Add(ID, newData);

            return newDict;
        }

        public static Dictionary<int, StudentData> Addmark(Dictionary<int, StudentData> newDict)
        {
            Marks newMark;
            int ID;
            double Value;
            double OutOf;
            double Weight;

            Console.Write("Student ID: ");
            int.TryParse(Console.ReadLine(), out ID);
            Console.Write("\nMark value: ");
            double.TryParse(Console.ReadLine(), out Value);
            Console.Write("\nOut of: ");
            double.TryParse(Console.ReadLine(), out OutOf);
            Console.Write("\nMark weight: ");
            double.TryParse(Console.ReadLine(), out Weight);

            newMark._ID = ID;
            newMark._OutOf = OutOf;
            newMark._Value = Value;
            newMark._Weight = Weight;

            newDict[ID]._Markslist.Add(newMark);

            return newDict;
        }

        public static ConsoleKey QuitConfirm(ConsoleKey Confirm)
        {
            string userInput = null;
            do
            {
                Console.WriteLine("Are you sure you want to quit without saving? (Yes/No)");
                userInput = Console.ReadLine().ToLower();
            }
            while (userInput != "y" && userInput != "yes" && userInput != "n" && userInput != "no");

            if(userInput == "y" || userInput == "yes")
            {
            }
            else if (userInput == "n" || userInput == "no")
            {
                Confirm = ConsoleKey.N;
            }
            return Confirm;
        }
    }
}
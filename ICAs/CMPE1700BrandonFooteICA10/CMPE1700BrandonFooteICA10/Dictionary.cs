using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteICA10
{
    class Dictionary
    {
        public struct StudentData
        {
            public String _LastName;
            public String _Firstname;
            public int _StudentID;

            public StudentData(String LastName, String FirstName, int StudentID)
            {
                _LastName = LastName;
                _Firstname = FirstName;
                _StudentID = StudentID;
            }
            public override string ToString()
            {
                return string.Format("{0}, {1} = {2}", _LastName, _Firstname, _StudentID.ToString()) ;
            }
        }

        static void Main(string[] args)
        {
            ConsoleKey input;
            String LineRead;
            String[] temp = null;
            int ID;
            int count = 0;
            StreamReader newStreamReader;
            Dictionary<int,StudentData> myDictionary = new Dictionary<int,StudentData>();
            try
            {
                newStreamReader = new StreamReader("StudentData.txt");
                try
                {
                    while ((LineRead = newStreamReader.ReadLine()) != null)
                    {
                        temp = LineRead.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        int.TryParse(temp[2], out ID);
                        StudentData newStudent = new StudentData(temp[0], temp[1], ID);
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

            do
            {
                Console.WriteLine("{0} Student Records found", count);
                Console.WriteLine("");
                Console.WriteLine("L - List all records (Alphabetical Order)");
                Console.WriteLine("S - Search by student ID");
                Console.WriteLine("N - Search by last name");
                Console.WriteLine("Q - Quit");
                Console.WriteLine("");
                Console.Write("Your choice? ");

                input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.L:
                        ListAll(myDictionary);
                        break;
                    case ConsoleKey.S:
                        SearchByID(myDictionary);
                        break;
                    case ConsoleKey.N:
                        SearchByLastName(myDictionary);
                        break;
                }
            }
            while(input != ConsoleKey.Q);
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
            while (success == false || SearchID > 999999 || SearchID <100000);
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


    }
}

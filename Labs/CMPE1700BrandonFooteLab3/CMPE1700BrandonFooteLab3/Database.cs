//*********************************************************************************** 
//Program: Database.cs 
//Description: Enters and stores student marks data
//Date: Apr. 24/2013 
//Author: Brandon Foote 
//Course: CMPE1700 
//Class: 2D 
//***********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteICA10
{
    class Dictionary
    {
        //Structure to hold marks data
        public struct Marks
        {
            public double _Value;   //Mark Value
            public double _OutOf;   //Value mark is out of
            public double _Weight;  //Weight of the mark
            public int _ID;

            //Constructor to create each mark
            public Marks(double Value, double OutOf, double Weight, int ID)
            {
                _Value = Value;
                _OutOf = OutOf;
                _Weight = Weight;
                _ID = ID;
            }
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3}", _ID, _Value, _OutOf, _Weight);
            }
        }

        //Structure to hold Student information
        public struct StudentData
        {
            public String _LastName;        //Holds student's last name
            public String _Firstname;       //Holds student's first name
            public int _StudentID;          //Holds student's ID number
            public List<Marks> _Markslist;  //Holds a list of student's marks

            //Constructor to build the structure
            public StudentData(String LastName, String FirstName, int StudentID, List<Marks> MarksList)
            {
                _LastName = LastName;
                _Firstname = FirstName;
                _StudentID = StudentID;
                _Markslist = MarksList;
            }
            //To string override
            public override string ToString()
            {
                return string.Format("{0}, {1} = {2} \n Marks:", _LastName, _Firstname, _StudentID.ToString());
            }
        }

        static void Main(string[] args)
        {
            ConsoleKey input;               //Stores user menu inputs
            String LineRead;                //Holds StreamReader line reads
            String[] temp = null;           //temp array to hold StreamReader buffer
            int ID = 0;                     //holds student ID numbers read in from file
            StreamReader newStreamReader;   //Reads stream from students file
            StreamReader marksReader;       //Reads stream from marks file
            Dictionary<int, StudentData> myDictionary = new Dictionary<int, StudentData>();//Student Dictionary

            try
            {
                //Opens stream to Students.txt
                newStreamReader = new StreamReader("Students.txt");
                try
                {
                    //Reads each line in while the next line in not empty
                    while ((LineRead = newStreamReader.ReadLine()) != null)
                    {
                        //Stores and splits the string that is read in
                        temp = LineRead.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        //Parses the ID number from the string array
                        int.TryParse(temp[2], out ID);
                        //Creates and stores a student value
                        StudentData newStudent = new StudentData(temp[0], temp[1], ID, new List<Marks>());
                        //Stores the student value in the dictionary
                        myDictionary.Add(ID, newStudent);
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    //Closes the stream to Students.txt
                    newStreamReader.Close();
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                //Opens a stream to Marks.txt
                marksReader = new StreamReader("Marks.txt");
                try
                {
                    //Reads each line in from Marks.txt while the next line s not null
                    while ((LineRead = marksReader.ReadLine()) != null)
                    {
                        double Value, OutOf, Weight;            //Variables to store data read in from the file
                        temp = LineRead.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //splits the values in the array and stores them
                        double.TryParse(temp[1], out Value);    //Parses mark value to a double
                        double.TryParse(temp[2], out OutOf);    //Parses value mark is out of to a double
                        double.TryParse(temp[3], out Weight);   //parses mark weight to a double
                        int.TryParse(temp[0], out ID);          //Parses Student ID to an int
                        //Creates a stores the values as a new mark structure
                        Marks newMark = new Marks(Value, OutOf, Weight, ID);    
                        //Stores marks in a list in dictionray
                        if (myDictionary.ContainsKey(newMark._ID))
                            myDictionary[newMark._ID]._Markslist.Add(newMark);
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    //closes stream to Marks.txt
                    marksReader.Close();
                }
            }
            catch (Exception e)
            {
            }

            //foreach (Marks i in secondList)
            //{
                //if(myDictionary.ContainsKey(i._ID))
                   // myDictionary[i._ID]._Markslist.Add(i);
            //}

            do
            {
                //Displays the menu for the database
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

                //Reads user menu commands
                input = Console.ReadKey(true).Key;

                //Switch to control the menu
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
                    case ConsoleKey.X:
                        SaveAndQuit(myDictionary);
                        break;
                }
            }
            //Loops menu while user input is not Q
            while (input != ConsoleKey.Q && input != ConsoleKey.X);
        }


        //******************************************************************************************** 
        //Method: public static void ListAll(Dictionary<int, StudentData> newDict)
        //Purpose: Lists all student marks
        //Parameters:  Dictionary<int, StudentData> newDict
        //Returns: nothing 
        //*********************************************************************************************
        public static void ListAll(Dictionary<int, StudentData> newDict)
        {
            string temp = "";   //Varaible to store a string
            int count = 0;      //Variable to count
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

        //******************************************************************************************** 
        //Method: public static void SearchByID(Dictionary<int, StudentData> newDict)
        //Purpose: Searches through students by ID
        //Parameters:  Dictionary<int, StudentData> newDict
        //Returns: nothing 
        //*********************************************************************************************
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

        //******************************************************************************************** 
        //Method: public static void SearchByLastName(Dictionary<int, StudentData> newDict)
        //Purpose: Searches through students by Last Name
        //Parameters:  Dictionary<int, StudentData> newDict
        //Returns: nothing 
        //*********************************************************************************************
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

        //******************************************************************************************** 
        //public static Dictionary<int, StudentData> AddStudent(Dictionary<int, StudentData> newDict)
        //Purpose: Add students to the database
        //Parameters:  Dictionary<int, StudentData> newDict
        //Returns: newDict
        //*********************************************************************************************
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

        //******************************************************************************************** 
        //public static Dictionary<int, StudentData> Addmark(Dictionary<int, StudentData> newDict)
        //Purpose: Add student marks to the database
        //Parameters:  Dictionary<int, StudentData> newDict
        //Returns: newDict
        //*********************************************************************************************
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

        //******************************************************************************************** 
        //public static ConsoleKey QuitConfirm(ConsoleKey Confirm)
        //Purpose: Confirms user quit command
        //Parameters:  Consolekey Confirm
        //Returns: Confirm
        //*********************************************************************************************
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

        public static void SaveAndQuit(Dictionary<int,StudentData> newDict)
        {
            StreamWriter newWriter = new StreamWriter("Students.txt");
            try
            {
                foreach (StudentData i in newDict.Values)
                {
                    newWriter.WriteLine("{0} {1} {2}", i._LastName, i._Firstname, i._StudentID);
                }

            }
            catch (Exception e)
            {
            }
            finally
            {
                newWriter.Close();
            }

            newWriter = new StreamWriter("Marks.txt");
            try
            {
                foreach (StudentData i in newDict.Values)
                {
                    foreach (Marks l in i._Markslist)
                    {
                        newWriter.WriteLine(l.ToString());
                    }
                }
                
            }
            catch (Exception e)
            {
            }
            finally
            {
                newWriter.Close();
            }
            
        }
    }
}
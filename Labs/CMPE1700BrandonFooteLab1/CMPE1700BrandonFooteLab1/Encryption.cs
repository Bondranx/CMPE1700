
//*********************************************************************************** 
//Program: Encryption (Lab 1) 
//Description: Loads data from a file and encrypts it using a user defined encryption
//key
//Lab: 1 
//Date: Febuary 23, 2014 
//Author: Brandon Foote
//Course: CMPE1700
//Class: 2D
//Instructor: JD Silver 
//***********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteLab1
{
    class Encryption
    {
        //******************************************************************************************** 
        //Method: static private List<char> Reader(List<char> newList, StreamReader input)
        //Purpose: Reads data from a file as defined by the user
        //Parameters:List<char> newList - The list to store the file data in 
        // streamReader input - The streamreader definition for the selected file 
        //Returns: List<char> newList - The list used to store the file data
        //*********************************************************************************************
        static private List<char> Reader(List<char> newList, StreamReader input)
        {
            //integer variable to temporarily store character information
            int holder;
            //Try statement attempts to read information from a file
            try
            {
                //Loops while there is still data to be read from the file
                while ((holder = input.Read()) != -1)
                    //Adds data to a list of characters for encryption/decryption
                    newList.Add((char)holder);
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
            }
            finally
            {
                input.Close();
            }

            return newList;
        }
        //******************************************************************************************** 
        //Method: static private void Writer(List<char> output, StreamWriter outputStream)
        //Purpose: Writes data to a file as defined by the user
        //Parameters:List<char> output - The list to write the file data to 
        // streamWriter outputStream - The streamwriter definition for the selected file 
        //Returns: Nothing
        //*********************************************************************************************
        static private void Writer(List<char> output, StreamWriter outputStream)
        {
            try
            {
                //Writes encrypted/decrypted data back to the original file
                foreach (char value in output)
                {
                    outputStream.Write(value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                outputStream.Close();
            }
        }

        static void Main(string[] args)
        {
            List<char> characterList = new List<char>();    //List to stroe file data
            int count = 0;                                  //counting variable for encrypting 
            int count2 = 0;                                 //Counting variable for encrypting
            string UserInput = "";                          //Stores user defined filename
            string encryptionKey = "";                      //Stores user defined encryption key
            bool success = false;                           //Stores value for failed/successful user input
            
            //Requests a filename from the user and repeats while the filename is invalid
            do
            {
                Console.WriteLine("What is the name of the file you would like to Encrypt/Decrypt: ");
                UserInput = Console.ReadLine();
                //Tries to initialize the streamreader for the user defined filename.
                try
                {
                    StreamReader NewStreamReader = new StreamReader(UserInput);
                    //stores the file data in the characterList variable
                    characterList = Reader(characterList, NewStreamReader);
                    success = true;
                }
                //Returns an error if the file cannot be read
                catch (Exception)
                {
                    Console.WriteLine("That is not a valid filename, you must enter a valid filename\n");
                    success = false; 
                }
            }
            while (success == false);

            //Requests an ecryption key from the user and repeats while encyption key is invalid
            do
            {
                Console.WriteLine("Please enter the encryption key you will be using: ");
                encryptionKey = Console.ReadLine();
                if (encryptionKey == "")
                    Console.WriteLine("You must enter an encryption key!\n");
            }
            while (encryptionKey == "");

            //Repeat while there are chracters in the list to be encrypted/decrypted
            while (count < characterList.Count)
            {
                characterList[count] = (char)(characterList[count] ^ encryptionKey[count2]);
                count2++;
                //Resets to first character in encryption key when last letter is reached
                if (count2 >= (encryptionKey.Length-1))
                    count2 = 0;
                count++;
            }

            //Writes the encrypted/decrypted file contents to the console.
            foreach (char value in characterList)
            {
                Console.Write(value);
            }
            //Initializes the StreamWriter
            StreamWriter NewStreamWriter = new StreamWriter(UserInput);
            //Writes encrypted/decrypted data back to the file
            Writer(characterList, NewStreamWriter);
            Console.ReadKey();
        }
    }
}

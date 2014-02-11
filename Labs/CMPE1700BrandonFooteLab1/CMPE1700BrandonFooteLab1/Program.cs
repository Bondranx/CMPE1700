using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteLab1
{
    class Program
    {
        static List<char> Reader(List<char> newList, StreamReader input)
        {
            int holder;
            try
            {
                while ((holder = input.Read()) != -1)
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

        static void Writer(List<char> output, StreamWriter outputStream)
        {
            try
            {
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
            List<char> characterList = new List<char>();

            int count = 0;
            int count2 = 0;
            string UserInput = "";
            string encryptionKey = "";
            bool success = false;
            
            do
            {
                Console.WriteLine("What is the name of the file you would like to Encrypt/Decrypt: ");
                UserInput = Console.ReadLine();
                try
                {
                    StreamReader NewStreamReader = new StreamReader(UserInput);
                    characterList = Reader(characterList, NewStreamReader);
                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("That is not a valid filename\n");
                    success = false;
                    
                }
            }
            while (success == false);
            do
            {
                Console.WriteLine("Please enter the encryption key you will be using: ");
                encryptionKey = Console.ReadLine();
                if (encryptionKey == "")
                    Console.WriteLine("You must enter an encryption key!\n");
            }
            while (encryptionKey == "");
            while (count < characterList.Count)
            {
                characterList[count] = (char)(characterList[count] ^ encryptionKey[count2]);
                count2++;
                if (count >= (encryptionKey.Length-1))
                    count2 = 0;
                count++;
            }
            foreach (char value in characterList)
            {
                Console.Write(value);
            }
            StreamWriter NewStreamWriter = new StreamWriter(UserInput);
            Writer(characterList, NewStreamWriter);


            Console.ReadKey();
        }
    }
}

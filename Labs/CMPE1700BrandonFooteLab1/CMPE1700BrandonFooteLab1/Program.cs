using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteLab1
{
    class Program
    {
        static List<char> Reader(List<char> newList, StreamReader input, string FileName)
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

        static void Main(string[] args)
        {
            List<char> characterList = new List<char>();

            int count = 0;
            char holder;
            string UserInput = "";
            string encryptionKey = "";

            Console.WriteLine("What is the name of the file you would like to Encrypt/Decrypt: ");
            UserInput = Console.ReadLine();

            Console.WriteLine("Please enter the encryption key you will be using: ");
            encryptionKey = Console.ReadLine();
            StreamReader NewStreamReader = new StreamReader(UserInput);

            characterList = Reader(characterList, NewStreamReader, UserInput);


            foreach (char value in characterList)
            {
                characterList[value] = (char)(characterList[value] ^ encryptionKey[count]);
                Console.WriteLine(value);
                if (count >= encryptionKey.Length-1)
                    count = 0;
            }
            Console.ReadKey();
        }
    }
}

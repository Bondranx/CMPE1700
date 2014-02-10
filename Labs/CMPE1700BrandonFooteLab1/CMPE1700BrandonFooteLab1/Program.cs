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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return newList;
        }

        static void Main(string[] args)
        {
            List<char> characterList = new List<char>();
            
            string UserInput = "";
            Console.WriteLine("What is the name of the file you would like to encrypt: ");
            UserInput = Console.ReadLine();
            StreamReader NewStreamReader = new StreamReader(UserInput);
            characterList = Reader(characterList, NewStreamReader, UserInput);
            foreach (char value in characterList)
            {
                Console.Write(value);
            }
            Console.ReadKey();
        }
    }
}

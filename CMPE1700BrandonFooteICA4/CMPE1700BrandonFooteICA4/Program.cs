using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = false;
            byte userInput;
            Console.WriteLine("Please enter an 8-bit number: ");
            do
            {
                    success = byte.TryParse(Console.ReadLine(), out userInput);
                    if (success == false)
                        Console.WriteLine("\nThe value entered is not an 8-bit number please enter a different value\n");
            }
            while (success == false);
            Console.WriteLine(userInput);
            Console.ReadKey();
        }
    }
}

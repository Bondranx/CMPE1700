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
            string repeat;
            do
            {
                bool success = true;
                byte userInput = 0;
                byte byMask = 0x01;
                int output = 0;
                int input = 0;
                repeat = "";
                do
                {
                    Console.WriteLine("Please enter an 8-bit binary number: ");
                    try
                    {
                        userInput = Convert.ToByte(Console.ReadLine(), 2);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        success = false;
                    }
                }
                while (success == false);

                success = false;

                do
                {
                    Console.Write("which bit position would you like to evaluate for? (0-7) ");
                    success = int.TryParse(Console.ReadLine(), out input);
                    if (success == false)
                        Console.WriteLine("That is not a number please enter a value between 0 & 7");
                    else if (input > 7 || input < 0)
                        Console.WriteLine("That value is invalid please enter a value between 0 & 7");
                }
                while (success == false || input > 7 || input < 0);

                byMask <<= input;

                if ((userInput & byMask) == 0)
                    output = 0;
                else
                    output = 1;

                Console.WriteLine("The bit is a " + output);
                Console.Write("\nRun the program again? Answer Yes or No: ");
                repeat = Console.ReadLine();
            }
            while (repeat == "Yes");
        }
    }
}

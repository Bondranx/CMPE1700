using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA11
{
    class HiLo
    {
        static void Main(string[] args)
        {
            int temp2 = 500;
            int count = 0;
            int guess;
            int search = 500;
            string userInput = "";
            int[] numArray = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                numArray[i] = i + 1;
            }

            Console.WriteLine("Please select a number between 1 and 1000.");

            do
            {
                guess = BinarySearch(numArray,search) + 1;
                Console.WriteLine("is your number {0}?", guess);
                userInput = Console.ReadLine().ToLower();
                if (userInput == "h" || userInput == "hi" || userInput == "high")
                {
                    temp2 = temp2 / 2;
                    search = guess - temp2;
                    count++;
                }
                else if (userInput == "l" || userInput == "lo" || userInput == "low")
                {
                    temp2 = temp2 / 2;
                    search = guess + temp2;
                    count++;
                }
                else if (userInput == "y" || userInput == "yes")
                {
                }
                else
                {
                    Console.WriteLine("\nI don't understand please try again\n");
                }
            }
            while (userInput != "y" && userInput != "yes");

            Console.WriteLine("Your number is {0}, I got it in {1} guesses.", guess, count);

            Console.ReadLine();
        }
        public static int BinarySearch(int[] iArray, int iSearch)
        {
            int iLower = 0; //lower index of the subarray 
            int iUpper = iArray.Length - 1; //upper index of the subarray 
            int iMiddle = 0; //midpoint of the subarray 
            int iFoundAt = -1; //location found, -1 == not found 

            while ((iLower <= iUpper) && (iFoundAt == -1))
            {
                iMiddle = (iLower + iUpper) / 2;
                if (iSearch > iArray[iMiddle])
                    iLower = iMiddle + 1;
                else if (iSearch < iArray[iMiddle])
                    iUpper = iMiddle - 1;
                else
                    iFoundAt = iMiddle;
            }
            return iMiddle;
        }
    }
}

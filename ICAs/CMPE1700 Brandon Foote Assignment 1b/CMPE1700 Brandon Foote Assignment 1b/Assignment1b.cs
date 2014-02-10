using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700_Brandon_Foote_Assignment_1b
{
    class Assignment1b
    {
        static void Main(string[] args)
        {
            int input = 0;
            int count = 0;
            int temp = 0;
            int x = 0;
            bool hasSwapped = false;
            Random generator = new Random();
            Console.WriteLine("How many rolls should be generated?: ");
            int.TryParse(Console.ReadLine(), out input);
            int[] array = new int[input];
            do
            {
                array[count] = generator.Next(1, 7) + generator.Next(1, 7);
                count++;
            }
            while (count < input);

            if (input < 2)
            {
            }
            else
            {
                Console.WriteLine("Commenced sorting of {0} items", count);
                do
                {
                    hasSwapped = false;
                    x = 0;
                    do
                    {
                        if (array[x] > array[x + 1])
                        {
                            temp = array[x];
                            array[x] = array[x + 1];
                            array[x + 1] = temp;
                            hasSwapped = true;
                        }
                        x++;
                    }
                    while (x < input - 1);
                }
                while (hasSwapped == true);
                Console.WriteLine("Sort concluded");
                Console.WriteLine("\nHistogram of roll results\n");
                x = 0;
                temp = 0;
                while (x < input)
                {
                    if (temp != array[x])
                    {
                        temp = array[x];
                        Console.Write("\n");
                        Console.Write("{0}:", temp);
                    }
                    Console.Write("*");
                    x++;
                }
                Console.WriteLine("");
                Console.ReadLine();
            }
        }
    }
}

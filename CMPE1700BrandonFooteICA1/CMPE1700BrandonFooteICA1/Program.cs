using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA1
{
    class Program
    {
        public enum Planets {Mercury = 1, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune};
        static void Main(string[] args)
        {
            double mass = 0;
            double weight = 0;
            double modifier = 0;
            int input = 0;
            bool success = false;
            do
            {
                Console.Write("What is your current mass (in Kg)? ");
                success = double.TryParse(Console.ReadLine(), out mass);
            }
            while (success == false || mass < 0);
            success = false;
            foreach (var value in Enum.GetValues(typeof(Planets)))
                Console.WriteLine("({0}) {1}", (int)value, value);
            do
            {
            Console.Write("Please enter the number of the planet you wish to visit: ");
            success = int.TryParse(Console.ReadLine(), out input);
            }
            while(success == false || input < 1 || input > 8);
            switch (input)
            {
                case 1:
                    modifier = 3.7;
                    break;
                case 2:
                    modifier = 8.87;
                    break;
                case 3:
                    modifier = 9.81;
                    break;
                case 4:
                    modifier = 3.71;
                    break;
                case 5:
                    modifier = 24.92;
                    break;
                case 6:
                    modifier = 10.44;
                    break;
                case 7:
                    modifier = 8.87;
                    break;
                case 8:
                    modifier = 11.15;
                    break;
            }
            weight = mass * modifier;
            Console.WriteLine("On the surface of {0} you would weigh: {1} Newtons", (Planets)input, weight);
            Console.ReadLine();
        }
    }
}

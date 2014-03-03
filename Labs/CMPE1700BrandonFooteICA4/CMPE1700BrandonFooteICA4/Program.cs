using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CMPE1700BrandonFooteICA4
{
    class Program
    {
        public static bool OpenFile(out StreamReader FileOpened, string userInput)
        {
            bool success = false;
            FileOpened = null;
            try
            {
                FileOpened = new StreamReader(userInput);
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                success = false;
            }
            return success;
        }

        public static int GetLine(ref string LineRead, StreamReader File, int LineNumber)
        {
            int count = 1;
            int output = 0;

            try
            {
                do
                {
                    if (count == LineNumber)
                    {
                        LineRead = File.ReadLine();
                        output = LineNumber;
                    }
                    else if (File.ReadLine() == null)
                    {
                        File.ReadLine();
                        output = -1;
                    }
                    else
                    {
                        output = -1;
                    }
                    count++;
                }
                while (count < LineNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return output;
        }


        static void Main(string[] args)
        {
            string userInput = "";
            string desktopPath = "";
            string LineRead = "";
            string fullPath = "";
            bool success = false;
            int output = 0;
            int LineNumber = 0;
            StreamReader NewFile;

            do
            {
                Console.Write("Please enter the name of the file to open: ");
                userInput = Console.ReadLine();
                desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fullPath = System.IO.Path.Combine(desktopPath, userInput);

                success = OpenFile(out NewFile, fullPath);
            }
            while (success == false);

            Console.WriteLine("Which line number would you like to read from the file?: ");
            int.TryParse(Console.ReadLine(), out LineNumber);

            output = GetLine(ref LineRead, NewFile, LineNumber);

            if (output == -1)
            {
                Console.WriteLine("File " + userInput + " does not contain a line at line number " + LineNumber);
            }
            else
            {
                Console.WriteLine("Line Read: " + LineRead + "At line: " + output);
            }
            Console.ReadKey();
        }
    }
}

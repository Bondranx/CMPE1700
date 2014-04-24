using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA12
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Random newRandom = new Random();
            List<int> newList = new List<int>();
            LinkedList<int> finalList = new LinkedList<int>();
            int[] newArray = new int[100];
            for (int i = 0; i < 100; i++)
            {
                newList.Add(newRandom.Next(-99,100));
            }

            foreach (int i in newList)
                Console.WriteLine(i);
            Console.ReadLine();

            Console.WriteLine("");

            SelectionSort(newList);

            foreach (int i in newList)
                Console.WriteLine(i);
            Console.ReadLine();

            LinkedList<int> newLinkedList = new LinkedList<int>();

            for (int i = 0; i < 100; i++)
            {
                //LinkedListNode<int> newNode = new LinkedListNode<int>(newRandom.Next(-99,100));
                newLinkedList.AddLast(newRandom.Next(-99,100));
            }

            foreach (int value in newLinkedList)
            {
                Console.WriteLine(value);
                newArray[count] = value;
                count++;
            }

            Console.ReadLine();

            InsertionSort(newArray);

            foreach (int value in newArray)
            {
                finalList.AddLast(value);
            }

            foreach (int value in finalList)
            {
                Console.WriteLine(value);
            }
            Console.ReadLine();
        }

        public static void SelectionSort(List<int> newList)
        {
            int iMinValue = 0; //current min value during scan 
            int iMinIndex = 0; //index where min value found 
            int iTemp = 0; //temporary storage for swapping 
            int iCurrent = 0; //current location for selected value 
            int iScan = 0; //index to scan the unsorted array 

            for (iCurrent = 0; iCurrent < newList.Count - 1; iCurrent++)
            {
                iMinIndex = iCurrent;

                for (iScan = iCurrent + 1; iScan < newList.Count; iScan++)
                {
                    if (newList[iScan] < newList[iMinIndex])
                    {
                        iMinIndex = iScan;
                    }
                }
                iTemp = newList[iMinIndex];
                newList[iMinIndex] = newList[iCurrent];
                newList[iCurrent] = iTemp;
            }
        }

        public static void InsertionSort(int[] iArray)
        {
            int iTemp = 0;
            int iPass = 0;
            int iScan = 0;

            for (iPass = 1; iPass < iArray.Length; iPass++)
            {
                iScan = iPass - 1;
                iTemp = iArray[iPass];

                while ((iScan >= 0) && (iTemp < iArray[iScan]))
                {
                    iArray[iScan + 1] = iArray[iScan];
                    iScan--;
                }
                iArray[iScan + 1] = iTemp;
            }
        }
    }
}

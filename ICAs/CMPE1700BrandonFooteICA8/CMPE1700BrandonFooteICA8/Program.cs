using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA8
{
    class Program
    {

        public class Node
        {
            //Node's internal data
            public int Value;
            //Reference to next item in the list (classes are reference types)
            public Node Next;
            
            //ctors
            public Node()
            {
                Value = 0; 
                Next = null;
            }

            public Node(int val)
            {
                Value = val;
                Next = null;
            }
        }

        static public Node AddToTail(Node Head, int Value)
        {
            Node Fresh = new Node(Value);

            //Do I have an empty list? jsut return my node
            if (Head == null)
                return Fresh;

            //Otherwise
            Node Current = Head;
            while (Current.Next != null)
                Current = Current.Next;
            Current.Next = Fresh;

            return Head;
        
        }

        static public Node AddToHead(Node Head, int Value)
        {
            Node Fresh = new Node(Value);
            Fresh.Next = Head;
            return Fresh;
        }

        static void PrintList(Node Head)
        {
            while (Head != null)
            {
                Console.WriteLine(Head.Value + " ");
                Head = Head.Next;
            }
        }

        static public Node AddItem(Node Head, int Value)
        {
            return Head;

        }

        static void PrintListReverse(Node Head)
        {
            Node Temp = new Node();
            Node Temp2 = new Node();
            int count = 10;
            while (count != 0)
            {
                Temp = Head;
                for (int i = 0; i < count; i++)
                {
                    Temp2 = Head;
                    Head = Head.Next;
                }
                count--;
                Head = Temp;
                Console.WriteLine(Temp2.Value + " ");
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            Node Head = null;
            string KeyRead = null;

            Console.WriteLine("How would you like to build the list?\n" +
                "LS - Largest to smallest\n" +
                "SL - Smallest to largest\n" +
                "AI - Add Item");

            KeyRead = Console.ReadLine().ToUpper();

            switch (KeyRead)
            {
                case "LS":
                    for (int i = 0; i < 10; ++i)
                        Head = AddToHead(Head, i);
                    break;
                case "SL":
                    for (int i = 0; i < 10; ++i)
                        Head = AddToTail(Head, i);
                    break;
                case "AI":
                    for (int i = 0; i < 10; ++i)
                        Head = AddToHead(Head, rand.Next(0,11));

                    break;
            }

            Console.WriteLine("How would you like to disply the list?\n" +
                "N - Normal\n" +
                "R - Reverse");

            KeyRead = Console.ReadLine().ToUpper();

            switch (KeyRead)
            {
                case "N":
                    PrintList(Head);
                    break;
                case "R":
                    PrintListReverse(Head);
                    break;
            }

            Console.ReadKey();
        }
    }
}

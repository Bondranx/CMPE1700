using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 100; ++i)
                AddNode(list, rand.Next()%100);
            PrintList(list.First);
            Console.WriteLine();
            PrintContainer(MakeContainerFromList(list));
            Console.ReadKey();
        }

        public static void AddNode(LinkedList<int> a, int b)
        {
            a.AddFirst(b);
        }

        public static void PrintList(LinkedListNode<int> a)
        {
            if (a.Next == null)
            {
                Console.Write(a.Value + " ");
                return;
            }
            Console.Write(a.Value + " ");
            PrintList(a.Next);
            return;
        }

        public static Stack<int> MakeContainerFromList(LinkedList<int> a)
        {
            Stack<int> newStack = new Stack<int>();
            foreach (int value in a)
                newStack.Push(value);
            return newStack;
        }

        public static void PrintContainer(Stack<int> a)
        {
            a.Reverse();
            int count = 0;
            Console.WriteLine();
            while (count < 100)
            {
                Console.Write(a.Pop() + " ");
                count++;
            }
        }
    }
}

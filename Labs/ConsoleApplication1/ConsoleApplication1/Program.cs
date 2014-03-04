using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication1
{
    [Serializable]
    public class Program
    {
        public static bool search(List<Dice> newList, int search, out int found)
        {
            bool TrueFalse = false;
            int count = 0;
            found = -1;
            do
            {
                if ((int)(newList[count].one) + (int)(newList[count].two) == search) 
                {
                    found = count;
                    TrueFalse = true;
                }
                count++;
            }
            while (found == -1 && count < newList.Count);

            return TrueFalse;
        }

        public enum Die {One=1, Two, Three, Four, Five, Six};
        public static Random Rand = new Random();
        [Serializable]
        public struct Dice
        {
            public Die one;
            public Die two;
            public Dice(Die dieOne, Die dieTwo)
            {
                one = dieOne;
                two = dieTwo;
            }
            public Dice(bool trueFalse)
            {
                if (trueFalse == true)
                {
                    one = (Die)Rand.Next(1, 7);
                    two = (Die)Rand.Next(1, 7);
                }
                else
                {
                    one = (Die)1;
                    two = (Die)1;
                }
            }
            public override string ToString()
            {
                return (((int)one + (int)two).ToString() + "(" + (Die)one + " " + (Die)two + ")");
            }
        }
        
        static void Main(string[] args)
        {
            List<Dice> DiceList = new List<Dice>();
            FileStream newStream = new FileStream("Storage.bin", FileMode.Create, FileAccess.Write);
            BinaryFormatter newWriter = new BinaryFormatter();
            bool success = false;
            int searchNum = 0;
            int foundNum;

            for (int count = 0; count < 10; count++)
            {
                Dice newDie = new Dice((Die)Rand.Next(1,7), (Die)Rand.Next(1,7));
                DiceList.Add(newDie);
            }

            foreach (Dice i in DiceList)
            {
                Console.WriteLine(i.ToString());
            }
            while (success == false)
            {
                Console.Write("What value would you like to search for?: ");
                int.TryParse(Console.ReadLine(), out searchNum);
                success = search(DiceList, searchNum, out foundNum);
                if (foundNum == -1)
                {
                    Console.WriteLine(searchNum + " Not Found in List");
                }
                else
                {
                    Console.WriteLine(searchNum + " Found at index: " + foundNum);
                }
            }

            Console.ReadKey();
            newWriter.Serialize(newStream, DiceList);
            newStream.Close();
            DiceList.Clear();
            FileStream streamTwo = new FileStream("Storage.bin", FileMode.Open, FileAccess.Read);
            DiceList = (List<Dice>)newWriter.Deserialize(streamTwo);
            Console.WriteLine("");
            foreach (Dice i in DiceList)
            {
                Console.WriteLine(i.ToString());
            }
            Console.ReadKey();
        }
    }
}

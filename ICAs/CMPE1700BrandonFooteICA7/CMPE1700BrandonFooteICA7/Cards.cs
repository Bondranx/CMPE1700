using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA7
{
    class Cards
    {
        public static Stack<Card> Shuffle(Stack<Card> Deck)
        {
            Stack<Card> partTwo = new Stack<Card>();
            Stack<Card> FinalDeck = new Stack<Card>();
            Random newRandom = new Random();
            int Position = 0;
            int count2 = 0;

            Position = newRandom.Next(15, 40);

            for (int count = 0; count < Position; count++)
            {
                partTwo.Push(Deck.Pop());
            }

                while (Deck.Count != 0 || partTwo.Count != 0)
                {

                    if (count2 == 0 && partTwo.Count != 0)
                        FinalDeck.Push(partTwo.Pop());
                    else if (count2 == 1 && Deck.Count != 0)
                        FinalDeck.Push(Deck.Pop());

                    if (count2 == 1)
                        count2 = 0;
                    else if(count2 == 0)
                        count2 = 1;
                }
            return FinalDeck;
        }

        static void Main(string[] args)
        {
            Stack<Card> Deck = new Stack<Card>();

            for (int count = 0; count < 4; count++)
            {
                for (int count2 = 2; count2 < 15; count2++)
                {
                    Card NewCard = new Card((CardSuit)count, (CardNumber)count2);
                    Deck.Push(NewCard);
                }
            }
            for(int count = 0; count < 15; count++)
                Deck = Shuffle(Deck);

            for (int count = 0; count < 4; count++)
            {
                for (int count2 = 0; count2 < 13; count2++)
                {
                    Console.WriteLine(Deck.Pop());
                }
                Console.WriteLine();
            }
                Console.ReadLine();
                
        }
        
    }
}

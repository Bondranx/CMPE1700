using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA2
{
    class Cards
    {

        static void Main(string[] args)
        {            
            Random number = new Random();
            List<Card> Deck = new List<Card>();
            Card swap = new Card();
            
            for (int count = 0; count < 4; count++)
            {
                for (int count2 = 2; count2 < 15; count2++)
                {
                    Card NewCard = new Card((CardSuit)count, (CardNumber)count2);
                    Deck.Add(NewCard);
                    
                }
            }

            for (int count = 51; count >= 0; count--)
            {
                int random = number.Next(0, count);
                swap = (Deck[count]);
                Deck[count] = Deck[random];
                Deck[random] = swap;
            }

            foreach (Card value in Deck)
            {
                Console.WriteLine(value);
            }
            Console.ReadLine();
        }
    }
}

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
            List<Card> Deck = new List<Card>();

            for (int count = 0; count < 4; count++)
            {
                for (int count2 = 2; count2 < 15; count2++)
                {
                    Card NewCard = new Card((CardSuit)count, (CardNumber)count2);
                    Deck.Add(NewCard);
                    Console.WriteLine(NewCard.ToString());
                }
            }


            Console.ReadLine();
        }
    }
}

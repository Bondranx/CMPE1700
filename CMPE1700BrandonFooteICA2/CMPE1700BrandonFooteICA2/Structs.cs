using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA2
{
    class Structs
    {
        public enum CardSuit { Clubs, Diamonds, Hearts, Spades };
        public enum CardNumber { Deuce = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14 };
        public struct Card
        {
            public string _suit;
            public string _number;
            

            public Card(string suit, string number)
            {
                _suit = "";
                _number = "";
            }
            public override string ToString()
            {
                return string.Format("{0}, {1}", _suit, _number);
            } 
        }
    }
}

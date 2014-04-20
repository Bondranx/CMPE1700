using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700BrandonFooteICA9
{
    public enum CardSuit { Clubs, Diamonds, Hearts, Spades };
    public enum CardNumber { Deuce = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
    public struct Card
    {
        public CardSuit _suit;
        public CardNumber _number;


        public Card(CardSuit suit, CardNumber number)
        {
            _suit = suit;
            _number = number;
        }
        public override string ToString()
        {
            return string.Format("{0}, of {1}", _number, _suit);
        }
    }

}

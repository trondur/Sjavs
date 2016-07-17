using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sjavs.Enums;

namespace Sjavs
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public Strenght Strength { get; private set; }
        public int TrumpStrength { get; set; } 
        public Card(Suit suit, Strenght strength)
        {
            Suit = suit;
            Strength = strength;
            TrumpStrength = GetTrumpStrength();
        }

        public override string ToString()
        {
            return Strength + " of " + Suit;
        }

        private int GetTrumpStrength()
        {
            if (Suit == Suit.Clubs)
            {
                if (Strength == Strenght.Queen)
                {
                    return 6;
                }
                if (Strength == Strenght.Jack)
                {
                    return 4;
                }
            }
            if (Suit == Suit.Spades)
            {
                if (Strength == Strenght.Queen)
                {
                    return 5;
                }
                if (Strength == Strenght.Jack)
                {
                    return 3;
                }
            }
            if (Suit == Suit.Hearts && Strength == Strenght.Jack)
            {
                return 2;
            }
            if (Suit == Suit.Diamonds && Strength == Strenght.Jack)
            {
                return 1;
            }
            return 0;
        }
    }
}

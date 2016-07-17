using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sjavs.Enums;

namespace Sjavs
{
    public static class CardMethods
    {
        public static int GetScore(List<Card> cards)
        {
            var score = 0;
            foreach (var card in cards)
            {
                switch (card.Strength)
                {
                    case Strenght.Seven:
                    case Strenght.Eight:
                    case Strenght.Nine:
                        break;
                    case Strenght.Ten:
                        score += 10;
                        break;
                    case Strenght.Jack:
                        score += 2;
                        break;
                    case Strenght.Queen:
                        score += 3;
                        break;
                    case Strenght.King:
                        score += 4;
                        break;
                    case Strenght.Ace:
                        score += 11;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return score;
        }

        public static bool IsBreakingEven(List<Card> cards)
        {
            return GetScore(cards) >= 30;
        }
    }
}

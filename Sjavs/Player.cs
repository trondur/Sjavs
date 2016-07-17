using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sjavs.Enums;

namespace Sjavs
{
    public class Player
    {
        public List<Card> Hand { get; private set; }
        public String Name { get; private set; }
        public PlayerPosition Position { get; private set; }
        public Player(List<Card> cards, string name, PlayerPosition position)
        {
            Hand = cards;
            Name = name;
            Position = position;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("");
            for(int i = 0; i < Hand.Count; i++)
            {
                builder.Append(i + ": " + Hand[i].ToString() + System.Environment.NewLine);            
            }
            return builder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sjavs.Enums;

namespace Sjavs
{
    public class Game
    {
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }
        public Player ThirdPlayer { get; set; }
        public Player FourthPlayer { get; set; }
        public Game()
        {
            var cards = CreateCards();

            FirstPlayer = new Player(cards.GetRange(0, 8), "Player 1", PlayerPosition.First);
            SecondPlayer = new Player(cards.GetRange(8, 8), "Player 2", PlayerPosition.Second);
            ThirdPlayer = new Player(cards.GetRange(16, 8), "Player 3", PlayerPosition.Third);
            FourthPlayer = new Player(cards.GetRange(24, 8), "Player 4", PlayerPosition.Fourth);

        }

        private List<Card> CreateCards()
        {
            var cards = new List<Card>();
            foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                foreach (var strength in Enum.GetValues(typeof(Strenght)).Cast<Strenght>())
                {
                    cards.Add(new Card(suit, strength));                                           
                }   
            }
            Shuffle(cards);
            return cards;

        }
        private static void Shuffle<T>(IList<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}

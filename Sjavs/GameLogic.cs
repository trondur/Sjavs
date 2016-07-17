using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sjavs.Enums;

namespace Sjavs
{
    public class GameLogic
    {
        private static Suit trump = Suit.Spades;
        CardPool cardPool = new CardPool(Suit.Clubs);
        List<Card> playerOneAndThreePoints = new List<Card>();
        List<Card> playerTwoAndFourPoints = new List<Card>();

        Game game = new Game();
        string line;
        
        public List<Card> PlayCard(List<Card> cardPool, Card playedCard)
        {
            cardPool.Add(playedCard);
            if (cardPool.Count == 4)
            {
                Console.WriteLine("Full");
            }
            return cardPool;
        }

        public void Play()
        {
            while ((line = Console.ReadLine()) != string.Empty)
            {
                switch (line)
                {
                    case "play card":
                        break;
                    case "print player1":
                        Console.WriteLine(game.FirstPlayer.ToString());
                        break;
                    case "print player2":
                        Console.WriteLine(game.SecondPlayer.ToString());
                        break;
                    case "print player3":
                        Console.WriteLine(game.ThirdPlayer.ToString());
                        break;
                    case "print player4":
                        Console.WriteLine(game.FourthPlayer.ToString());
                        break;
                    case "play player1":
                        var index1 = int.Parse(Console.ReadLine());                    
                        var card1 = game.FirstPlayer.Hand[index1];
                        if(cardPool.PlayCard(PlayerPosition.First, card1))
                        {
                            game.FirstPlayer.Hand.RemoveAt(index1);                
                        }
                        break;
                    case "play player2":
                        var index2 = int.Parse(Console.ReadLine());
                        var card2 = game.SecondPlayer.Hand[index2];
                        if (cardPool.PlayCard(PlayerPosition.Second, card2))
                        {
                            game.SecondPlayer.Hand.RemoveAt(index2);
                        }
                        break;
                    case "play player3":
                        var index3 = int.Parse(Console.ReadLine());
                        var card3 = game.ThirdPlayer.Hand[index3];
                        if (cardPool.PlayCard(PlayerPosition.Third, card3))
                        {
                            game.ThirdPlayer.Hand.RemoveAt(index3);
                        }
                        break;
                    case "play player4":
                        var index4 = int.Parse(Console.ReadLine());
                        var card4 = game.FourthPlayer.Hand[index4];
                        if (cardPool.PlayCard(PlayerPosition.Fourth, card4))
                        {
                            game.FourthPlayer.Hand.RemoveAt(index4);
                        }
                        break;
                    case "print cardpool":
                        foreach (var card5 in cardPool.GetCardPool().Where(card5 => card5 != null))
                        {
                            Console.WriteLine(card5.ToString());
                        }
                        break;
                    case "print leading":
                        Console.WriteLine(cardPool.GetLeader().Item1);
                        Console.WriteLine(cardPool.GetLeader().Item2);
                        break;
                    case "print score1":
                        Console.WriteLine(CardMethods.GetScore(playerOneAndThreePoints));
                        break;
                    case "print score2":
                        Console.WriteLine(CardMethods.GetScore(playerTwoAndFourPoints));
                        break;
                    case "bid":
                        switch (Console.ReadLine())
                        {
                            case "player1":
                                Console.WriteLine(GetBidPossibilities(game.FirstPlayer.Hand));
                                break;
                            case "player2":
                                Console.WriteLine(GetBidPossibilities(game.SecondPlayer.Hand));
                                break;
                            case "player3":
                                Console.WriteLine(GetBidPossibilities(game.ThirdPlayer.Hand));
                                break;
                            case "player4":
                                Console.WriteLine(GetBidPossibilities(game.FourthPlayer.Hand));
                                break;
                            default:
                                Console.WriteLine("Unknown command");
                                break;
                       }
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                if (cardPool.AllHavePlayed())
                {
                    switch (cardPool.GetLeader().Item1)
                    {
                        case PlayerPosition.First:
                        case PlayerPosition.Third:
                            playerOneAndThreePoints.AddRange(cardPool.GetCardPool());
                            break;
                        case PlayerPosition.Second:
                        case PlayerPosition.Fourth:
                            playerTwoAndFourPoints.AddRange(cardPool.GetCardPool());
                            break;
                    }
                    cardPool.ClearPool();
                }
            }
        }

        public List<KeyValuePair<Suit, int>> GetBidPossibilities(List<Card> hand)
        {
            int trumps = 0, clubs = 0, spades = 0, hearts = 0, diamonds = 0;
            foreach (var card in hand)
            {
                if (card.TrumpStrength > 1)
                {
                    trumps++;
                }
                switch (card.Suit)
                {
                    case Suit.Clubs:
                        clubs++;
                        break;
                    case Suit.Spades:
                        spades++;
                        break;
                    case Suit.Hearts:
                        hearts++;
                        break;
                    case Suit.Diamonds:
                        diamonds++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return new List<KeyValuePair<Suit, int>>()
            {
                new KeyValuePair<Suit, int>(Suit.Clubs, clubs),
                new KeyValuePair<Suit, int>(Suit.Spades, spades),
                new KeyValuePair<Suit, int>(Suit.Hearts, hearts),
                new KeyValuePair<Suit, int>(Suit.Diamonds, diamonds),
            };
        }
    }
}

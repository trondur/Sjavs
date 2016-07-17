using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sjavs.Enums;

namespace Sjavs
{
    public class CardPool
    {
        Card FirstPlayerCard;
        Card SecondPlayerCard;
        Card ThirdPlayerCard;
        Card FourthPlayerCard;

        private PlayerPosition leader;
        private Card leadingCard;

        private Suit trump;

        public CardPool(Suit trump)
        {
            this.trump = trump;
            leader = PlayerPosition.None;
        }

        /// <summary>
        /// Adds a card to ther cardpool.
        /// </summary>
        /// <param name="position">Player position</param>
        /// <param name="card">Card to play</param>
        /// <returns>True if the player has not added a card to the current cardpool already</returns>
        public bool PlayCard(PlayerPosition position, Card card)
        {
            switch (position)
            {
                case PlayerPosition.First:
                    if (FirstPlayerCard == null)
                    {
                        FirstPlayerCard = card;
                        if (IsHigherThanCurrentLeader(card))
                        {
                            leader = PlayerPosition.First;
                            leadingCard = card;
                        }
                        return true;
                    }
                    break;
                case PlayerPosition.Second:
                    if (SecondPlayerCard == null)
                    {
                        SecondPlayerCard = card;
                        if (IsHigherThanCurrentLeader(card))
                        {
                            leader = PlayerPosition.Second;
                            leadingCard = card;
                        }
                        return true;
                    }
                    break;
                case PlayerPosition.Third:
                    if (ThirdPlayerCard == null)
                    {
                        ThirdPlayerCard = card;
                        if (IsHigherThanCurrentLeader(card))
                        {
                            leader = PlayerPosition.Third;
                            leadingCard = card;
                        }
                        return true;
                    }
                    break;
                case PlayerPosition.Fourth:
                    if (FourthPlayerCard == null)
                    {
                        FourthPlayerCard = card;
                        if (IsHigherThanCurrentLeader(card))
                        {
                            leader = PlayerPosition.Fourth;
                            leadingCard = card;
                        }
                        return true;
                    }
                    break;
            }
            return false;
        }
        /// <summary>
        /// Sets all cards in the cardpool to null
        /// </summary>
        public void ClearPool()
        {
            FirstPlayerCard = null;
            SecondPlayerCard = null;
            ThirdPlayerCard = null;
            FourthPlayerCard = null;
            leadingCard = null;
            leader = PlayerPosition.None;
        }

        /// <summary>
        /// Checks if all players have played a card this round.
        /// </summary>
        /// <returns>True if all players have playeds a card this round, else returns false.</returns>
        public bool AllHavePlayed()
        {
            return (FirstPlayerCard != null) && (SecondPlayerCard != null) && (ThirdPlayerCard != null) &&
                   (FourthPlayerCard != null);
        }

        /// <summary>
        /// Compares the current leading card of the cardpool with a given card and returns the bigger one of them.
        /// </summary>
        /// <returns>A tuple with the player position with the leading card and the leading card</returns>
        public Tuple<PlayerPosition, Card> GetLeader()
        {
            return new Tuple<PlayerPosition, Card>(leader, leadingCard);
        }
        /// <summary>
        /// Throws exception if all players have not played.
        /// </summary>
        /// <returns>List of all cards in the cardPool</returns>
        public List<Card> GetCardPool()
        {
            if (AllHavePlayed())
            {
                return new List<Card>()
                {
                    FirstPlayerCard,
                    SecondPlayerCard,
                    ThirdPlayerCard,
                    FourthPlayerCard
                };
            }
            else
            {
                throw new ArgumentNullException("","Not all players have played their cards");
            }
        }
        /// <summary>
        /// Checks if the played card is higher than the current leaders card.
        /// </summary>
        /// <param name="playedCard">Card to be played</param>
        /// <returns>True if card is higher than the current leaders card</returns>
        private bool IsHigherThanCurrentLeader(Card playedCard)
        {
            if (leadingCard == null)
            {
                return true;
            }
            if (playedCard.TrumpStrength > leadingCard.TrumpStrength)
            {
                return true;
            }
            if (playedCard.Suit == trump)
            {
                if (leadingCard.Suit == trump)
                {
                    return playedCard.Strength > leadingCard.Strength;
                }
                return true;
            }
            if (leadingCard.Suit == trump)
            {
                return false;
            }
            return playedCard.Strength > leadingCard.Strength;
        }
    }
}

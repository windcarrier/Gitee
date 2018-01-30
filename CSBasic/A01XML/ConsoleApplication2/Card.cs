using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }
    public enum Rank
    {
        Ace =1,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }
    public class Card
    {
        public readonly Suit suit;
        public readonly Rank rank;
        public Card(Suit aSuit, Rank aRank)
        {
            suit = aSuit;
            rank = aRank;
        }
        public override string ToString()
        {
            return "The " + rank + " of" + suit + "s";
        }
    }
    public class Desk
    {
        private Card[] cards;
        /// <summary>
        /// Desk cotains Cards
        /// </summary>
        public Desk()
        {
            cards = new Card[52];
            for(int suitVal= 0;suitVal<4;suitVal++)
            {
                for (int rankVal =1;rankVal<14;rankVal++)
                {
                    cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
                }
            }
        }
        /// <summary>
        /// 得到一张牌的算法
        /// </summary>
        /// <param name="cardNum">IptcardNum</param>
        /// <returns>Card</returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                return cards[cardNum];
            }
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51."));
        }
        /// <summary>
        /// 洗牌
        /// </summary>
        public void Shuffle()
        {
            Card[] newDeck = new Card[52];
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int destCard = 0;
                bool foundCard = false;
                while(foundCard== false)
                {
                    destCard = sourceGen.Next(52);
                    if(assigned[destCard]==false)
                    {
                        foundCard = true;
                    }
                }
                assigned[destCard] = true;
                newDeck[destCard] = cards[i];
            }
            newDeck.CopyTo(cards, 0);
        }
    }
    public class Cards : CollectionBase
    {
        public void Add(Card aCard)
        {
            List.Add(aCard);
        }
        public void Remove(Card aCard)
        {
            List.Remove(aCard);
        }
        public Card this[int cardIndex]
        {
            get
            {
                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }
        public void CopyTo(Cards targetCards)
        {
            for(int i = 0;i<this.Count;i++)
            {
                targetCards[i] = this[i];
            }
        }
        public bool Contains(Card aCard) => this.InnerList.Contains(aCard);
    }
}

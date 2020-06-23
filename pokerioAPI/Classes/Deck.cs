using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace pokerioAPI.Classes {
    public enum Suit {
        Club,
        Diamond,
        Heart,
        Spade
    }

    //This enum will represent the card values.
    //Ace is set to 1 so the enum storage matches
    //the card rank.
    public enum Rank {
        Ace = 1,
        Two,
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
        King
    }

    //The Card class will be used as a template for
    //selecting cards.
    public class Card {
        //The fields are set to 'read-only' because
        //there's no need for a blank card, or
        //for the card to change value once 
        //created...
        public readonly Suit suit;
        public readonly Rank rank;

        //..to facilitate this, the default 
        //constructor will be set to private...
        private Card() {

        }

        //...and an alternative contructor is 
        //provided to build a card from supplied 
        //suit and rank.
        public Card(Suit newSuit, Rank newRank) {
            suit = newSuit;
            rank = newRank;
        }

        //Lastly, an override of System.Object's 
        //ToString() method is needed to provide a
        //more readable string output.
        public override string ToString() {
            return $"{{\n\"Suit\":{suit},\n \"Rank\": {rank}}}";

        }
    }

    //The Deck class will be used to maintain 52 
    //card objects.
    public class Deck {
        //Although this array is used to maintain  
        //the card objects, it won't be directly 
        //accessible because access is achieved 
        //through the GetCard() method, hence the
        //private access modifier.
        public List<Card> cards = new List<Card>();
        private int Size = 52;
        //private bool[] CardMap = Enumerable.Repeat(true, 52).ToArray(); 
        //Default constructor, which creates and 
        //assigns 52 cards in the 'cards' field.
        public Deck() {
            for(int suitVal = 0;suitVal < 4;
                 suitVal++) {
                for(int rankVal = 1;rankVal < 14;
                     rankVal++) {
                    cards.Add(new Card((Suit)suitVal,(Rank)rankVal));
                }
            }
            //RemainingCards = cards;
        }

        //This Card method will return the card object + 
        //index or throws an exception if out of 
        //range.
        /*public Card GetCard(int cardNum) {
            if(cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw
                (new System.ArgumentOutOfRangeException
                ("cardNum", cardNum,
                 "Value must be between 0 and 51."));
        }*/
        public Card GetCard(int cardNum) {
            if(cardNum >= 0 && cardNum <= 51) {
                //if(CardMap[cardNum]) {
                  //  CardMap[cardNum] = false;
                    //RemainingCards = RemainingCards - cards[cardNum];
                    return cards[cardNum];
                //}
                //else {
                    //throw (new System.ArgumentException("card already drawn", "Try a card that has not been drawn"));
              //  }
            }
            else
                throw
                (new System.ArgumentOutOfRangeException
                ("cardNum", cardNum,
                 "Value must be between 0 and 51."));
        }
        public Card DrawCard() {
            Random a = new Random();
            int tmp = a.Next(Size);
            Size--;
            Card c = GetCard(tmp);
            cards = cards.Where(t => t != null).ToList();
            return c;
        }

        //The shuffle method works by creating a
        //temp card array and copies cards from
        //existing card array into this array at
        //random. To keep a record of assigned cards,
        //an array of bool variables is used,
        //assigning these to true as each card is
        //copied. If location is in use, another
        //number is generated at random.
        public void Shuffle() {
            Card[] newDeck = new Card[52];
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();

            for(int i = 0;i < 52;i++) {
                int destCard = 0;
                bool foundCard = false;
                while(foundCard == false) {
                    destCard = sourceGen.Next(52);
                    if(assigned[destCard] == false)
                        foundCard = true;
                }
                assigned[destCard] = true;
                newDeck[destCard] = cards[i];
            }
            cards.Clear();
            cards.AddRange(newDeck);
        }
    }
}

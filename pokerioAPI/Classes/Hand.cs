using pokerioAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokerioAPI.Models {
    public class Hand {
        List<Card> cardsInHand = new List<Card>();

        public Hand(ref Deck d) {
            cardsInHand.Add(d.DrawCard());
            cardsInHand.Add(d.DrawCard());
        }
        public Hand() { }

        public List<Card> getCardsInHand() {
            return cardsInHand;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokerioAPI.Classes {
    public class CardSort {
        public Deck deck = new Deck();

        public CardSort() {
            var sorted = deck.cards
    .GroupBy(l => l.suit)
    .OrderByDescending(g => g.Count())
    .SelectMany(g => g.OrderByDescending(c => c.rank));
        }
    }

}

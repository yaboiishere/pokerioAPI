using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokerioAPI.Classes {
    public static class CardSort {
        public static List<Card> sortCards(List<Card> cards) => cards
        .GroupBy(l => l.suit)
        .OrderByDescending(g => g.Count())
        .SelectMany(g => g.OrderByDescending(c => c.rank))
        .ToList();

        public static bool CheckPair(List<Card> cards) {
            //see if exactly 2 cards card the same rank.
            return cards.GroupBy(card => card.rank).Count(group => group.Count() == 2) == 1;
        }

        public static bool CheckTwoPair(List<Card> cards) {
            //see if there are 2 lots of exactly 2 cards card the same rank.
            return cards.GroupBy(card => card.rank).Count(group => group.Count() >= 2) == 2;
        }

        public static bool CheckTrips(List<Card> cards) {
            //see if exactly 3 cards card the same rank.
            return cards.GroupBy(card => card.rank).Any(group => group.Count() == 3);
        }
        public static bool CheckStraight(List<Card> cards) {
            //maybe check 5 and 10 here first for performance

            var ordered = cards.OrderByDescending(a => a.rank).ToList();
            for(var i = 0;i < ordered.Count - 4;i++) {
                var skipped = ordered.Skip(i);
                var possibleStraight = skipped.Take(5).ToList();
                if(IsStraight(possibleStraight)) {
                    return true;
                }
            }
            return false;
        }
        public static bool IsStraight(List<Card> cards) {
            return cards.GroupBy(card => card.rank).Count() == cards.Count() && cards.Max(card => (int)card.rank) - cards.Min(card => (int)card.rank) == 4;
        }

        public static bool CheckFlush(List<Card> cards) {
            //see if 5 or more cards card the same rank.
            return cards.GroupBy(card => card.suit).Count(group => group.Count() >= 5) == 1;
        }

        public static bool CheckFullHouse(List<Card> cards) {
            // check if trips and pair is true
            return CheckPair(cards) && CheckTrips(cards);
        }
        public static bool CheckQuads(List<Card> cards) {
            //see if exactly 4 cards card the same rank.
            return cards.GroupBy(card => card.rank).Any(group => group.Count() == 4);
        }

        // need to check same 5 cards
        public static bool CheckStraightFlush(List<Card> cards) {
            // check if flush and straight are true.
            return CheckFlush(cards) && CheckStraight(cards);
        }

    }

}

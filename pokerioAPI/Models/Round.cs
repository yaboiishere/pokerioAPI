using pokerioAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokerioAPI.Models {
    public enum State {
        Preflop,
        Flop,
        Turn,
        River,
        Showdown
    }
    public class Round {
        public long Id { get; set; }
        public Game ParentGame;
        public Card[] Flop = new Card[3];
        public Card Turn;
        public Card River;

        public Round(ref Deck d) {
            for(int i= 0;i<3;i++) {
                Flop[i] = d.DrawCard();
            }
            Turn = d.DrawCard();
            River = d.DrawCard();
        }
        public Round() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pokerioAPI.Classes;

namespace pokerioAPI.Models {

    public class Game {
        public long Id { get; set; }
        public Player Winner { get; set; }
        private List<Player> players = new List<Player>();
        public List<Player> AllInPlayers = new List<Player>();
        public int Pot { get; set; }
        public List<int> Sidepot = new List<int>(0);
        public int potNum = 0;
        public Deck deck = new Deck();
        public Round round = new Round();
        private int lastSmallBlindId = 0;
        private int SmallBlind { get; set; }
        private int roundCount = 1;

        public Game() {
            round = new Round(ref deck);
        }

        public void AddPlayer(Player player) {
            players.Append<Player>(player);
        }
        // string for now TBI
        public string startGame(int smallBlind = 5) {
            //add vote for new game or ready check
            SmallBlind = smallBlind;
            //temp till i make users
            Player tmp = JsonConvert.DeserializeObject<Player>("{\"username\": 'pesho',\"password\": 'pesho',\"balance\": 0,\"isAllin\": false, \"currentWinnings\": 0,\"isDealer\": false,\"isInGame\": false}");
            this.players.Add(tmp);
            this.players.Add(JsonConvert.DeserializeObject<Player>("{\"username\": 'gesho',\"password\": 'pesho',\"balance\": 0,\"isAllin\": false, \"currentWinnings\": 0,\"isDealer\": false,\"isInGame\": false}"));
            List<Player> q = players.Where(p => p.WantsToJoin).ToList();
            if(q.Any()) {
                q.ForEach(que => { que.WantsToJoin = false;
                    que.IsInGame = true;
                });
            }
            q = players.Where(p => p.IsInGame).ToList();
            q.ForEach(que => players.Add(que));
            if(players.Count() > 1) {
                //Deal cards to players TBI

                //
                round = new Round(ref deck);
                Pot = 0;
                Sidepot.Clear();
                Sidepot.Add(0);
                players[lastSmallBlindId].Balance -= /*small blind TBI*/ smallBlind;
                players[lastSmallBlindId + 1].Balance -= /*2*small blind*/ 2 * smallBlind;
                Pot += 3 * smallBlind; //3*small blind
                Sidepot[potNum] += 3 * smallBlind;
                lastSmallBlindId++;
                roundCount++;
                return "success";
            }
            else
                return "mission failed boss we'll get em next time";

        }

        public Card[] Flop() {

            return round.Flop;
        }

        public Card Turn() {
            return round.Turn;
        }

        public Card River() {
            return round.River;
        }

        public JObject Betting(int betSize, string action) {
            if(!Sidepot.Any()) {
                Sidepot.Add(0);
            }
            Sidepot[potNum] += betSize;
            List<Player> newAllInPlayers = players.Where(p => p.IsAllin == true).ToList();
            if(newAllInPlayers.Any()) {
                //Pot += betSize;
                if(newAllInPlayers != AllInPlayers) {
                    Sidepot[potNum] += betSize;
                    newAllInPlayers.ForEach(a => a.CurrentWinnings = potNum);
                    potNum++;
                }
            }
            Pot = Sidepot.Sum();
            AllInPlayers = newAllInPlayers;
            JObject json;
            switch(action) {
                case "Flop":
                    json = JObject.Parse($"{{ \"result\": \"success\", \"data\": {{ \"AllInPlayers\": { JsonConvert.SerializeObject(AllInPlayers)}, \"{action}\": {JsonConvert.SerializeObject(Flop())} }} }}");
                    break;
                case "Turn":
                    json = JObject.Parse($"{{ \"result\": \"success\", \"data\": {{ \"AllInPlayers\": { JsonConvert.SerializeObject(AllInPlayers)}, \"{action}\": {JsonConvert.SerializeObject(Turn())} }} }}");
                    break;
                case "River":
                    json = JObject.Parse($"{{ \"result\": \"success\", \"data\": {{ \"AllInPlayers\": { JsonConvert.SerializeObject(AllInPlayers)}, \"{action}\": {JsonConvert.SerializeObject(River())} }} }}");
                    break;
                default:
                    json = JObject.Parse($"{{ \"result\": \"success\", \"data\": {{ \"AllInPlayers\": { JsonConvert.SerializeObject(AllInPlayers)} }}, \"{action}\": \"Failed. Bad action\" }}");
                    break;
            }
            
            return json;
        }

        public void DetermineWinner() {
            //TBI
        }

    }
}

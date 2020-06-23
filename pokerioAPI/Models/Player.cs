using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokerioAPI.Models {
    public enum BlindTypes {
        None,
        Big,
        Small
    }
    public class Player {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public bool IsAllin { get; set; }
        public int CurrentWinnings { get; set; }
        public bool IsDealer { get; set; }
        public bool IsInGame { get; set; }
        public BlindTypes Blind { get; set; }
        public bool WantsToJoin = false;
    }
}

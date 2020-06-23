using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
        public int Balance = 100;
        public bool IsAllin = false;
        public int CurrentWinnings = 0;
        public bool IsDealer = false;
        public bool IsInGame = false;
        public BlindTypes Blind = 0;
        public bool WantsToJoin = false;
    }
}

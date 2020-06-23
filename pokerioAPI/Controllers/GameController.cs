using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pokerioAPI.Classes;
using pokerioAPI.Models;


namespace pokerioAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly Game _game;
        public GameController(Game game) {
            _game = game;
        }
        // GET: api/Game
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Game
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("startGame/smallBlind={smallBlind}")]
        public string StartGameWithCustomBlind(int smallBlind) {
            return _game.startGame(smallBlind);
           
        }

        [HttpPost("startGame")]
        public string StartGame() {
            return _game.startGame();

        }

        [HttpPost("{action}&betSize={betSize}")]
        public JObject bet(string action, int betSize) {
            return _game.Betting(betSize, action);
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokerDeck.Domain.DTOS;
using PokerDeck.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDeck.Domain
{
    public class PlayerService : IPlayerService
    {
        private const string _randomNameApiUrl = "https://api.namefake.com/english-unitedstates/random";
        public PlayerService()
        {

        }

        public IEnumerable<Player> GeneratePlayers()
        {
            var httpClient = new HttpClient();
            var uri = new Uri(_randomNameApiUrl);
            var players = new List<Player>();

            try
            {
                for(var i = 0; i < 4; i++)
                {
                    var result = httpClient.Send(new HttpRequestMessage() { RequestUri = uri });
                    var jsonResponse = result.Content.ReadAsStringAsync().Result;
                    dynamic content = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                    players.Add(new Player() { Name = content.name });
                }
            }
            catch (Exception ex)
            {
                //Log message and throw 
                throw;
            }

            return players;
        }
    }
}

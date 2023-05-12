using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokerDeck.Domain.DTOS;
using PokerDeck.Domain.Interfaces;
using Sentry.Extensibility;
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
        private HttpClient _httpClient;
        public PlayerService(HttpClient client)
        {
            _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<Player> GeneratePlayers()
        {
            var uri = new Uri(_randomNameApiUrl);
            var players = new List<Player>();

            try
            {
                for(var i = 0; i < 4; i++)
                {
                    var result = _httpClient.SendAsync(new HttpRequestMessage() { RequestUri = uri }).Result;
                    if (!result.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"FakeName Api response code was {result.StatusCode}.");
                        return players;
                    }
                    var jsonResponse = result.Content.ReadAsStringAsync().Result;
                    dynamic content = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                    players.Add(new Player() { Name = content.name });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calling FakeNameApi: {ex.GetBaseException().Message}.");
                return new List<Player>();
            }

            return players;
        }
    }
}

using PokerDeck.Domain;
using System.Linq;
using Xunit;

namespace PokerApp.Domain.IntegrationTests
{
    public class PlayerServiceTests
    {
        [Fact]
        public void GeneratePlayers_Generates4PlayersWithRandomNameAndEmptyCards()
        {
            var expectedNumOfPlayers = 4;
            var playerService = new PlayerService(new System.Net.Http.HttpClient());

            var players = playerService.GeneratePlayers();

            Assert.Equal(expectedNumOfPlayers, players.Count());
            Assert.True(players.All(p => !string.IsNullOrWhiteSpace(p.Name)));
            Assert.True(players.All(p => p.Hand == null));
        }
    }
}
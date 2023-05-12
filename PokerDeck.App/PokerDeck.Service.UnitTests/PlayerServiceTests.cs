using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerDeck.Domain.UnitTests
{
    public class PlayerServiceTests
    {
        [Fact]
        public void GeneratePlayers_Generates4PlayersWithRandomNameAndEmptyCards()
        {
            var playerService = new PlayerService();
            var expectedNumOfPlayers = 4;

            var players = playerService.GeneratePlayers();

            Assert.Equal(expectedNumOfPlayers, players.Count());
            Assert.True(players.All(p => !string.IsNullOrWhiteSpace(p.Name)));
            Assert.False(players.All(p => p.Hand.Any()));
        }
    }
}

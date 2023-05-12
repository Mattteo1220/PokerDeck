using Moq;
using Sentry.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerDeck.Domain.UnitTests
{
    public class DealerServiceTests
    {
        [Fact]
        public void Deal_DealsOutNumberOfCardsFromDeck()
        {
            var dealerService = new DealerService();
            var playerService = new PlayerService(new System.Net.Http.HttpClient());
            var pokerDeckService = new PokerDeckService();
            var deck = pokerDeckService.GenerateDeck();
            var players = playerService.GeneratePlayers();

            dealerService.Deal(deck, players, 5);

            Assert.True(players.All(p => p.Hand.Count() == 5));
        }


    }
}

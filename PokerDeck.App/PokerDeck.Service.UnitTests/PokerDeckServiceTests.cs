
using PokerDeck.Domain;
using System.Linq;
using Xunit;

namespace PokerDeck.Service.UnitTests
{
    public class PokerDeckServiceTests
    {
        [Fact]
        public void GenerateDeck_Creates52PokerCardsWithCorrectSuiteOf13Cards()
        {
            var pokerDeckService = new PokerDeckService();
            var expectedNumOfSuites = 4;
            var expectedNumOfCardsPerSuite = 13;

            var deck = pokerDeckService.GenerateDeck();

            var actualSuites = deck.Suites.Count();
            var actualCardsPerSuite = deck.Suites.Select(s => new {s.CardSuiteType, s.Cards});
            var actualNumOfCardsPerSuite = deck.Suites.Select(s => s.Cards.Count()).ToList();

            Assert.NotNull(deck);
            Assert.Equal(expectedNumOfSuites, actualSuites);

            Assert.Equal(expectedNumOfCardsPerSuite, actualNumOfCardsPerSuite[0]);
            Assert.Equal(expectedNumOfCardsPerSuite, actualNumOfCardsPerSuite[1]);
            Assert.Equal(expectedNumOfCardsPerSuite, actualNumOfCardsPerSuite[2]);
            Assert.Equal(expectedNumOfCardsPerSuite, actualNumOfCardsPerSuite[3]);

            Assert.Contains(actualCardsPerSuite, s => s.CardSuiteType == Domain.Enums.CardSuiteType.Spades);
            Assert.Contains(actualCardsPerSuite, s => s.CardSuiteType == Domain.Enums.CardSuiteType.Hearts);
            Assert.Contains(actualCardsPerSuite, s => s.CardSuiteType == Domain.Enums.CardSuiteType.Clubs);
            Assert.Contains(actualCardsPerSuite, s => s.CardSuiteType == Domain.Enums.CardSuiteType.Diamonds);

            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "2")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "3")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "4")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "5")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "6")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "7")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "8")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "9")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "10")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "King")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "Ace")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "Queen")));
            Assert.True(actualCardsPerSuite.All(s => s.Cards.Any(c => c.CardName == "Jack")));

        }
    }
}
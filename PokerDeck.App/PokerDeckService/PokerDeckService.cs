using PokerDeck.Domain.DTOS;
using PokerDeck.Domain.Enums;

namespace PokerDeck.Domain
{
    public class PokerDeckService : IPokerDeckService
    {
        private const int _numOfSuites = 4;
        public PokerDeckService()
        {

        }

        public Deck GenerateDeck()
        {
            var deck = new Deck();
            var suites = new List<Suite>();
            for (var i = 0; i < _numOfSuites; i++)
            {
                var suite = new Suite();
                suite.CardSuiteType = (CardSuiteType)i;
                var cards = new List<Card>();
                cards.Add(new Card() { CardName = "Ace"});
                cards.Add(new Card() { CardName = "King"});
                cards.Add(new Card() { CardName = "Queen"});
                cards.Add(new Card() { CardName = "Jack"});
                for (var j = 2; j < 11; j++)
                {
                    cards.Add(new Card()
                    {
                        CardName = j.ToString()
                    });
                }
                suite.Cards = cards;
                suites.Add(suite);
            }
            deck.Suites = suites;

            return deck;
        }
    }
}
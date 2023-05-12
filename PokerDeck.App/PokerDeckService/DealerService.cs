using PokerDeck.Domain.DTOS;
using PokerDeck.Domain.Enums;
using PokerDeck.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDeck.Domain
{
    public class DealerService : IDealerService
    {
        public DealerService()
        {

        }

        public void Deal(Deck deck, IEnumerable<Player> players, int numOfCardsToDeal)
        {
            var suites = deck.Suites.ToList();
            var random = new Random();

            foreach(var player in players)
            {
                var hand = new List<(CardSuiteType, string)>();
                for (var i = 0; i < numOfCardsToDeal; i++)
                {
                    var suiteIndex = random.Next(1, 4);
                    var cardIndex = random.Next(1, 13);
                    var suite = suites[suiteIndex];
                    var cards = suite.Cards.ToList();
                    hand.Add((suite.CardSuiteType, cards[cardIndex].CardName));
                }
                player.Hand = hand;
            }
        }
    }
}

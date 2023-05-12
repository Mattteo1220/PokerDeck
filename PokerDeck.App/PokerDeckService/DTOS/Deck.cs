using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDeck.Domain.DTOS
{
    public class Deck
    {
        public int DeckId { get; set; }
        public IEnumerable<Suite> Suites { get; set; }
    }
}

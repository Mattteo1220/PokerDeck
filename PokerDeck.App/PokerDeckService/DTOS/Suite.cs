using PokerDeck.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDeck.Domain.DTOS
{
    public class Suite
    {
        public CardSuiteType CardSuiteType { get; set; }
        public IEnumerable<Card> Cards { get; set; }
    }
}

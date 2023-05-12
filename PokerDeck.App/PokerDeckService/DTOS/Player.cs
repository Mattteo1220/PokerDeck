using PokerDeck.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDeck.Domain.DTOS
{
    public class Player
    {
        public string Name { get; set; }
        public IEnumerable<(CardSuiteType cardSuiteType, string cardName)> Hand { get; set; }
    }
}

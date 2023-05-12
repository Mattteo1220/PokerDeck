using PokerDeck.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDeck.Domain
{
    public interface IPokerDeckService
    {
        Deck GenerateDeck();
    }
}

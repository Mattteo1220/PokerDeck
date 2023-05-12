
using PokerDeck.Domain;

var playerService = new PlayerService();
var pokerDeckService = new PokerDeckService();
var dealerService = new DealerService();

var deck = pokerDeckService.GenerateDeck();
var players = playerService.GeneratePlayers();
dealerService.Deal(deck, players, 5);

Console.WriteLine("Hello, Players!");

foreach(var player in players)
{
    Console.WriteLine();
    Console.WriteLine($"{player.Name} with hand \r\n{string.Join("\r\n", player.Hand.Select(h => $"'{h.cardName}' of '{h.cardSuiteType}',"))}");
    Console.WriteLine();
}

Console.WriteLine("Press any button to exit");
Console.ReadLine();

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokerDeck.Domain;
using PokerDeck.Domain.Interfaces;

var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
    services.AddScoped(typeof(HttpClient));
    services.AddScoped<IDealerService, DealerService>();
    services.AddScoped<IPokerDeckService, PokerDeckService>();
    services.AddScoped<IPlayerService, PlayerService>();
}).Build();

var playerService = host.Services.GetRequiredService<IPlayerService>();
var pokerDeckService = host.Services.GetRequiredService<IPokerDeckService>();
var dealerService = host.Services.GetRequiredService<IDealerService>();

var deck = pokerDeckService.GenerateDeck();
var players = playerService.GeneratePlayers();
if (!players.Any())
{
    Console.WriteLine("bad stuff happened.");
    Console.ReadLine();
}
dealerService.Deal(deck, players, 5);

Console.WriteLine("Hello, Players!");

foreach(var player in players)
{
    Console.WriteLine();
    Console.WriteLine($"{player.Name} with hand \r\n{string.Join("\r\n", player.Hand.Select(h => $"'{h.cardName}' of '{h.cardSuiteType}',"))}");
    Console.WriteLine();
}

Console.ReadLine();
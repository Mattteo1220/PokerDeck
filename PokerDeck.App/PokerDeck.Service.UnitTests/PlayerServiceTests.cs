using Moq;
using Moq.Protected;
using PokerDeck.Domain.DTOS;
using Sentry.Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PokerDeck.Domain.UnitTests
{
    public class PlayerServiceTests
    {
        public class TestScope
        {
            public PlayerService PlayerService;
            public Mock<HttpMessageHandler> mockHttpMessageHandler;
            public Mock<IDiagnosticLogger> MockLogger;
            public TestScope()
            {
                mockHttpMessageHandler = new Mock<HttpMessageHandler>();
                var httpClient = new HttpClient(mockHttpMessageHandler.Object);
                PlayerService = new PlayerService(httpClient);
            }
        }

        [Fact]
        public void Ctor_MissingHttpClient_ThrowsArgumentNullException()
        {
            var scope = new TestScope();
            Assert.Throws<ArgumentNullException>(() => new PlayerService(null));
        }

        [Fact]
        public void GeneratePlayers_ResponseNot200_LogsMessage()
        {
            var scope = new TestScope();
            var expectedErrorMessage = $"FakeName Api response code was BadRequest.\r\n";
            var originalouput = Console.Out;

            scope.mockHttpMessageHandler
                .Protected() // <= here is the trick to set up protected!!!
                .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.BadRequest});

            string actualMessage = null;
            List<Player> players = new List<Player>();
            using (var stringWriter = new StringWriter())
            { 
                Console.SetOut(stringWriter);
                players = (List<Player>)scope.PlayerService.GeneratePlayers();

                stringWriter.Flush();
                actualMessage = stringWriter.GetStringBuilder().ToString();
            }
            Assert.Equal(expectedErrorMessage, actualMessage);
            Assert.False(players.Any());
            Console.SetOut(originalouput);
        }

        [Fact]
        public void GeneratePlayers_ErrorOccurs_ConsoleWritelineCalledWithErrorMessage()
        {
            var scope = new TestScope();
            var expectedErrorMessage = $"An error occurred while calling FakeNameApi: Something bad happened.\r\n";
            var originalouput = Console.Out;
            var exception = new Exception("Something bad happened");

            scope.mockHttpMessageHandler
                .Protected() // <= here is the trick to set up protected!!!
                .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(exception);

            string actualMessage = null;
            List<Player> players = new List<Player>();
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                players = (List<Player>)scope.PlayerService.GeneratePlayers();

                stringWriter.Flush();
                actualMessage = stringWriter.GetStringBuilder().ToString();
            }
            Assert.Equal(expectedErrorMessage, actualMessage);
            Assert.False(players.Any());
            Console.SetOut(originalouput);
        }
    }
}

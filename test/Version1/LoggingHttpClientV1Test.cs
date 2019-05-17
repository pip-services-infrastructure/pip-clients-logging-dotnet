using PipServices.Logging.Client.Version1;
using PipServices3.Commons.Config;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Logging.Client.Test.Version1
{
    public class LoggingHttpClientV1Test : IDisposable
    {
        private static readonly ConfigParams HttpConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
        );

        private LoggingHttpClientV1 _client;
        private LoggingClientFixtureV1 _fixture;

        public LoggingHttpClientV1Test()
        {
            _client = new LoggingHttpClientV1();
            _client.Configure(HttpConfig);

            _fixture = new LoggingClientFixtureV1(_client);
            _client.OpenAsync(null);
        }

        public void Dispose()
        {
            _client.CloseAsync(null).Wait();
        }

        [Fact]
        public async Task TestCrudOperationsAsync()
        {
            await _fixture.TestCrudOperationsAsync();
        }
    }
}

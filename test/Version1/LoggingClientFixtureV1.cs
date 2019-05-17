using PipServices.Logging.Client.Version1;
using PipServices3.Commons.Data;
using PipServices3.Commons.Errors;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Logging.Client.Test.Version1
{
    public class LoggingClientFixtureV1
    {
        private ILoggingClientV1 _client;

        public LoggingClientFixtureV1(ILoggingClientV1 client)
        {
            _client = client;
        }

        public async Task TestCrudOperationsAsync()
        {
            var message = await this._client.WriteMessageAsync(null, new LogMessageV1()
            {
                Time = new DateTime(),
                Source = null,
                Level = LogLevel.Info,
                CorrelationId = "123",
                Error = null,
                Message = "AAA"
            });

            Assert.NotNull(message);

            var message1 = new LogMessageV1()
            {
                Time = new DateTime(),
                Source = null,
                Level = LogLevel.Debug,
                CorrelationId = "123",
                Error = null,
                Message = "BBB"
            };

            var message2 = new LogMessageV1()
            {
                Time = new DateTime(),
                Source = null,
                Level = LogLevel.Error,
                CorrelationId = "123",
                Error = ErrorDescriptionFactory.Create(new Exception()),
                Message = "AAB"
            };
            message2.Time = new DateTime(1975, 1, 1, 0, 0, 0, 0);

            await this._client.WriteMessagesAsync(null, new LogMessageV1[] { message1, message2 });

            var page = await this._client.ReadMessagesAsync(null, FilterParams.FromTuples("search", "AA"), null);
            Assert.Equal(2, page.Data.Count);

            page = await this._client.ReadErrorsAsync(null, null, null);
            Assert.Single(page.Data);
        }
    }
}

using PipServices.Logging.Client.Version1;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using PipServices3.Commons.Errors;
using System;

namespace run
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var correlationId = "123";
                var config = ConfigParams.FromTuples(
                    "connection.type", "http",
                    "connection.host", "localhost",
                    "connection.port", 8080
                );
                var client = new LoggingHttpClientV1();
                client.Configure(config);
                LogMessageV1 message1 = new LogMessageV1()
                {
                    Time = new DateTime(),
                    Source = null,
                    Level = LogLevel.Debug,
                    CorrelationId = "123",
                    Error = null,
                    Message = "BBB"
                };

                LogMessageV1 message2 = new LogMessageV1()
                {
                    Time = new DateTime(),
                    Source = null,
                    Level = LogLevel.Error,
                    CorrelationId = "123",
                    Error = ErrorDescriptionFactory.Create(new Exception()),
                    Message = "AAB"
                };
                client.OpenAsync(correlationId);
                client.WriteMessagesAsync(null, new LogMessageV1[] { message1, message2 });
                var page = client.ReadMessagesAsync(null, FilterParams.FromTuples("search", "AA"), null);
                Console.WriteLine("Read log messages: ");

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();

                client.CloseAsync(string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

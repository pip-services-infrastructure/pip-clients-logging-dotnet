using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using PipServices3.Rpc.Clients;
using System;
using System.Threading.Tasks;

namespace PipServices.Logging.Client.Version1
{
    public class LoggingHttpClientV1 : CommandableHttpClient, ILoggingClientV1
    {
        public LoggingHttpClientV1() : base("v1/logging")
        { }

        public LoggingHttpClientV1(object config) : base("v1/logging")
        {
            if (config != null)
                this.Configure(ConfigParams.FromValue(config));
        }

        public async Task<DataPage<LogMessageV1>> ReadMessagesAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<LogMessageV1>>(
                    "read_messages",
                    correlationId,
                    new
                    {
                        filter = filter,
                        paging = paging
                    }
                    );
            }
        }

        public async Task<DataPage<LogMessageV1>> ReadErrorsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<LogMessageV1>>(
                    "read_errors",
                    correlationId,
                    new
                    {
                        filter = filter,
                        paging = paging
                    }
                    );
            }
        }

        public async Task<LogMessageV1> WriteMessageAsync(string correlationId, LogMessageV1 message)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<LogMessageV1>(
                    "write_message",
                    correlationId,
                    new
                    {
                        message = message
                    }
                    );
            }
        }

        public async Task WriteMessagesAsync(string correlationId, LogMessageV1[] messages)
        {
            using (var timing = Instrument(correlationId))
            {
                await CallCommandAsync<Task>(
                    "write_messages",
                    correlationId,
                    new
                    {
                        messages = messages
                    }
                    );
            }
        }

        public async Task ClearAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                await CallCommandAsync<Task>(
                    "clear",
                    correlationId,
                    new { }
                    );
            }
        }
    }
}

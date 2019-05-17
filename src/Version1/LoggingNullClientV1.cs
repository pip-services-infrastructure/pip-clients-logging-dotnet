using System.Threading.Tasks;
using PipServices3.Commons.Data;

namespace PipServices.Logging.Client.Version1
{
    public class LoggingNullClientV1 : ILoggingClientV1
    {
        public async Task<DataPage<LogMessageV1>> ReadMessagesAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<LogMessageV1>());
        }

        public async Task<DataPage<LogMessageV1>> ReadErrorsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<LogMessageV1>());
        }

        public async Task<LogMessageV1> WriteMessageAsync(string correlationId, LogMessageV1 message)
        {
            return await Task.FromResult(new LogMessageV1());
        }

        public async Task WriteMessagesAsync(string correlationId, LogMessageV1[] messages)
        {
            await Task.Delay(0);
        }

        public async Task ClearAsync(string correlationId)
        {
            await Task.Delay(0);
        }
    }
}

using PipServices3.Commons.Data;
using System.Threading.Tasks;

namespace PipServices.Logging.Client.Version1
{
    public interface ILoggingClientV1
    {
        Task<DataPage<LogMessageV1>> ReadMessagesAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<DataPage<LogMessageV1>> ReadErrorsAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<LogMessageV1> WriteMessageAsync(string correlationId, LogMessageV1 message);
        Task WriteMessagesAsync(string correlationId, LogMessageV1[] messages);
        Task ClearAsync(string correlationId);
    }
}

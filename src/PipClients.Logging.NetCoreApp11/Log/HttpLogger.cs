using PipClients.Logging.Clients;

namespace PipClients.Logging.Log
{
    public class HttpLogger : AbstractLogger
    {
        public HttpLogger() 
            : base(new LoggingHttpClientV1())
        {
        }
    }
}

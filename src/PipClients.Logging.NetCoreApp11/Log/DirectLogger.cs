using PipClients.Logging.Clients;

namespace PipClients.Logging.Log
{
    public class DirectLogger : AbstractLogger
    {
        public DirectLogger() 
            : base(new LoggingDirectClientV1())
        {
        }
    }
}

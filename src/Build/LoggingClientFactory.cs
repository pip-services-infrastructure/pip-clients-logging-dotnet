using PipServices.Logging.Client.Version1;
using PipServices3.Commons.Refer;
using PipServices3.Components.Build;

namespace PipServices.Logging.Client.Build
{
    public class LoggingClientFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services-logging", "factory", "default", "default", "1.0");
        public static Descriptor NullClientDescriptor = new Descriptor("pip-services-logging", "client", "null", "*", "1.0");
        public static Descriptor HttpClientDescriptor = new Descriptor("pip-services-logging", "client", "http", "*", "1.0");

        public LoggingClientFactory()
        {
            RegisterAsType(NullClientDescriptor, typeof(LoggingNullClientV1));
            RegisterAsType(HttpClientDescriptor, typeof(LoggingHttpClientV1));
        }
    }
}

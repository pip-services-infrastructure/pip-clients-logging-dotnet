using PipServices.Commons.Build;
using PipServices.Commons.Refer;

using PipClients.Logging.Clients;

namespace PipClients.Logging.Build
{
    public class LoggingFactory: IFactory
    {
        public object CanCreate(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.LoggingRestClient))
                {
                    return true;
                }

                if (descriptor.Equals(Descriptors.LoggingDirectClient))
                {
                    return true;
                }
            }

            return null;
        }

        public object Create(object locater)
        {
            var descriptor = locater as Descriptor;

            if (descriptor != null)
            {
                if (descriptor.Equals(Descriptors.LoggingRestClient))
                {
                    return new LoggingHttpClientV1();
                }

                if (descriptor.Equals(Descriptors.LoggingDirectClient))
                {
                    return new LoggingDirectClientV1();
                }
            }

            return null;
        }
    }
}

using PipServices3.Commons.Errors;
using System;
using System.Runtime.Serialization;

namespace PipServices.Logging.Client.Version1
{
    [DataContract]
    public class LogMessageV1
    {
        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "correlation_id")]
        public string CorrelationId { get; set; }

        [DataMember(Name = "error")]
        public ErrorDescription Error { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}

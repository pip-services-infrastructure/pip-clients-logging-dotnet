using System;

using PipServices.Commons.Errors;
using PipServices.Commons.Log;
using PipServices.Commons.Data;
using PipServices.Logging.Models;

namespace PipClients.Logging.NetCoreApp11.Test
{
    public class TestModel
    {
        public string CorrelationId { get; set; }

        public LogMessageV1 SampleMessage1 { get; set; }
        public LogMessageV1 SampleMessage2 { get; set; }
        public LogMessageV1 SampleMessage3 { get; set; }

        public LogMessageV1 SampleErrorMessage1 { get; set; }
        public LogMessageV1 SampleErrorMessage2 { get; set; }
        public LogMessageV1 SampleErrorMessage3 { get; set; }

        public DateTime FiveDaysAgo { get; set; }
        public DateTime FourDaysAgo { get; set; }
        public DateTime ThreeDaysAgo { get; set; }
        public DateTime TwoDaysAgo { get; set; }
        public DateTime OneDayAgo { get; set; }

        public FilterParams FilterParams { get; set; }
        public PagingParams PagingParams { get; set; }

        public TestModel()
        {
            CorrelationId = "1";

            FiveDaysAgo = DateTime.UtcNow.AddDays(-5);
            FourDaysAgo = DateTime.UtcNow.AddDays(-4);
            ThreeDaysAgo = DateTime.UtcNow.AddDays(-3);
            TwoDaysAgo = DateTime.UtcNow.AddDays(-2);
            OneDayAgo = DateTime.UtcNow.AddDays(-1);

            SampleMessage1 = new LogMessageV1(FiveDaysAgo, LogLevel.Info, "Persistence", CorrelationId, null, "Test Message #1");
            SampleMessage2 = new LogMessageV1(ThreeDaysAgo, LogLevel.Warn, "Persistence", CorrelationId, null, "Test Message #2");
            SampleMessage3 = new LogMessageV1(OneDayAgo, LogLevel.Debug, "Persistence", CorrelationId, null, "Test Message #3");

            SampleErrorMessage1 = new LogMessageV1(FiveDaysAgo, LogLevel.Error, "Persistence", CorrelationId, new ErrorDescription() { Code = "911" }, "Test Error Message #1");
            SampleErrorMessage2 = new LogMessageV1(ThreeDaysAgo, LogLevel.Fatal, "Persistence", CorrelationId, new ErrorDescription() { }, "Test Error Message #2");
            SampleErrorMessage3 = new LogMessageV1(OneDayAgo, LogLevel.Fatal, "Persistence", CorrelationId, new ErrorDescription() { Cause = "Bad luck" }, "Test Error Message #3");

            FilterParams = new FilterParams();
            PagingParams = new PagingParams();
        }
    }
}

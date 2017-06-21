using PipServices.Commons.Config;
using PipServices.Commons.Log;
using PipServices.Commons.Refer;
using PipServices.Commons.Run;
using PipServices.Commons.Errors;
using PipServices.Logging.Models;

using PipClients.Logging.Clients;

using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net;

namespace PipClients.Logging.Log
{
    public abstract class AbstractLogger : Logger, IReconfigurable, IReferenceable, IOpenable
    {
	    private static readonly int _defaultInterval = 1000;
	
        protected ILoggingClientV1 _client;
        protected List<LogMessageV1> _cache = new List<LogMessageV1>();
        protected int _interval = _defaultInterval;
        protected FixedRateTimer _fixedRateTimer;

        public AbstractLogger(ILoggingClientV1 client)
            :base()
        {
            _client = client;

            _fixedRateTimer = new FixedRateTimer(Dump, _interval, 0);
            _fixedRateTimer.Start();
        }

        public override void Configure(ConfigParams config)
        {
            base.Configure(config);

            (_client as IConfigurable).Configure(config);
            _interval = config.GetAsIntegerWithDefault("interval", _interval);

            _fixedRateTimer.Stop();
            _fixedRateTimer = new FixedRateTimer(Dump, _interval, 0);
            _fixedRateTimer.Start();
        }

        public void SetReferences(IReferences references)
        {
            (_client as IReferenceable).SetReferences(references);
        }

        public bool IsOpened()
        {
            return (_client as IOpenable).IsOpened();
        }

        public Task OpenAsync(string correlationId)
        {
            return (_client as IOpenable).OpenAsync(correlationId);
        }

        public Task CloseAsync(string correlationId)
        {
            return (_client as IClosable).CloseAsync(correlationId);
        }

        public void Clear()
        {
            _cache = new List<LogMessageV1>();
        }

        protected override void Write(LogLevel level, string correlationId, Exception ex, string message)
        {
		    var error = ex != null ? ErrorDescriptionFactory.Create(ex) : null;
            var source = Dns.GetHostName(); // Todo: add current module name name
            var logMessage = new LogMessageV1(level, source, correlationId, error, message);
		
            _cache.Add(logMessage);
        }

        public void Dump()
        {
            if (_cache.Count == 0)
            {
                return;
            }

            _client.WriteMessagesAsync("logger", _cache.ToArray());

            _cache = new List<LogMessageV1>();
        }
    }
}

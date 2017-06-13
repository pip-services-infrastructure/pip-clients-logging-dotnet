﻿using PipServices.Commons.Refer;

namespace PipClients.Logging.Build
{
    public static class Descriptors
    {
        private const string Group = "pip-services-logging";

        public static Descriptor LoggingFactory { get; } = new Descriptor(Group, "factory", "default", "default", "1.0");

        public static Descriptor LoggingRestClient { get; } = new Descriptor(Group, "client", "http", "default", "1.0");

        public static Descriptor LoggingDirectClient { get; } = new Descriptor(Group, "client", "direct", "default", "1.0");

        public static Descriptor LoggingClient { get; } = new Descriptor(Group, "client", "*", "default", "*");
    }
}
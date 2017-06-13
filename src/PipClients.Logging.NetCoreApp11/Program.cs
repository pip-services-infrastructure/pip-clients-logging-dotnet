using System;
using System.Threading;

using PipClients.Logging.Run;

namespace PipClients.Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var task = (new LoggingProcess()).RunAsync(args, CancellationToken.None);
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

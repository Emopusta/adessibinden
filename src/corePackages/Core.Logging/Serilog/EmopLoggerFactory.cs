using Serilog;

namespace Core.Logging.Serilog
{
    public class EmopLoggerFactory : IEmopLoggerFactory
    {
        public IEmopLogger ForContext<TContext>()
        {
            return new EmopLogger(Log.Logger.ForContext(typeof(TContext)));
        }
    }
}

namespace Core.Logging.Serilog;

public interface IEmopLoggerFactory
{

    public IEmopLogger ForContext<TContext>();

}

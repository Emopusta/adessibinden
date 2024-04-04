using Serilog;

namespace Core.Logging.Serilog;

public class EmopLogger : IEmopLogger
{
    private readonly ILogger _logger;

    public EmopLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void Debug(string message)
    {
        _logger?.Debug(message);
    }

    public void Error(string message)
    {
        _logger?.Error(message);
    }

    public void Information(string message)
    {

        _logger?.Information(message);
    }

    public void Verbose(string message)
    {
        _logger?.Verbose(message);
    }

    public void Warning(string message)
    {
        _logger?.Warning(message);
    }
}

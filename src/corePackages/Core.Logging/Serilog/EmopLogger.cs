using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Core.Logging.Serilog;

public class EmopLogger : IEmopLogger
{
    private ILogger _logger;
    private readonly IConfiguration _configuration;

    public EmopLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(_configuration)
            .Enrich.With(new ExampleEnricher())
            .CreateLogger();
    }

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


    public ILogger ForContext<T>()
    {
        string[] filteredLayers = [/*"Core.EventBus"*/]; //Todo: Get these from appsettings

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(_configuration)
            .Enrich.With(new ExampleEnricher())
            .Filter.ByIncludingOnly(logEvent =>
            {
                if (logEvent.Properties.TryGetValue("SourceContext", out LogEventPropertyValue value))
                {
                    var context = value.ToString().Trim('"');

                    foreach (var layer in filteredLayers)
                    {
                        if (context.StartsWith(layer))
                        {
                            return false;
                        }
                    }
                }
                return true;
            })
            .CreateLogger()
            .ForContext(typeof(T));

        return logger;
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

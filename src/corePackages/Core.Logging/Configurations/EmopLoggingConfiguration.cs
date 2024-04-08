namespace Core.Logging.Configurations;

public class EmopLoggingConfiguration
{
    public LoggerFilterConfiguration Filter { get; set; }

    public GrafanaLokiConfiguration GrafanaLoki { get; set; }

}

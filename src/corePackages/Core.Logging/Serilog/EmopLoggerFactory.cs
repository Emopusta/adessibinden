using Core.Logging.Configurations;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;

namespace Core.Logging.Serilog
{
    public class EmopLoggerFactory : IEmopLoggerFactory
    {
        private readonly IConfiguration _configuration;

        public EmopLoggerFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEmopLogger ForContext<TContext>()
        {
            var filteredLayers = _configuration.GetSection("EmopLogging:Filter").Get<LoggerFilterConfiguration>();

            var grafanaLokiConfiguration = _configuration.GetSection("GrafanaLoki").Get<GrafanaLokiConfiguration>();
            var labels = new List<LokiLabel>();

            foreach (var (key, value) in grafanaLokiConfiguration.Labels)
            {
                labels.Add(new LokiLabel { Key = key, Value = value });
            }

            Enum.TryParse(grafanaLokiConfiguration.MinimumLevel, out LogEventLevel level);

            var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(_configuration)
            .WriteTo.GrafanaLoki(grafanaLokiConfiguration.URL, restrictedToMinimumLevel: LogEventLevel.Information, labels: labels)
            .Enrich.With(new ExampleEnricher())
            .Filter.ByIncludingOnly(logEvent =>
            {
                if (logEvent.Properties.TryGetValue("SourceContext", out LogEventPropertyValue value))
                {
                    var context = value.ToString().Trim('"');

                    foreach (var layer in filteredLayers.FilteredLayers)
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
            .ForContext(typeof(TContext));

            return new EmopLogger(logger);
        }
    }
}

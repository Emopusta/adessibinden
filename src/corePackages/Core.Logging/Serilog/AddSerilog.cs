using Core.Logging.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;

namespace Core.Logging.Serilog;

public static class AddSerilog
{
    public static IServiceCollection AddEmopLogger(this IServiceCollection services, IHostBuilder host)
    {

        host.UseSerilog((builderContext, loggerConfiguration) =>
        {
            var emopLoggingConfigurations = builderContext.Configuration.GetSection("EmopLogging").Get<EmopLoggingConfiguration>();

            loggerConfiguration
            .ReadFrom.Configuration(builderContext.Configuration)
            .Enrich.With(new ExampleEnricher());

            ConfigureEmopLogger(emopLoggingConfigurations, loggerConfiguration);
        });
           

        services.AddScoped<IEmopLoggerFactory, EmopLoggerFactory>();

        return services;

    }


    private static void ConfigureEmopLogger(EmopLoggingConfiguration emopLoggingConfiguration,
        LoggerConfiguration loggerConfiguration)
    {
        if (emopLoggingConfiguration!=null)
        {
            ConfigureGrafanaLoki(emopLoggingConfiguration.GrafanaLoki, loggerConfiguration);
            ConfigureLayerFiltering(emopLoggingConfiguration.Filter, loggerConfiguration);
        }
    }

    private static void ConfigureLayerFiltering(LoggerFilterConfiguration loggerFilterConfiguration, LoggerConfiguration loggerConfiguration)
    {
        if (loggerFilterConfiguration!=null)
        {
            loggerConfiguration.Filter.ByIncludingOnly(logEvent =>
             {
                 if (logEvent.Properties.TryGetValue("SourceContext", out LogEventPropertyValue value) && loggerFilterConfiguration.FilteredLayers != null)
                 {
                     var context = value.ToString().Trim('"');

                     foreach (var layer in loggerFilterConfiguration.FilteredLayers)
                     {
                         if (context.StartsWith(layer))
                         {
                             return false;
                         }
                     }
                 }
                 return true;
             });
        }
    }

    private static void ConfigureGrafanaLoki(GrafanaLokiConfiguration grafanaLokiConfiguration, LoggerConfiguration loggerConfiguration)
    {

        if (grafanaLokiConfiguration.Enabled)
        {
            var labels = new List<LokiLabel>();

            foreach (var (key, value) in grafanaLokiConfiguration.Labels)
            {
                labels.Add(new LokiLabel { Key = key, Value = value });
            }

            _ = Enum.TryParse(grafanaLokiConfiguration.MinimumLevel, out LogEventLevel level);

            _ = loggerConfiguration.WriteTo.GrafanaLoki(grafanaLokiConfiguration.URL, restrictedToMinimumLevel: level, labels: labels);
        }
    }
}

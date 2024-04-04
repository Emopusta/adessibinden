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
    public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IHostBuilder host)
    {

        host.UseSerilog((builderContext, loggerConfiguration) =>
        {
            var filteredLayers = builderContext.Configuration.GetSection("EmopLogging:Filter").Get<LoggerFilterConfiguration>();

            loggerConfiguration
            .ReadFrom.Configuration(builderContext.Configuration)
            .Enrich.With(new ExampleEnricher())
            .Filter.ByIncludingOnly(logEvent =>
             {
                 if (logEvent.Properties.TryGetValue("SourceContext", out LogEventPropertyValue value) && filteredLayers!=null)
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
             });

            var grafanaLokiConfiguration = builderContext.Configuration.GetSection("GrafanaLoki").Get<GrafanaLokiConfiguration>() ?? new GrafanaLokiConfiguration { Enabled = false };
            
            if (grafanaLokiConfiguration.Enabled)
            {
                var labels = new List<LokiLabel>();

                foreach (var (key, value) in grafanaLokiConfiguration.Labels)
                {
                    labels.Add(new LokiLabel { Key = key, Value = value });
                }

                _ = Enum.TryParse(grafanaLokiConfiguration.MinimumLevel, out LogEventLevel level);

                _ = loggerConfiguration.WriteTo.GrafanaLoki(grafanaLokiConfiguration.URL, restrictedToMinimumLevel: LogEventLevel.Information, labels: labels);

            }

        });
           

        services.AddScoped<IEmopLoggerFactory, EmopLoggerFactory>();

        return services;

    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Core.Logging.Serilog;

public static class AddSerilog
{
    public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IHostBuilder host)
    {

        host.UseSerilog();

        services.AddScoped<ILogger, SerilogPostgresLogger>();

        return services;

    }
}

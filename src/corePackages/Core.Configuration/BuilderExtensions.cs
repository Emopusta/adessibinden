using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Core.Configuration;

public static class BuilderExtensions
{
    public static IHostBuilder SetInitialConfiguration(this IHostBuilder host, IConfiguration configuration)
    {
        EmopConfiguration.Configuration = configuration;

        return host;
    }
}

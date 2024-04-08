using Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Core.Host;

public static class HostServiceRegistration
{
    public static IHostBuilder SetEmopConfiguration(this IHostBuilder host, IConfiguration configuration)
    {

        EmopConfiguration.Configuration = configuration;

        return host;
    }
}

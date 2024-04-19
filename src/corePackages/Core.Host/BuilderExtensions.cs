using Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Core.Host;

public static class BuilderExtensions
{
    public static IHostBuilder SetEmopConfiguration(this IHostBuilder host, IConfiguration configuration)
    {

        host.SetInitialConfiguration(configuration);

        return host;
    }
}

using Core.Cache.Configurations;
using Core.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Cache.ServiceRegistration;

public static class ServiceRegistration
{

    public static IServiceCollection AddEmopCache(this IServiceCollection services)
    {

        _ = services.Configure<CacheConfiguration>(EmopConfiguration.Configuration.GetSection("CacheConfiguration"));

        //services.AddDistributedMemoryCache();
        services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");

        return services;
    }

}

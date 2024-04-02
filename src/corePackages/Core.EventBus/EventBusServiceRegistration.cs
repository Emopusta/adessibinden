using Core.EventBus.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Core.EventBus
{
    public static class EventBusServiceRegistration
    {

        public static IServiceCollection RegisterEventBusServices(this IServiceCollection services)
        {

            services.AddScoped<ICapAdapter, CapAdapter>();

            return services;
        }

    }
}

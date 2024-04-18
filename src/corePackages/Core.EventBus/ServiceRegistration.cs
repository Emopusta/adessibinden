using Core.EventBus.EmopCap;
using Core.EventBus.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.EventBus
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddEmopCap(this IServiceCollection services)
        {
            services.AddScoped<ICapAdapter, CapAdapter>();

            return services;
        }

        public static IServiceCollection RegisterEmopCapConsumersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var consumers = assembly.DefinedTypes
                .Where(p => p.GetInterfaces()
                .Any(p => p.IsAssignableFrom(typeof(IEmopCapConsumer))) && p.IsClass);

            foreach (var consumer in consumers)
            {
                services.AddScoped(consumer);
            }

            return services;
        }

    }
}

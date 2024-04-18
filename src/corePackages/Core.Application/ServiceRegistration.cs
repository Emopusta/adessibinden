using Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application;

public static class ServiceRegistration
{

    public static IServiceCollection RegisterCustomServicesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var customServices = assembly.DefinedTypes.Where(p => p.GetInterfaces().Any(p => p.IsAssignableFrom(typeof(IServiceBase))) && p.IsInterface).ToList();
        var customManagers = assembly.DefinedTypes.Where(p => p.GetInterfaces().Any(p => p.IsAssignableFrom(typeof(IServiceBase))) && p.IsClass).ToList();

        foreach (var service in customServices)
        {
            var manager = customManagers.FirstOrDefault(p => p.IsAssignableTo(service));
            services.AddScoped(service!, manager);
        }

        return services;
    }
}

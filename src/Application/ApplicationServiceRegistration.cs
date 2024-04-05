using Core.Application.Decorators;
using Core.Application.Pipelines.Cache;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.Application.Services;
using DotNetCore.CAP;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.Loader;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(TransactionBehavior<,>));
            configuration.AddOpenBehavior(typeof(FluentValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(EmopCacheBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddServices();
        
        services.AddCAPSubscribeConsumers();

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.Decorate(typeof(IRequestHandler<,>), typeof(ExampleDecoratorForCommandHandler<,>));

        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
         this IServiceCollection services,
         Assembly assembly,
         Type type,
         Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
     )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {

        var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        var applicationAssembly = Directory.GetFiles(path, "Application.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();

        var customServices = applicationAssembly.DefinedTypes.Where(p => p.GetInterfaces().Any(p => p.IsAssignableFrom(typeof(IServiceBase))) && p.IsInterface).ToList();
        var customManagers = applicationAssembly.DefinedTypes.Where(p => p.GetInterfaces().Any(p => p.IsAssignableFrom(typeof(IServiceBase))) && p.IsClass).ToList();

        foreach (var service in customServices)
        {
            var manager = customManagers.FirstOrDefault(p => p.IsAssignableTo(service));
            services.AddScoped(service!, manager);
        }

        return services;
    }

    private static IServiceCollection AddCAPSubscribeConsumers(this IServiceCollection services)
    {
        var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        var applicationAssembly = Directory.GetFiles(path, "Application.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();

        var customConsumers = applicationAssembly.DefinedTypes.Where(p => p.GetInterfaces().Any(p => p.IsAssignableFrom(typeof(ICapSubscribe))) && p.IsClass).ToList();

        foreach (var consumer in customConsumers)
        {
            services.AddScoped(consumer);
        }

        return services;
    }
}

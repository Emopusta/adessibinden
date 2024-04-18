using Core.Application;
using Core.Application.Decorators;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.Cache.Cache;
using Core.EventBus;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

        services.RegisterCustomServicesFromAssembly(Assembly.GetExecutingAssembly());
        
        services.RegisterEmopCapConsumersFromAssembly(Assembly.GetExecutingAssembly());

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

}

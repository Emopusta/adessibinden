using Application.Services.AuthService;
using Application.Services.ProductService;
using Application.Services.UserFavouriteProductService;
using Application.Services.UserProfileService;
using Application.Services.UsersService;
using Core.Application.Decorators;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.EventBus.RabbitMQ;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
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
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserProfileService, UserProfileManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IUserFavouriteProductService, UserFavouriteProductManager>();


        var rabbitMQFactory = new ConnectionFactory()
        {
            Port = 5672,
            UserName = "guest",
            Password = "guest",
            HostName = "localhost",
            Uri = new("amqp://guest:guest@localhost:5672")
        };

        services.AddSingleton(rabbitMQFactory);

        services.AddScoped<IMessageBroker,  MessageBroker>();

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

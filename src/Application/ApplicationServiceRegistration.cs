using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.UoW;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });


        return services;
    }

   
}

using Core.Application.GenericRepository;
using Core.Application.Pipelines.GenericRepository;
using Core.Application.Rules;
using Core.DataAccess.Entities;
using Core.DataAccess.Repositories;
using DataAccess.Contexts;
using DataAccess.UoW;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AdessibindenContext>(options => 
                options.UseNpgsql(
                    configuration.GetConnectionString("Adessibinden")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<IGenericRepository<Color, Guid>, GenericRepository<Color, Guid>>();
            services.AddScoped<IGenericRepository<CarBrand, Guid>, GenericRepository<CarBrand, Guid>>();



            string domainFullName = "Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Equals(domainFullName)).ToList();
            var interfaceGeneric = AppDomain.CurrentDomain.GetAssemblies()[88].DefinedTypes.ToList()[20];
            var generic = AppDomain.CurrentDomain.GetAssemblies()[30].DefinedTypes.ToList()[13];

            foreach (var loadedAssembly in loadedAssemblies[0].DefinedTypes)
            {
                Type type = loadedAssembly.AsType();
                Type interfaceGenericTypeDefinition = interfaceGeneric.GetGenericTypeDefinition();
                Type genericTypeDefinition = generic.GetGenericTypeDefinition();
                interfaceGenericTypeDefinition.MakeGenericType(type, typeof(Guid));
                genericTypeDefinition.MakeGenericType(type, typeof(Guid));

                services.AddScoped(interfaceGenericTypeDefinition, genericTypeDefinition);

            }

            return services;
        }

 

    }
}

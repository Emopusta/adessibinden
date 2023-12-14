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
using System.Runtime.Loader;

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

            services.RegisterGenericRepositories();



            return services;
        }

    private static IServiceCollection RegisterGenericRepositories(this IServiceCollection services)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var domainAssembly = Directory.GetFiles(path, "Domain.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();
            var coreAssembly = Directory.GetFiles(path, "Core.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();
            var dataAccessAssembly = Directory.GetFiles(path, "DataAccess.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();

            var iGenericRepository = coreAssembly.DefinedTypes.FirstOrDefault(p => p.Name.Equals("IGenericRepository`1"));
            var genericRepository = dataAccessAssembly.DefinedTypes.FirstOrDefault(p => p.Name.Equals("GenericRepository`1"));


            foreach (var domain in domainAssembly.DefinedTypes)
            {
                Type domainEntityType = domain.AsType();
                Type iGenericTypeDefinition = iGenericRepository.GetGenericTypeDefinition();
                Type genericTypeDefinition = genericRepository.GetGenericTypeDefinition();

                iGenericTypeDefinition.MakeGenericType(domainEntityType);
                genericTypeDefinition.MakeGenericType(domainEntityType);

                services.AddScoped(iGenericTypeDefinition, genericTypeDefinition);

            }

            return services;
        }

    }
}

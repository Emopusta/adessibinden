using Core.Application.GenericRepository;
using Core.DataAccess.Repositories;
using DataAccess.Contexts;
using DataAccess.Repositories;
using DataAccess.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.Loader;

namespace DataAccess;

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
        var coreAssembly = Directory.GetFiles(path, "Core.Application.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();
        var dataAccessAssembly = Directory.GetFiles(path, "DataAccess.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();

        if (domainAssembly == null || coreAssembly == null || dataAccessAssembly == null) throw new Exception("Assemblies could not found.");

        var iGenericRepository = coreAssembly.DefinedTypes.FirstOrDefault(p => p.AsType() == typeof(IGenericRepository<>));
        var genericRepository = dataAccessAssembly.DefinedTypes.FirstOrDefault(p => p.AsType() == typeof(GenericRepository<>));

        if (iGenericRepository == null || genericRepository == null) throw new Exception("GenericRepository Assemblies could not found.");

        foreach (var domain in domainAssembly.DefinedTypes)
        {
            var domainEntityType = domain.AsType();
            
            if (domainEntityType == null) { continue; }

            iGenericRepository.MakeGenericType(domainEntityType);
            genericRepository.MakeGenericType(domainEntityType);

            services.AddScoped(iGenericRepository, genericRepository);
        }
        return services;
    }
}

public class DbContextDesignFactory : IDesignTimeDbContextFactory<AdessibindenContext>
{
    public AdessibindenContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        var optionsBuilder = new DbContextOptionsBuilder<AdessibindenContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("Adessibinden"));
        return new AdessibindenContext(optionsBuilder.Options);
    }
}

using Core.Application.GenericRepository;
using Core.DataAccess.Repositories;
using Core.DataAccess.UoW;
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

        services.AddScoped<IUnitOfWork, UnitOfWork<AdessibindenContext>>();

        services.RegisterCustomRepositories();

        services.AddCap(options =>
        {
            options.UseEntityFramework<AdessibindenContext>();
            options.UsePostgreSql(configuration.GetConnectionString("Adessibinden"));
            options.UseDashboard(path => path.PathMatch = "/cap-dashboard");
            options.UseRabbitMQ(options =>
            {
                options.ConnectionFactoryOptions = options =>
                {
                    options.Ssl.Enabled = false;
                    options.HostName = "localhost";
                    options.UserName = "guest";
                    options.Password = "guest";
                    options.Port = 5672;
                    options.Uri = new("amqp://guest:guest@localhost:5672");
                };
            });
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
    
private static IServiceCollection RegisterCustomRepositories(this IServiceCollection services)
    {
        var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        var applicationAssembly = Directory.GetFiles(path, "Application.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();
        var dataAccessAssembly = Directory.GetFiles(path, "DataAccess.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();

        if (applicationAssembly == null || dataAccessAssembly == null) throw new Exception("Assemblies could not found.");

        var iRepositories = applicationAssembly.DefinedTypes.Where(p => p.GetInterfaces().Any(p => p.IsAssignableFrom(typeof(IBaseCustomRepository)))).ToList();
        var repositories = dataAccessAssembly.DefinedTypes.Where(p => p.GetInterfaces().Any(p => p.IsAssignableFrom(typeof(IBaseCustomRepository)))).ToList();

        int oneToOneCondition = 1;
        int notImplementedCondition = 0;
        foreach (var iRepository in iRepositories)
        {
            var assignableCounter = repositories.Count(p => p.IsAssignableTo(iRepository));
            if (assignableCounter > oneToOneCondition) throw new Exception("Repository interfaces and concretes must be one-to-one. You can not implement a Repository Interface to multiple concrete Repositories.");
            if (assignableCounter == notImplementedCondition) throw new Exception($" \"{iRepository.Name}\" not implemented to its concrete.");
        }

        if (iRepositories.Count != repositories.Count) throw new Exception($"Total number of Custom Repository Interfaces and Concretes must be equal. \"{nameof(IBaseCustomRepository)}\" must implemented to custom repository interface not to concrete.");

        foreach (var repository in repositories)
        {
            var iRepository = iRepositories.FirstOrDefault(p => p.IsAssignableFrom(repository));
            services.AddScoped(iRepository!, repository);
        }

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

using Application.Services.Repositories;
using Core.DataAccess.Repositories;
using DataAccess.Contexts;
using DataAccess.Repositories;
using DataAccess.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddScoped<IColorRepository, ColorRepository>();

            return services;
        }
    }
}

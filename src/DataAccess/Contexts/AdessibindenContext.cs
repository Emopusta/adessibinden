using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Loader;
using Core.CrossCuttingConcerns.Interceptors;
using Core.DataAccess.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts;

public class AdessibindenContext : DbContext
{
    public DbSet<CarBrand> CarBrands { get; set; }

    public DbSet<CarChassisType> CarChassisTypes { get; set; }

    public DbSet<CarFuelType> CarFuelTypes { get; set; }

    public DbSet<CarModel> CarModels { get; set; }

    public DbSet<CarProduct> CarProducts { get; set; }

    public DbSet<CarProductCategory> CarProductCategories { get; set; }

    public DbSet<Color> Colors { get; set; }

    public DbSet<ComputerBrand> ComputerBrands { get; set; }

    public DbSet<ComputerOperatingSystem> ComputerOperatingSystems { get; set; }

    public DbSet<ComputerProcessor> ComputerProcessors { get; set; }

    public DbSet<ComputerProduct> ComputerProducts { get; set; }

    public DbSet<ComputerRAM> ComputerRams { get; set; }

    public DbSet<ComputerSSDCapacity> ComputerSsdcapacities { get; set; }

    public DbSet<ComputerVideoCard> ComputerVideoCards { get; set; }

    public DbSet<PhoneBrand> PhoneBrands { get; set; }

    public DbSet<PhoneInternalMemory> PhoneInternalMemories { get; set; }

    public DbSet<PhoneModel> PhoneModels { get; set; }

    public DbSet<PhoneProduct> PhoneProducts { get; set; }

    public DbSet<PhoneRAM> PhoneRams { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserFavouriteProduct> UserFavouriteProducts { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public AdessibindenContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        AddGlobalSoftDeleteFilter(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
        .AddInterceptors(new LoggingInterceptor());

    private static void AddGlobalSoftDeleteFilter(ModelBuilder modelBuilder)
    {
        Expression<Func<BaseEntity, bool>> softDeleteGlobalFilterExpression = x => !x.DeletedDate.HasValue;

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (entity.ClrType.IsAssignableTo(typeof(BaseEntity)))
            {
            var parameter = Expression.Parameter(entity.ClrType);
            var body = ReplacingExpressionVisitor.Replace(softDeleteGlobalFilterExpression.Parameters.First(), parameter, softDeleteGlobalFilterExpression.Body);
            var lambdaExpression = Expression.Lambda(body, parameter);

            entity.SetQueryFilter(lambdaExpression);
            }
        }

      
    }
}

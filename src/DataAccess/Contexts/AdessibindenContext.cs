using System.Reflection;
using Core.CrossCuttingConcerns.Interceptors;
using Core.DataAccess.ModelBuilderExtensions;
using Core.Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

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

    public AdessibindenContext(DbContextOptions<AdessibindenContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.AddTimestampsToEntities();

        modelBuilder.AddGlobalFilterWithExpression<Entity>(expression: e => !e.DeletedDate.HasValue);
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var entities = ChangeTracker.Entries<Entity>();

        foreach (var entity in entities)
        {
            _ = entity.State switch
            {
                EntityState.Added => entity.Entity.CreatedDate = now,
                EntityState.Modified => entity.Entity.UpdatedDate = now,
                EntityState.Deleted => entity.Entity.DeletedDate = now,
                _ => now
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
        .AddInterceptors(new LoggingInterceptor()); 
}

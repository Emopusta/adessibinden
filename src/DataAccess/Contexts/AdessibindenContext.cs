using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts;

public class AdessibindenContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
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
    public AdessibindenContext(DbContextOptions options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}

using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.DataAccess.ModelBuilderExtensions;

public static class GlobalEntityConfigurationExtensions
{
    public static ModelBuilder AddTimestampsToEntities(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedDate").IsRequired();
                modelBuilder.Entity(entityType.ClrType).Property<DateTime?>("UpdatedDate");
                modelBuilder.Entity(entityType.ClrType).Property<DateTime?>("DeletedDate");
            }
        }
        return modelBuilder;
    }

    public static ModelBuilder AddPropertiesToEntitiesDerivedFrom<TBaseEntity>(this ModelBuilder modelBuilder, Action<IMutableEntityType> action) 
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(TBaseEntity) == entityType.ClrType.BaseType)
            {
                action(entityType);
            }
        }
        return modelBuilder;
    }
}

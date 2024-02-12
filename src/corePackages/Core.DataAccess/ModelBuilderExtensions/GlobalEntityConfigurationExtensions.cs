using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.ModelBuilderExtensions;

public static class GlobalEntityConfigurationExtensions
{
    public static ModelBuilder AddTimestampsToEntity(this ModelBuilder modelBuilder)
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
}

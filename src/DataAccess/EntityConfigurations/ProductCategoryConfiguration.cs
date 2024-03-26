using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("productCategories").HasKey(e => e.Id);

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<ProductCategory> GetSeeds()
    {
        var data = new List<ProductCategory>
    {
        new() { Id = 1, Name = "Phone" }
    };
        return data;
    }
}


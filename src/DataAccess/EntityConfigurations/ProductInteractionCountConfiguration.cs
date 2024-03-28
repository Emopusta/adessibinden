using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductInteractionCountConfiguration : IEntityTypeConfiguration<ProductInteractionCount>
{
    public void Configure(EntityTypeBuilder<ProductInteractionCount> builder)
    {
        builder.ToTable("productInteractionCounts").HasKey(e => e.Id);

        builder.Property(e => e.ProductId).HasColumnType("integer").HasColumnName("ProductId").IsRequired();
        builder.Property(e => e.Count).HasColumnType("integer").HasColumnName("Count").IsRequired();

        builder.HasOne(e => e.Product).WithOne(e => e.ProductInteractionCount);
    }

}

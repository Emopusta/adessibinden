using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.CreatorUserId).HasColumnName("CreatorUserId").IsRequired();
        builder.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryId").IsRequired();
        builder.Property(e => e.Description).HasColumnType("character varying").HasColumnName("Description");
        builder.Property(e => e.Title).HasColumnType("character varying").HasColumnName("Title");

        builder.HasOne(d => d.CreatorUser).WithMany(p => p.Products)
            .HasForeignKey(d => d.CreatorUserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Product_CreatorUserId_fkey");

        builder.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
            .HasForeignKey(d => d.ProductCategoryId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("ProductCategories_fkey");
    }
}

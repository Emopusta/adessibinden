using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CarProductConfiguration : IEntityTypeConfiguration<CarProduct>
{
    public void Configure(EntityTypeBuilder<CarProduct> builder)
    {

        builder.ToTable("carProducts").HasKey(e => e.Id);

        builder.Property(e => e.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(e => e.CarProductCategoryId).HasColumnName("CarProductCategoryId").IsRequired();
        builder.Property(e => e.ChassisTypeId).HasColumnName("ChassisTypeId").IsRequired();
        builder.Property(e => e.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(e => e.FuelTypeId).HasColumnName("FuelTypeId").IsRequired();
        builder.Property(e => e.ModelId).HasColumnName("ModelId").IsRequired();

        builder.HasOne(d => d.CarProductCategory).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.CarProductCategoryId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("CarProductCategoryId_fkey");

        builder.HasOne(d => d.ChassisType).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.ChassisTypeId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("ChassisTypeId");

        builder.HasOne(d => d.Color).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("ColorId_fkey");

        builder.HasOne(d => d.FuelType).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.FuelTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FuelTypeId");

        builder.HasOne(d => d.Model).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("ModelId");

        builder.HasOne(d => d.Product).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("ProductId_fkey");
    }
}

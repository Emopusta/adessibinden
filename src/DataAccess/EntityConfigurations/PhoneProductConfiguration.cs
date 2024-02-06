using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PhoneProductConfiguration : IEntityTypeConfiguration<PhoneProduct>
{
    public void Configure(EntityTypeBuilder<PhoneProduct> builder)
    {
        builder.ToTable("phoneProducts").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(e => e.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(e => e.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(e => e.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(e => e.InternalMemoryId).HasColumnName("InternalMemoryId").IsRequired();
        builder.Property(e => e.RAMId).HasColumnName("RAMId").IsRequired();
        builder.Property(e => e.UsageStatus).HasColumnName("UsageStatus").IsRequired();
        builder.Property(e => e.Price).HasColumnType("money").HasColumnName("Price").IsRequired();
        
        builder.HasOne(d => d.Color).WithMany(p => p.PhoneProducts)
            .HasForeignKey(d => d.ColorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ColorId_fkey");

        builder.HasOne(d => d.InternalMemory).WithMany(p => p.PhoneProducts)
            .HasForeignKey(d => d.InternalMemoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("InternalMemoryId_fkey");

        builder.HasOne(d => d.Model).WithMany(p => p.PhoneProducts)
            .HasForeignKey(d => d.ModelId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ModelId_fkey");

        builder.HasOne(d => d.Product).WithMany(p => p.PhoneProducts)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ProductId_fkey");

        builder.HasOne(d => d.RAM).WithMany(p => p.PhoneProducts)
            .HasForeignKey(d => d.RAMId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("RAMId_fkey");
    }
}

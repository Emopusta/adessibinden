using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ComputerProductConfiguration : IEntityTypeConfiguration<ComputerProduct>
{
    public void Configure(EntityTypeBuilder<ComputerProduct> builder)
    {
        builder.ToTable("computerProducts").HasKey(e => e.Id);

        builder.Property(e => e.RAMId).HasColumnName("RAMId").IsRequired();
        builder.Property(e => e.SSDCapacityId).HasColumnName("SSDCapacityId").IsRequired();
        builder.Property(e => e.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(e => e.OperatingSystemId).HasColumnName("OperatingSystemId").IsRequired();
        builder.Property(e => e.ProcessorId).HasColumnName("ProcessorId").IsRequired();
        builder.Property(e => e.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(e => e.VideoCardId).HasColumnName("VideoCardId").IsRequired();

        builder.HasOne(d => d.Brand).WithMany(p => p.ComputerProducts)
            .HasForeignKey(d => d.BrandId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("BrandId_fkey");

        builder.HasOne(d => d.OperatingSystem).WithMany(p => p.ComputerProducts)
            .HasForeignKey(d => d.OperatingSystemId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("OperatingSystemId_fkey");

        builder.HasOne(d => d.Processor).WithMany(p => p.ComputerProducts)
            .HasForeignKey(d => d.ProcessorId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("ProcessorId_fkey");

        builder.HasOne(d => d.Product).WithMany(p => p.ComputerProducts)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("ProductId_fkey");

        builder.HasOne(d => d.RAM).WithMany(p => p.ComputerProducts)
            .HasForeignKey(d => d.RAMId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("RAMId_fkey");

        builder.HasOne(d => d.SSDCapacity).WithMany(p => p.ComputerProducts)
            .HasForeignKey(d => d.SSDCapacityId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("SSDCapacityId_fkey");

        builder.HasOne(d => d.VideoCard).WithMany(p => p.ComputerProducts)
            .HasForeignKey(d => d.VideoCardId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("VideoCardId_fkey");
    }
}

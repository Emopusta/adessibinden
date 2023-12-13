using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class CarProductConfiguration : IEntityTypeConfiguration<CarProduct>
    {
        public void Configure(EntityTypeBuilder<CarProduct> builder)
        {

            builder.ToTable("carProducts").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

            builder.Property(e => e.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(e => e.CarProductCategoryId).HasColumnName("CarProductCategoryId").IsRequired();
            builder.Property(e => e.ChassisTypeId).HasColumnName("ChassisTypeId").IsRequired();
            builder.Property(e => e.ColorId).HasColumnName("ColorId").IsRequired();
            builder.Property(e => e.FuelTypeId).HasColumnName("FuelTypeId").IsRequired();
            builder.Property(e => e.ModelId).HasColumnName("ModelId").IsRequired();


            builder.HasOne(d => d.CarProductCategory).WithMany(p => p.CarProducts)
                    .HasForeignKey(d => d.CarProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CarProductCategoryId_fkey");

            builder.HasOne(d => d.ChassisType).WithMany(p => p.CarProducts)
                    .HasForeignKey(d => d.ChassisTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChassisTypeId");

            builder.HasOne(d => d.Color).WithMany(p => p.CarProducts)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ColorId_fkey");

            builder.HasOne(d => d.FuelType).WithMany(p => p.CarProducts)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FuelTypeId");

            builder.HasOne(d => d.Model).WithMany(p => p.CarProducts)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ModelId");

            builder.HasOne(d => d.Product).WithMany(p => p.CarProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductId_fkey");
            
        }
    }
}

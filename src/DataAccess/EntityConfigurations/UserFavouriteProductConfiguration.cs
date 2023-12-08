using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UserFavouriteProductConfiguration : IEntityTypeConfiguration<UserFavouriteProduct>
    {
        public void Configure(EntityTypeBuilder<UserFavouriteProduct> builder)
        {
            builder.ToTable("UserFavouriteProducts").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(e => e.UserId).HasColumnName("UserId").IsRequired();

            builder.HasOne(d => d.Product).WithMany(p => p.UserFavouriteProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProductId_fkey");

            builder.HasOne(d => d.User).WithMany(p => p.UserFavouriteProducts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserId_fkey");
        }
    }
}

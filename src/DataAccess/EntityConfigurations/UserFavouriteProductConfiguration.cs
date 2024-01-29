using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class UserFavouriteProductConfiguration : IEntityTypeConfiguration<UserFavouriteProduct>
    {
        public void Configure(EntityTypeBuilder<UserFavouriteProduct> builder)
        {
            builder.ToTable("userFavouriteProducts").HasKey(e => new {e.UserId, e.ProductId});
 
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

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CarProductCategoryConfiguration : IEntityTypeConfiguration<CarProductCategory>
{
    public void Configure(EntityTypeBuilder<CarProductCategory> builder)
    {
        builder.ToTable("carProductCategories").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
    }
}

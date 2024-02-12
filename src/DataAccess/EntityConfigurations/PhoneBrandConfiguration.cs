using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PhoneBrandConfiguration : IEntityTypeConfiguration<PhoneBrand>
{
    public void Configure(EntityTypeBuilder<PhoneBrand> builder)
    {
        builder.ToTable("phoneBrands").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
    }
}

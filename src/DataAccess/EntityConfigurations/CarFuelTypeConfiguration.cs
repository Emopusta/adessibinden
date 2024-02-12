using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CarFuelTypeConfiguration : IEntityTypeConfiguration<CarFuelType>
{
    public void Configure(EntityTypeBuilder<CarFuelType> builder)
    {
        builder.ToTable("carFuelTypes").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
    }
}

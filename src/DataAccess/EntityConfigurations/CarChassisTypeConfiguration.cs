using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace DataAccess.EntityConfigurations;

public class CarChassisTypeConfiguration : IEntityTypeConfiguration<CarChassisType>
{
    public void Configure(EntityTypeBuilder<CarChassisType> builder)
    {
        builder.ToTable("carChassisTypes").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ComputerSSDCapacityConfiguration : IEntityTypeConfiguration<ComputerSSDCapacity>
{
    public void Configure(EntityTypeBuilder<ComputerSSDCapacity> builder)
    {
        builder.ToTable("computerSSDCapacities").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Capacity).HasColumnType("character varying").HasColumnName("Capacity").IsRequired();
    }
}

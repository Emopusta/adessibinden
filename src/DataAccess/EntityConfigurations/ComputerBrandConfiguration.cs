using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ComputerBrandConfiguration : IEntityTypeConfiguration<ComputerBrand>
{
    public void Configure(EntityTypeBuilder<ComputerBrand> builder)
    {
        builder.ToTable("computerBrands").HasKey(e => e.Id);

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name");
    }
}

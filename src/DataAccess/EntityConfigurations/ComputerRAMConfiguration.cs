using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ComputerRAMConfiguration : IEntityTypeConfiguration<ComputerRAM>
{
    public void Configure(EntityTypeBuilder<ComputerRAM> builder)
    {
        builder.ToTable("computerRAMs").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Memory).HasColumnType("character varying").HasColumnName("Memory").IsRequired();
    }
}

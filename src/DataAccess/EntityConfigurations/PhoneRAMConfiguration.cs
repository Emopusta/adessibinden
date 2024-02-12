using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PhoneRAMConfiguration : IEntityTypeConfiguration<PhoneRAM>
{
    public void Configure(EntityTypeBuilder<PhoneRAM> builder)
    {
        builder.ToTable("phoneRAMs").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Memory).HasColumnType("character varying").HasColumnName("Memory").IsRequired();
    }
}

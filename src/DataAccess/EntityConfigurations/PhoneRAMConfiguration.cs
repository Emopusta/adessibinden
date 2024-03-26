using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PhoneRAMConfiguration : IEntityTypeConfiguration<PhoneRAM>
{
    public void Configure(EntityTypeBuilder<PhoneRAM> builder)
    {
        builder.ToTable("phoneRAMs").HasKey(e => e.Id);

        builder.Property(e => e.Memory).HasColumnType("character varying").HasColumnName("Memory").IsRequired();

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<PhoneRAM> GetSeeds()
    {
        var data = new List<PhoneRAM>
    {
        new() { Id = 1, Memory = "1 Gb" },
        new() { Id = 2, Memory = "512 Kb" }
    };
        return data;
    }
}

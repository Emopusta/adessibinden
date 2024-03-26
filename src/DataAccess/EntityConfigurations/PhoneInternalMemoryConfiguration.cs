using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PhoneInternalMemoryConfiguration : IEntityTypeConfiguration<PhoneInternalMemory>
{
    public void Configure(EntityTypeBuilder<PhoneInternalMemory> builder)
    {
        builder.ToTable("phoneInternalMemories").HasKey(e => e.Id);

        builder.Property(e => e.Capacity).HasColumnType("character varying").HasColumnName("Capacity").IsRequired();

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<PhoneInternalMemory> GetSeeds()
    {
        var data = new List<PhoneInternalMemory>
        {
            new() { Id = 1, Capacity = "64 Gb" },
            new() { Id = 2, Capacity = "128 Gb" },
            new() { Id = 3, Capacity = "256 Gb" },
            new() { Id = 4, Capacity = "512 Gb" }
        };
        return data;
    }
}

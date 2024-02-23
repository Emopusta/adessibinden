using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("colors").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name");
        builder.HasIndex(e => e.Name).IsUnique();

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<Color> GetSeeds()
    {
        var colors = new List<Color>
        {
            new() { Id = 1, Name = "Red" },
            new() { Id = 2, Name = "Green" },
            new() { Id = 3, Name = "Yellow" },
            new() { Id = 4, Name = "Blue" }
        };
        return colors;
    }
}

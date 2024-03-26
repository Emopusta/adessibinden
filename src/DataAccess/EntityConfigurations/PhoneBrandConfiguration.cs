using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PhoneBrandConfiguration : IEntityTypeConfiguration<PhoneBrand>
{
    public void Configure(EntityTypeBuilder<PhoneBrand> builder)
    {
        builder.ToTable("phoneBrands").HasKey(e => e.Id);

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<PhoneBrand> GetSeeds()
    {
        var data = new List<PhoneBrand>
    {
        new() { Id = 1, Name = "Apple" },
        new() { Id = 2, Name = "Samsung" }
    };
        return data;
    }
}

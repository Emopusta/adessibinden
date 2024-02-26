using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PhoneModelConfiguration : IEntityTypeConfiguration<PhoneModel>
{
    public void Configure(EntityTypeBuilder<PhoneModel> builder)
    {
        builder.ToTable("phoneModels").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
        builder.Property(e => e.BrandId).HasColumnName("BrandId").IsRequired();

        builder.HasOne(d => d.Brand).WithMany(p => p.PhoneModels)
            .HasForeignKey(d => d.BrandId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("BrandId_fkey");

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<PhoneModel> GetSeeds()
    {
        var data = new List<PhoneModel>
        {
            new() { Id = 1, Name = "Iphone 11" , BrandId = 1},
            new() { Id = 2, Name = "Iphone 12" , BrandId = 1},
            new() { Id = 3, Name = "Iphone 13" , BrandId = 1},
            new() { Id = 4, Name = "Iphone 14" , BrandId = 1},
            new() { Id = 5, Name = "Galaxy Note 4" , BrandId = 2},
            new() { Id = 6, Name = "Galaxy Note 5" , BrandId = 2},
            new() { Id = 7, Name = "Galaxy Note 6" , BrandId = 2},
        };
        return data;
    }
}

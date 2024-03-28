using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class InteractionCountConfiguration : IEntityTypeConfiguration<InteractionCount>
{
    public void Configure(EntityTypeBuilder<InteractionCount> builder)
    {
        builder.ToTable("interactionCounts").HasKey(e => e.Id);

        builder.Property(e => e.Count).HasColumnType("integer").HasColumnName("Count");
        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name");
        builder.HasIndex(e => e.Name).IsUnique();

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<InteractionCount> GetSeeds()
    {
        var interactionCounts = new List<InteractionCount>
        {
            new() { Id = 1, Name = "phone_product_details_queue_cap" , Count = 0 },   
        };
        return interactionCounts;
    }
}

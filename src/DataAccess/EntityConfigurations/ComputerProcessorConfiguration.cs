using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ComputerProcessorConfiguration : IEntityTypeConfiguration<ComputerProcessor>
{
    public void Configure(EntityTypeBuilder<ComputerProcessor> builder)
    {
        builder.ToTable("computerProcessors").HasKey(e => e.Id);

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
    }
}

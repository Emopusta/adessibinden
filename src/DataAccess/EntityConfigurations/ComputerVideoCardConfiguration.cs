using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ComputerVideoCardConfiguration : IEntityTypeConfiguration<ComputerVideoCard>
{
    public void Configure(EntityTypeBuilder<ComputerVideoCard> builder)
    {
        builder.ToTable("computerVideoCards").HasKey(e => e.Id);

        builder.Property(e => e.Memory).HasColumnType("character varying").HasColumnName("Memory").IsRequired();
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ComputerOperatingSystemConfiguration : IEntityTypeConfiguration<ComputerOperatingSystem>
    {
        public void Configure(EntityTypeBuilder<ComputerOperatingSystem> builder)
        {
            builder.ToTable("computerOperatingSystems").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
        }
    }
}

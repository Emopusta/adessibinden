using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {

            builder.ToTable("colors").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

            builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name");
            builder.HasIndex(e => e.Name).IsUnique();

            builder.HasData(GetSeeds());
        }


        private IEnumerable<Color> GetSeeds()
        {
            var colors = new List<Color>();

            colors.Add(new Color() { Id = 1, Name = "Red" });
            colors.Add(new Color() { Id = 2, Name = "Green" });
            colors.Add(new Color() { Id = 3, Name = "Yellow" });
            colors.Add(new Color() { Id = 4, Name = "Blue" });

            return colors;
        }
    }
}

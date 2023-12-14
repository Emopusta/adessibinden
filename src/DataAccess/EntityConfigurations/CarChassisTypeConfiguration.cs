using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class CarChassisTypeConfiguration : IEntityTypeConfiguration<CarChassisType>
    {
        public void Configure(EntityTypeBuilder<CarChassisType> builder)
        {
            builder.ToTable("carChassisTypes").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

            builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
         
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class PhoneInternalMemoryConfiguration : IEntityTypeConfiguration<PhoneInternalMemory>
    {
        public void Configure(EntityTypeBuilder<PhoneInternalMemory> builder)
        {
            builder.ToTable("phoneInternalMemories").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(e => e.Capacity).HasColumnType("character varying").HasColumnName("Capacity").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}

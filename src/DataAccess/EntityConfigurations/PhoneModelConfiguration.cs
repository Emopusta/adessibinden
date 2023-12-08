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
    public class PhoneModelConfiguration : IEntityTypeConfiguration<PhoneModel>
    {
        public void Configure(EntityTypeBuilder<PhoneModel> builder)
        {
            builder.ToTable("PhoneModels").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
            
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();
            builder.Property(e => e.BrandId).HasColumnName("BrandId").IsRequired();

            builder.HasOne(d => d.Brand).WithMany(p => p.PhoneModels)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BrandId_fkey");
                }
    }
}

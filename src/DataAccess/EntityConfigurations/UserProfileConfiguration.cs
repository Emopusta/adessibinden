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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("userProfiles").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Address).HasColumnType("character varying").HasColumnName("Address");
            builder.Property(e => e.FirstName).HasColumnType("character varying").HasColumnName("FirstName").IsRequired();
            builder.Property(e => e.LastName).HasColumnType("character varying").HasColumnName("LastName").IsRequired();

            builder.Property(e => e.BirthDate).HasColumnName("BirthDate");
            builder.Property(e => e.UserId).HasColumnName("UserId").IsRequired();

            builder.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserId");
        }
    }
}

﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("userProfiles").HasKey(e => e.Id);

        builder.Property(e => e.Address).HasColumnType("character varying").HasColumnName("Address");
        builder.Property(e => e.FirstName).HasColumnType("character varying").HasColumnName("FirstName");
        builder.Property(e => e.LastName).HasColumnType("character varying").HasColumnName("LastName");

        builder.Property(e => e.BirthDate).HasColumnName("BirthDate");
        builder.Property(e => e.UserId).HasColumnName("UserId").IsRequired();

        builder.HasOne(d => d.User).WithMany(p => p.UserProfiles)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("UserId");
    }
}

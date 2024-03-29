﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("carModels").HasKey(e => e.Id);

        builder.Property(e => e.BrandId).HasColumnName("BrandId");

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name").IsRequired();

        builder.HasOne(d => d.Brand).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("BrandId_fkey");
    }
}

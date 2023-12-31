﻿using Core.Security.Hashing;
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(e => e.Email).HasColumnType("character varying").HasColumnName("Email").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnType("character varying").HasColumnName("PasswordSalt").IsRequired();
            builder.Property(e => e.PasswordHash).HasColumnType("character varying").HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);


            builder.HasMany(u => u.UserOperationClaims);
            builder.HasMany(u => u.RefreshTokens);

            builder.HasData(getSeeds());
        }

        private IEnumerable<User> getSeeds()
        {
            List<User> users = new();

            HashingHelper.CreatePasswordHash(
                password: "Passw0rd",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User adminUser =
                new()
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Status = true,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
            users.Add(adminUser);

            return users.ToArray();
        }
    }
}
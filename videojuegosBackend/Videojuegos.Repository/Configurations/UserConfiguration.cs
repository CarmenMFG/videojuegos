using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(us => us.Id)
                .HasName("PK_User");

            builder.Property(us => us.Id)
                .HasColumnName("id");

            builder.Property(us => us.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(us => us.User)
               .HasColumnName("user")
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(us => us.Password)
               .HasColumnName("password")
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(us => us.IdRol)
              .HasColumnName("idrol")
              .IsRequired()
              .HasColumnType("int");

            builder.HasOne(us => us.Rol)
            .WithMany(r => r.Users)
            .HasForeignKey(r => r.IdRol);
        }
    }
}

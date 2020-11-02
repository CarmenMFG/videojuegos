using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Configurations
{
    public class VideoGameConfiguration : IEntityTypeConfiguration<VideoGameEntity>
    {
        public void Configure(EntityTypeBuilder<VideoGameEntity> builder)
        {
            builder.ToTable("VIDEOGAME");

            builder.HasKey(vg => vg.Id)
                .HasName("PK_Videogames");

            builder.Property(vg => vg.Id)
                .HasColumnName("id");

            builder.Property(vg => vg.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(vg => vg.CoverPage)
                .HasColumnName("coverpage")
                .HasColumnType("image");

            builder.Property(vg => vg.BackCover)
                .HasColumnName("backcover")
                .HasColumnType("image");

            builder.Property(vg => vg.ReleaseDate)
                .HasColumnName("releasedate")
                .HasColumnType("varchar(20)");

            builder.Property(vg => vg.Developer)
                .HasColumnName("developer")
                .HasColumnType("varchar(200)");

            builder.Property(vg => vg.BarCode)
                .HasColumnName("barcode")
                .HasColumnType("varchar(50)");

            builder.Property(vg => vg.Notes)
                .HasColumnName("notes")
                .HasColumnType("varchar(500)");

            builder.Property(vg => vg.Description)
               .HasColumnName("description")
               .HasColumnType("varchar(1000)");

            builder.Property(vg => vg.Redump)
               .HasColumnName("redump")
               .HasColumnType("varchar(200)");

            builder.Property(vg => vg.CreateDate)
               .HasColumnName("createdate")
               .HasColumnType("datetime")
               .HasDefaultValueSql("now()"); ;

            builder.Property(vg => vg.UpdateDate)
               .HasColumnName("updatedate")
               .HasColumnType("datetime")
               .HasDefaultValueSql("now()");

            builder.Property(vg => vg.Genre)
               .HasColumnName("genre")
               .HasColumnType("varchar(1000)");

            builder.Property(vg => vg.Distributor)
               .HasColumnName("distributor")
               .HasColumnType("varchar(200)");

            builder.Property(vg => vg.IdSystem)
               .HasColumnName("idSystem")
               .HasColumnType("int)");

            builder.Property(vg => vg.IdSupport)
               .HasColumnName("idsupport")
               .HasColumnType("int)");

            builder.Property(vg => vg.Region)
                .HasColumnName("region")
                .HasColumnType("varchar(20)");

            builder.Property(vg => vg.Language)
              .HasColumnName("language")
              .HasColumnType("varchar(20)");

            builder.Property(vg => vg.IdUser)
              .HasColumnName("iduser")
              .HasColumnType("int");

            builder.Property(vg => vg.IsActive)
              .HasColumnName("isactive")
              .HasColumnType("smallint");

            builder.HasOne(v => v.System)
              .WithMany(p => p.VideoGames)
              .HasForeignKey(vg => vg.IdSystem);
           
            builder.HasOne(v => v.Support)
              .WithMany(s => s.VideoGames)
              .HasForeignKey(vg => vg.IdSupport);

            builder.HasOne(v => v.User)
              .WithMany(u => u.VideoGames)
              .HasForeignKey(vg => vg.IdUser);
       }
       

    }
}

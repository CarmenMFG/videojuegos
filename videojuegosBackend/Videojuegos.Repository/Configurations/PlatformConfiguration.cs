using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Configurations
{
    public class PlatformConfiguration : IEntityTypeConfiguration<PlatformEntity>
    {
        public void Configure(EntityTypeBuilder<PlatformEntity> builder)
        {
            builder.ToTable("PLATFORM");

            builder.HasKey(pl => pl.Id)
                .HasName("PK_Platform");

            builder.Property(pl => pl.Id)
                .HasColumnName("id");

            builder.Property(pl => pl.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(pl => pl.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(1000)");
           

        }
    }
}


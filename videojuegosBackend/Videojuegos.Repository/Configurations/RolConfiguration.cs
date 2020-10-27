using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<PlatformEntity>
    {
        public void Configure(EntityTypeBuilder<PlatformEntity> builder)
        {
            builder.ToTable("ROL");

            builder.HasKey(r => r.Id)
                .HasName("PK_Rol");

            builder.Property(r => r.Id)
                .HasColumnName("id");

            builder.Property(r => r.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar(20)");
          
            builder.Property(r => r.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(1000)");
        }
    }
}

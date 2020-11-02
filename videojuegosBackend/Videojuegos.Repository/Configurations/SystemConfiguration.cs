using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Configurations
{
    public class SystemConfiguration : IEntityTypeConfiguration<SystemEntity>
    {
        public void Configure(EntityTypeBuilder<SystemEntity> builder)
        {
            builder.ToTable("SYSTEM");

            builder.HasKey(st => st.Id)
                .HasName("PK_System");

            builder.Property(st => st.Id)
                .HasColumnName("id");

            builder.Property(st => st.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(st => st.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(1000)");

            builder.Property(st => st.IdPlatform)
               .HasColumnName("idplatform")
               .HasColumnType("int");

            builder.HasOne(v => v.Platform)
             .WithMany(u => u.Systems)
             .HasForeignKey(vg => vg.IdPlatform);
           
         

        }
    }
}


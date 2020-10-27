using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Configurations
{
    public class SupportConfiguration : IEntityTypeConfiguration<SupportEntity>
    {
        public void Configure(EntityTypeBuilder<SupportEntity> builder)
        {
            builder.ToTable("SUPPORT");

            builder.HasKey(su => su.Id)
                .HasName("PK_Support");

            builder.Property(su => su.Id)
                .HasColumnName("id");

            builder.Property(su => su.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(su => su.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(1000)");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Data
{
  public  class VideogameContext : DbContext
    {
        public VideogameContext(DbContextOptions<VideogameContext> options) : base(options) { }
        
        public DbSet<VideoGameEntity> VideoGames { get; set; }
        public DbSet<PlatformEntity> Platforms { get; set; }
        public DbSet<SupportEntity> Supports { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

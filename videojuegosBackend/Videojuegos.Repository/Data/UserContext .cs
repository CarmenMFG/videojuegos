using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Videogames.Repository.Entities;

namespace Videogames.Repository.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<UserEntity> Users{ get; set; }
        public DbSet<RolEntity> Roles { get; set; }

        //meter soporte
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

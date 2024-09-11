using Microsoft.EntityFrameworkCore;
using Web_Api_JWT.Configs;

namespace Web_Api_JWT.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Category>Categories { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            base.OnModelCreating(modelBuilder); 
        }
    }
}

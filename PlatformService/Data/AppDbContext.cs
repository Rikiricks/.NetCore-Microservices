using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7354L29\\SQLEXPRESS;Database=platformsdb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Platform> Platforms{get;set;}
    }

}
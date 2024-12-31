using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data{
    public class DataContextEF : DbContext{

        private IConfiguration _config;

        public DataContextEF(IConfiguration config){
            _config = config;
        }

public DbSet<Computer> Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To check if it is configured and to avoid second time overriding the configuration method
            //It takes 2 arguments, one is the path to the sql server and the other is a call back function where we can onvoke the retry on failure method
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultString"),optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

modelBuilder.Entity<Computer>().HasKey(c=>c.ComputerId);
            // modelBuilder.Entity<Computer>().ToTable("Computer", "TutorialAppSchema");

        }

    }
}
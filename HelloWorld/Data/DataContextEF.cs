using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data{
    public class DataContextEF : DbContext{

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To check if it is configured and to avoid second time overriding the configuration method
            //It takes 2 arguments, one is the path to the sql server and the other is a call back function where we can onvoke the retry on failure method
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;",optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

    }
}
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = localhost; Initial Catalog = Streamer; Integrated Security = True; ; MultipleActiveResultSets = True; App = EntityFramework")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Name}, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }


    }
}

using Microsoft.EntityFrameworkCore;

namespace Mission06_Brown.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Database already contains data, so no seed data needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No seed data - using existing JoelHiltonMovieCollection.sqlite database
        }
    }
}

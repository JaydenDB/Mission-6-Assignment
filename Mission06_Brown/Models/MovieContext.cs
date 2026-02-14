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

        // Seed categories and 3 initial movies
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            // Seed 3 movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = null,
                    Notes = "Best superhero film"
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 3,
                    Title = "The Shawshank Redemption",
                    Year = 1994,
                    Director = "Frank Darabont",
                    Rating = "R",
                    Edited = true,
                    LentTo = null,
                    Notes = "Classic"
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryId = 2,
                    Title = "The Princess Bride",
                    Year = 1987,
                    Director = "Rob Reiner",
                    Rating = "PG",
                    Edited = false,
                    LentTo = null,
                    Notes = "Inconceivable!"
                }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// setting up the connection between the database and our website  
namespace mission4.Models
{
    public class MovieContext : DbContext
    {
        // constructor
        public MovieContext(DbContextOptions<MovieContext>options) : base (options)
        {
            // leave blank for now
        }
        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category>Categories{ get; set; }
        // linking all of the category names to id's to be able to loop through them later
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName="Comedy"},
                new Category { CategoryId = 3, CategoryName="Drama"},
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" }
                );
            mb.Entity<ApplicationResponse>().HasData(
                // adding more movies to the database by hand

                new ApplicationResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Dumb and Dumber",
                    Director = "Peter Farrlley",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Star Wars: The Emperor Strikes Back",
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    CategoryId = 3,
                    Title = "Better Off Dead",
                    Director = "Savage Steve Holland",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }

                ); ;
        }
    }
}

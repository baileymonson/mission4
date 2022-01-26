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

        // adding more movies to the database by hand
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieId = 1,
                    Category = "Comedy",
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
                    Category = "Action/Sci-Fi",
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
                    Category = "Comedy/Romance",
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

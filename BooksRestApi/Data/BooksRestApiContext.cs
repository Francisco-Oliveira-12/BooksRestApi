using BooksRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksRestApi.Data
{
    //Entity Framework Core
    //Query data from the database.
    //Do different kinds of operations with data from the database
    public class BooksRestApiContext : DbContext
    {
        //Constructor
        public BooksRestApiContext(DbContextOptions<BooksRestApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    YearPublished = 2018
                },
                new Book
                {
                    Id = 2,
                    Title = "Deep Work",
                    Author = "Cal Newport",
                    YearPublished = 2016
                },
                new Book
                {
                    Id = 3,
                    Title = "The 7 Habits of Highly Effective People",
                    Author = "Stephen R. Covey",
                    YearPublished = 1989
                },
                new Book
                {
                    Id = 4,
                    Title = "Mindset",
                    Author = "Carol S. Dweck",
                    YearPublished = 2006
                }
             );
        }

        //Made to be able to access and do different kinds of opperations in the table Books
        public DbSet<Book> Books { get; set; }
    }
}

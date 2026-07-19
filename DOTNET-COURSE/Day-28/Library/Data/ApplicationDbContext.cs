using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.ViewModels;

namespace Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connection = builder.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category>() {
                new Category { Id = 1, Name = "Action"},
                new Category { Id = 2, Name = "SciFi"},
                new Category { Id = 3, Name = "History"}
            });

            modelBuilder.Entity<Book>().HasData(new List<Book>() {
                new Book { ISBN = 1, Name = "Book1", Description = "Description Book 1", Author = "Author 1", CategoryId = 1},
                new Book { ISBN = 2, Name = "Book2", Description = "Description Book 2", Author = "Author 2", CategoryId = 2},
                new Book { ISBN = 3, Name = "Book3", Description = "Description Book 3", Author = "Author 3", CategoryId = 1},
                new Book { ISBN = 4, Name = "Book4", Description = "Description Book 4", Author = "Author 4", CategoryId = 2},
                new Book { ISBN = 5, Name = "Book5", Description = "Description Book 5", Author = "Author 5", CategoryId = 3}
            });
        }
        public DbSet<Library.ViewModels.BookVM> BookVM { get; set; } = default!;

    }
}

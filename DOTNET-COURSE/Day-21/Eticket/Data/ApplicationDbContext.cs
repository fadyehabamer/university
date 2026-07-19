using Microsoft.EntityFrameworkCore;
using Eticket.Models;
using Microsoft.Extensions.Configuration;

namespace Eticket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ActorMovies> ActorMovies { get; set; } // This DbSet will default to the "ActorMovies" table
        public DbSet<Cinema> Cinemas { get; set; }

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActorMovies>()
                .HasKey(am => new { am.ActorsId, am.MoviesId });

            modelBuilder.Entity<ActorMovies>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorsId);

            modelBuilder.Entity<ActorMovies>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MoviesId);
        }
    }
}

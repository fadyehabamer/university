using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Taask> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9GSKSA6\DOTNETCOURSE;Initial Catalog=Task01EF;Integrated Security=True;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // change table name to NewTask
            modelBuilder.Entity<Taask>()
            .ToTable("NewTask");

            // ------------------------------------------------

            // change col name date to deadline
            modelBuilder.Entity<Taask>()
            .Property(t => t.Date)
            .HasColumnName("Deadline");

        }

    }
}

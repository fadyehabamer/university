using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var bulider = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var connection = bulider.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connection);
        }
    }
}

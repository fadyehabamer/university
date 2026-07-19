using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var bulider = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var connection = bulider.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connection);
        }


        public DbSet<WebApplication1.ViewModels.DepartmentVM> DepartmentVM { get; set; } = default!;
    }
}

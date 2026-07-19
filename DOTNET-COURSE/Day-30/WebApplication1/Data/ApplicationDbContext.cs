using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Data
{



    public class ApplicationDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" },
                new Department { Id = 3, Name = "Payroll" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John", Designation = "Software Engineer", DepartmentId = 1 },
                new Employee { Id = 2, Name = "Smith", Designation = "HR Manager", DepartmentId = 2 },
                new Employee { Id = 3, Name = "Peter", Designation = "Payroll Manager", DepartmentId = 3 }
            );
        }

    }
}

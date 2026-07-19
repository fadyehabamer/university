using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFRev504;Integrated Security=True;TrustServerCertificate=True",);

            var bulider = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var connection = bulider.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connection);
        }
    }
}

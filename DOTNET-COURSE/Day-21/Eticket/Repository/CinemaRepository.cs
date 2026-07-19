using Eticket.Models;
using Eticket.Repository.IRepository;
using Eticket.Data;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public List<Cinema> GetAllCinemas()
        {
            return context.Cinemas.ToList();
        }

        public Cinema GetCinemaById(int cinemaId)
        {
            // return cinema with id and all asociated films
            return context.Cinemas
               .Include(c => c.Movies)
               .FirstOrDefault(c => c.Id == cinemaId);

        }
    }
}

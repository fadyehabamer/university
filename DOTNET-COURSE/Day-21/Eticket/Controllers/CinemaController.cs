using Eticket.Data;
using Eticket.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Controllers
{
    public class CinemaController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        CinemaRepository cinemaRepository = new CinemaRepository();

        public IActionResult Index()
        {
            var cinemas = cinemaRepository.GetAllCinemas();
            return View(cinemas);
        }

        public IActionResult Details(int id)
        {
            var cinema = cinemaRepository.GetCinemaById(id);
            return View(cinema);
        }




    }
}

using Eticket.Data;
using Eticket.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Controllers
{
    public class ActorController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        ActorRepository actorRepository = new ActorRepository();

        public IActionResult Index()
        {
            var actors = actorRepository.GetAllActors();
            return View(actors);

        }

        public IActionResult Details(int id)
        {
            var actor = actorRepository.GetActorById(id);

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }
    }
}

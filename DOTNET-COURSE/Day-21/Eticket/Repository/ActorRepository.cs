using Eticket.Data;
using Eticket.Repository.IRepository;
using Eticket.Models;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Repository
{
    public class ActorRepository : IActorRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public List<Actor> GetAllActors()
        {
            return context.Actors.ToList();
        }

        public Actor GetActorById(int actorId)
        {
            // return actor with id and all asociated films
            return context.Actors
                .Include(a => a.ActorMovies)
                .ThenInclude(am => am.Movie)
                .FirstOrDefault(a => a.Id == actorId);

        }


    }
}

using Eticket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Repository.IRepository
{
   public interface IActorRepository
   {
        List<Actor> GetAllActors();

        Actor GetActorById(int actorId);


   }
}

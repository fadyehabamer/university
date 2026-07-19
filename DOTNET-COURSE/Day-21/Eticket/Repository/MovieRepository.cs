using Eticket.Data;
using Eticket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Eticket.Repository


{
    public class MovieRepository : IMovieRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public List<Movie> GetAllMovies()
        {
            return context.Movies.ToList();

        }

        public Movie GetMovieById(int movieId)
        {

            return context.Movies
             .Include(m => m.Category)
             .Include(m => m.ActorMovies)
                 .ThenInclude(am => am.Actor)
             .FirstOrDefault(m => m.Id == movieId);



        }

        public List<Actor> GetActorForMovie(int movieId)
        {
            return context.ActorMovies.Where(x => x.MoviesId == movieId).Select(x => x.Actor).ToList();
        }
    }
}

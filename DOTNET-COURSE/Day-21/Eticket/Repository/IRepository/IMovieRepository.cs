using Eticket.Models;

namespace Eticket.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int movieId);

        List<Actor> GetActorForMovie(int movieId);



    }
}
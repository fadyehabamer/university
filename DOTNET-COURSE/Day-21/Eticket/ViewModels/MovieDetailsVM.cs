using Eticket.Models;

namespace Eticket.ViewModels
{
    public class MovieDetailsVM
    {
        public Movie Movie { get; set; }
        public List<Movie> RecommendedMovies { get; set; }
    }
}

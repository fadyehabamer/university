namespace Eticket.Models
{
    public class ActorMovies
    {
        public int ActorsId { get; set; } // Updated from ActorId
        public Actor Actor { get; set; }

        public int MoviesId { get; set; } // Updated from MovieId
        public Movie Movie { get; set; }
    }
}
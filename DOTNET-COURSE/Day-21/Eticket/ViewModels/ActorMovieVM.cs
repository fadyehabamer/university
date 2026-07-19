namespace Eticket.ViewModels
{
    public class ActorMovieVM
    {
        public int ActorId { get; set; }
        public ActorVM Actor { get; set; }

        public int MovieId { get; set; }
        public MovieVM Movie { get; set; }

    }
}

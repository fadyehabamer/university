namespace Eticket.ViewModels
{
    public class CinemaVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CinemaLogo { get; set; }
        public string Address { get; set; }
        public List<MovieVM> Movies { get; set; } // Optional, depending on usage


    }
}

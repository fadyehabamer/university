using Eticket.Models;

namespace Eticket.ViewModels;
    using Eticket.Data;

    public class MovieVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MovieStatus MovieStatus { get; set; }

        public int CinemaId { get; set; }
        public CinemaVM Cinema { get; set; } // Referencing CinemaVM

        public int CategoryId { get; set; }
        public CategoryVM Category { get; set; } // Referencing CategoryVM

        public List<ActorVM> Actors { get; set; } // Referencing ActorVM

    }


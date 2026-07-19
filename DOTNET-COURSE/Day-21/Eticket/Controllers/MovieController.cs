using Eticket.Data;
using Eticket.Models;
using Eticket.Repository;
using Eticket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        MovieRepository movieRepository = new MovieRepository();

        public IActionResult Index()
        {
            var movies = movieRepository.GetAllMovies();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = movieRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            // Fetch movies from the same category
            var recommendedMovies = context.Movies
        .Include(m => m.Category) // Include the Category
        .Where(m => m.CategoryId == movie.CategoryId && m.Id != movie.Id)
        .ToList();

            var viewModel = new MovieDetailsVM
            {
                Movie = movie,
                RecommendedMovies = recommendedMovies
            };

            return View(viewModel);

        }


        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(Enumerable.Empty<Movie>());
            }

            var movies = movieRepository.GetAllMovies()
                .Where(m => m.Name.Contains(query))
                .ToList();

            return View(movies);
        }

    }
}

using Eticket.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult Index()
        {
            var categories = categoryRepository.GetAllCategories();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}

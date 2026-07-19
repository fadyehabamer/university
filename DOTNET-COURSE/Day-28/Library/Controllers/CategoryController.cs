using Library.Data;
using Library.Models;
using Library.Repository;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        BookRepository bookRepository = new BookRepository();
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult Index()
        {
            //var listOfCategories = context.Categories.ToList();

            // Repository pattern
            var listOfCategories = categoryRepository.GetAllCategories();
            return View(listOfCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            if(ModelState.IsValid)
            {
                // Mapping
                Category category = new Category() { Name = categoryVM.Name };

                //context.Categories.Add(category);
                //context.SaveChanges();

                // Repository pattern
                categoryRepository.CreateCategory(category);

                TempData["alert"] = "Created successfuly";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            // var category = context.Categories.Find(id);
            //Repository pattern
            var category = categoryRepository.GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                // Mapping
                Category category = new Category() { Id = categoryVM.Id, Name = categoryVM.Name };

                //context.Categories.Update(category);
                //context.SaveChanges();

                // Repository pattern
                categoryRepository.UpdateCategory(category);

                TempData["alert"] = "Updated successfuly";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            //var category = context.Categories.Find(id);

            //Repository pattern
            var category = categoryRepository.GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int Id)
        {
            // Mapping
            // var category = context.Categories.Find(Id);

            // Repository pattern
            var category = categoryRepository.GetCategoryById(Id);

            //context.Categories.Remove(category);
            //context.SaveChanges();

            // Repository pattern
            categoryRepository.DeleteCategory(Id);

            TempData["alert"] = "Deleted successfuly";

            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var departments = context.Departments.ToList();
            return View(departments);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM department)
        {

            var departmentModel = new Department
            {
                Name = department.Name
            };

            if (!ModelState.IsValid)
            {
                return View(department);
            }
            TempData["Message"] = "Department added successfully";

            context.Departments.Add(departmentModel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var department = context.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var departmentModel = context.Departments.Find(department.Id);
            departmentModel.Name = department.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Details(int id)
        {
            var department = context.Departments.Find(id);
            return View(department);
        }






    }
}

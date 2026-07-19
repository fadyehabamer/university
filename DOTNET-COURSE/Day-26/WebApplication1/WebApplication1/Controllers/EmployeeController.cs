using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index(string userName)
        {

            var employees = context.Employees.Include(e => e.Department).ToList();

            //var employees = context.Employees.ToList();
            // var departments = context.Departments.ToList();
            // foreach (var employee in employees)
            // {
            //     employee.Department = departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
            // }

            ViewData["Message"] = "Hello from ViewData";
            ViewBag.MessageTwo = "Hello from ViewBag";

            ViewData["EmpCount"] = employees.Count;

            if (!string.IsNullOrEmpty(userName))
            {
                ViewData["Name"] = userName;
            }
            else
            {
                ViewData["Name"] = "Guest";
            }


            TempData["Message"] = "Hello from TempData";
            ViewData["CookieName"] = Request.Cookies["UserName"];
            return View(employees);
        }




        public IActionResult Create()
        {
            ViewData["Departments"] = context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVM)
        {

            if (ModelState.IsValid)
            {
                //context.Employees.Add(employee
                // Casting From Model to ViewModel
                var employee = new Employee
                {
                    Name = employeeVM.Name,
                    Phone = employeeVM.Phone,
                    Email = employeeVM.Email,
                    Address = employeeVM.Address,
                    DepartmentId = employeeVM.DepartmentId
                };



                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


            for (int i = 0; i < ModelState.Count; i++)
            {
                var key = ModelState.Keys.ElementAt(i);
                var value = ModelState.Values.ElementAt(i);
                if (value.Errors.Count > 0)
                {
                    var error = value.Errors[0];
                    ModelState.AddModelError(key, error.ErrorMessage);

                    Console.WriteLine(key + " : " + error.ErrorMessage);

                }
            }

            return View(employeeVM);
        }

        public IActionResult Edit(int id)
        {
            var employee = context.Employees.Find(id);
            return View(employee);
        }

        public IActionResult SaveEdit(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult GetUserName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetUserName(string name)

        {
            TempData["Name"] = name;
            Response.Cookies.Append("UserName", name);
            return RedirectToAction("Index");

        }


    }
}

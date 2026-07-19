using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var result = context.Products.ToList();
            return View(result);
        }

        // https://localhost:7040/product/GetProductById?id=1
        // https://localhost:7040/product/GetProductById/1
        public IActionResult GetProductById(int id)
        {
            var result = context.Products.Find(id);
            return View(result);
        }

        // https://localhost:7040/product/GetProductByName?name=iphone 1
        // https://localhost:7040/product/GetProductByName/iphone 1 // NOT VALID!!!!!
        public IActionResult GetProductByName(string name)
        {
            var result = context.Products.FirstOrDefault(e => e.Name == name);
            return View(result);
        }

    }
}

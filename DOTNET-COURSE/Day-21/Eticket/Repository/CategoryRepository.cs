using Eticket.Repository.IRepository;
using Eticket.Models;
using Eticket.Data;
using Microsoft.EntityFrameworkCore;
namespace Eticket.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            // return category with id and all asociated films
            return context.Categories
               .Include(c => c.Movies)
               .FirstOrDefault(c => c.Id == categoryId);

        }
    }
}

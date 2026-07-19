using Library.Data;
using Library.Models;
using Library.Repository.IRepository;

namespace Library.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Categories.Find(id);
            }
        }

        public void CreateCategory(Category category)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Categories.Update(category);
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }

        }






    }
}


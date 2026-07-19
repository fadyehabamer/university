using Eticket.Models;
namespace Eticket.Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
    }
}

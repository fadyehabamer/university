using Models;
using System.Linq.Expressions;

namespace WebApplication1.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        // CRUD
        List<Department> GetAll();

        //Department GetById(int id);
        //Department GetByName(string name);
        Department GetOne(Expression <Func<Department, bool>> filter);

        void Create(Department department);
        void Update(Department department);
        void Delete(int id);





    }
}

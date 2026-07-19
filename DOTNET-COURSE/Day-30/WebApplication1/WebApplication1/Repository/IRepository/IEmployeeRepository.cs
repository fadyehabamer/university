using Models;

namespace WebApplication1.Repository.IRepository
{
    public interface IEmployeeRepository
    {

        List<Employee> GetAll();
        Employee GetById(int id);

        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);




    }
}

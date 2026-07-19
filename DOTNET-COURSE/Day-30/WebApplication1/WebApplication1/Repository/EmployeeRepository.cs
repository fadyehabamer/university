using Models;
using Data;
using WebApplication1.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            // will do Cycle reference
            // return _context.Employees.Include(Employee => Employee.Department).ToList();

            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

    }
}

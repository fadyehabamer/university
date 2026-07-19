using Data;
using Models;
using System.Linq.Expressions;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        //public Department GetById(int id)
        //{
        //    return _context.Departments.FirstOrDefault(x => x.Id == id);
        //}

        //public Department GetByName(string name)
        //{
        //    return _context.Departments.FirstOrDefault(x => x.Name == name);
        //}

        public Department GetOne(Expression<Func<Department, bool>> filter)
        {
            return _context.Departments.Where(filter).FirstOrDefault();
        }



        public void Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }




    }
}

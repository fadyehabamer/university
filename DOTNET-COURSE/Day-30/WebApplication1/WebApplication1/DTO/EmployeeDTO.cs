using Models;

namespace WebApplication1.DTO
{
    public class EmployeeDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        //public Department Department { get; set; }



    }
}

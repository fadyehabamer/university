using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApplication1.DTO;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository depatrmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository depatrmentRepository
            )
        {
            this.employeeRepository = employeeRepository;
            this.depatrmentRepository = depatrmentRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployess()
        {
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();

            // Mapping Employee to EmployeeVM
            foreach (var employee in employeeRepository.GetAll())
            {
                employeesDTO.Add(new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Designation = employee.Designation,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = depatrmentRepository.GetOne(x => x.Id == employee.DepartmentId).Name
                });
            }



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // return Ok(employeeRepository.GetAll());
            // Must return the DTO object - DepartmentVM
            return Ok(employeesDTO);

        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = employeeRepository.GetById(id);


            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Designation = employee.Designation,
                DepartmentId = employee.DepartmentId
            };

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employeeDTO);
        }


        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee employee = new Employee
            {
                Name = employeeDTO.Name,
                Designation = employeeDTO.Designation,
                DepartmentId = employeeDTO.DepartmentId,
            };

            employeeRepository.Create(employee);

            //return Ok(employee);
            return Created(employee.Name.ToString(), employee);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = employeeDTO.Name;
            employee.Designation = employeeDTO.Designation;
            employee.DepartmentId = employeeDTO.DepartmentId;

            employeeRepository.Update(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            employeeRepository.Delete(id);

            return NoContent();
        }

    }
}

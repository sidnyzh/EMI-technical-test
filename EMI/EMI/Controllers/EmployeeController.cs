using EMI.Application.DTO.Employee.Request;
using EMI.Application.DTO.Employee.Response;
using EMI.Application.Interface;
using EMI.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "RolePolicy")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeApplication _employeeApplication;

        public EmployeeController(IEmployeeApplication employeeApplication)

        {
            _employeeApplication = employeeApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeApplication.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            GetEmployeeResponse employee = await _employeeApplication.GetEmployee(Id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest newEmployee)
        {
            await _employeeApplication.CreateEmployee(newEmployee);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeRequest updatedEmployee)
        {
            await _employeeApplication.UpdateEmployee(id, updatedEmployee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeApplication.DeleteEmployee(id);
            return Ok();
        }
    }
}

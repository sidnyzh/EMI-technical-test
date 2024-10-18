using AutoMapper;
using EMI.Application.DTO.Employee.Request;
using EMI.Application.DTO.Employee.Response;
using EMI.Application.Interface;
using EMI.Domain.Entity;
using EMI.Domain.Interface;

namespace EMI.Application.Main
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeDomain _employeeDomain;
        private readonly IMapper _mapper;

        public EmployeeApplication(IEmployeeDomain employeeDomain, IMapper mapper)
        {
            _employeeDomain = employeeDomain;
            _mapper = mapper;
        }

        public async Task CreateEmployee(CreateEmployeeRequest employee)
        {
            Employee CreateEmployeeRequestToEmployee = _mapper.Map<Employee>(employee);

            PositionHistory positionHistory = new ()
            {
                Position = employee.CurrentPosition,
                StartDate = DateTime.UtcNow,

            };

            CreateEmployeeRequestToEmployee.PositionHistories.Add(positionHistory);

            await _employeeDomain.CreateEmployee(CreateEmployeeRequestToEmployee);
        }


        public async Task<GetEmployeeResponse> GetEmployee(int id)
        {
            Employee employee = await _employeeDomain.GetEmployee(id);

            GetEmployeeResponse EmployeeToGetEmployeeResponse = _mapper.Map<GetEmployeeResponse>(employee);

            return EmployeeToGetEmployeeResponse;
        }

        public async Task<IEnumerable<GetEmployeeResponse>> GetEmployees()
        {
            IEnumerable<Employee> employee = await _employeeDomain.GetEmployees();

            IEnumerable<GetEmployeeResponse> EmployeesToGetEmployeeResponse = _mapper.Map<IEnumerable<GetEmployeeResponse>>(employee);

            return EmployeesToGetEmployeeResponse;
        }

        public async Task UpdateEmployee(int id, UpdateEmployeeRequest updateEmployee)
        {
            Employee updateEmployeeRequestToEmployee = _mapper.Map<Employee>(updateEmployee);

            updateEmployeeRequestToEmployee.EmployeeId = id;

            await _employeeDomain.UpdateEmployee(updateEmployeeRequestToEmployee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeDomain.DeleteEmployee(id);
        }
    }
}

using EMI.Application.DTO.Employee.Request;
using EMI.Application.DTO.Employee.Response;

namespace EMI.Application.Interface
{
    public interface IEmployeeApplication
    {
        Task<IEnumerable<GetEmployeeResponse>> GetEmployees();

        Task<GetEmployeeResponse> GetEmployee(int id);

        Task CreateEmployee(CreateEmployeeRequest createEmployee);

        Task UpdateEmployee(int id, UpdateEmployeeRequest updateEmployee);

        Task DeleteEmployee(int id);
    }
}

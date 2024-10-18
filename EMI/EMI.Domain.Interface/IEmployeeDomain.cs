using EMI.Domain.Entity;

namespace EMI.Domain.Interface
{
    public interface IEmployeeDomain
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task CreateEmployee(Employee employee);

        Task UpdateEmployee(Employee employee);

        Task DeleteEmployee(int id);
    }
}

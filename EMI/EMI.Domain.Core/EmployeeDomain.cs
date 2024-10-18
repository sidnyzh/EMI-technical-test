using EMI.Domain.Entity;
using EMI.Domain.Interface;
using EMI.Repository.EFC;
using EMI.Repository.Pattern.Repository;
using EMI.Transversal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static EMI.Transversal.Enums.Enums;

namespace EMI.Domain.Core
{
    public class EmployeeDomain : IEmployeeDomain
    {
        private readonly EmiDbContext _context;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeDomain(EmiDbContext context, IRepository<Employee> employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException();
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _employeeRepository.InsertAsync(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            Employee Originalemployee = await _employeeRepository.GetWithIncludesAsync(e => e.EmployeeId == employee.EmployeeId,
            e => e.PositionHistories) 
                ?? throw new NotFoundException();

            Originalemployee.Name = employee.Name;
            Originalemployee.Department = employee.Department;
            Originalemployee.Salary = employee.Salary;
            
            if(Originalemployee.CurrentPosition != employee.CurrentPosition)
            {
                var oldPosition = Originalemployee.PositionHistories.Where( ph => ph.EndDate is null)
                    .FirstOrDefault() ?? null;

                oldPosition.EndDate = DateTime.UtcNow;

                PositionHistory newPosition = new PositionHistory()
                {
                    Employee = Originalemployee.EmployeeId,
                    Position = employee.CurrentPosition,
                    StartDate = DateTime.UtcNow,
                    EndDate = null,
                };

                 Originalemployee.CurrentPosition = employee.CurrentPosition;
                Originalemployee.PositionHistories.Add(newPosition);
            }

            await _employeeRepository.UpdateAsync(Originalemployee);
        }

        public async Task DeleteEmployee(int Id)
        {
            var employee = await _employeeRepository.GetByIdAsync(Id)
            ?? throw new NotFoundException("Employee not found");

            await  _employeeRepository.DeleteAsync(Id);
        }

        private async Task<IEnumerable<Employee>> GetEmployeesInDepartmentWithProjects(int department)
        {
            var employeesInDepartmentWithProjects = await _context.Employees
                .Where(e => e.Department == department && e.EmployeeProjects != null)
                .ToListAsync();

            return employeesInDepartmentWithProjects;
        }

        private decimal CalculateYearlyBonus(Employee employee)
        {
            decimal bonusPercentage;

            switch (employee.CurrentPosition)
            {
                case (int)PositionTypesEnum.DepartmentManager:
                case (int)PositionTypesEnum.ExecutiveManager:
                case (int)PositionTypesEnum.ProjectManager:
                case (int)PositionTypesEnum.SeniorManager:
                    bonusPercentage = 0.2m;
                    break;
                default:
                    bonusPercentage = 0.1m;
                    break;
            }

            return employee.Salary * bonusPercentage;
        }

    }
}

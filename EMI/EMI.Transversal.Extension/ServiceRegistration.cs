using EMI.Application.Interface;
using EMI.Application.Main;
using EMI.Domain.Core;
using EMI.Domain.Entity.Models;
using EMI.Domain.Interface;
using EMI.Repository.Pattern.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EMI.Transversal.Extension
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeDomain, EmployeeDomain>();
            services.AddScoped<IEmployeeApplication, EmployeeApplication>();
            services.AddScoped<IRepository<Employee>, Repository<Employee>>();
        }
    }
}

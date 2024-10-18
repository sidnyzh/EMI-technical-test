using EMI.Application.Interface;
using EMI.Application.Main;
using EMI.Authentication.Authentication;
using EMI.Authentication.Authorization;
using EMI.Authentication.JWT;
using EMI.Domain.Core;
using EMI.Domain.Entity;
using EMI.Domain.Interface;
using EMI.Repository.EFC;
using EMI.Repository.Pattern.Repository;
using Microsoft.AspNetCore.Authorization;

namespace EMI.AppStart
{
    public static class DependencyResolver
    {
        public static  IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IEmployeeApplication, EmployeeApplication>();
            services.AddScoped<IEmployeeDomain, EmployeeDomain>();
            services.AddScoped<IRepository<Employee>, Repository<Employee>>();


            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IRepository<User>, Repository<User>>();


            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IAuthorizationHandler, RoleHandler>();

            services.AddScoped<IJWTInformation, JWTInformation>();

            return services;
        }
    }
}

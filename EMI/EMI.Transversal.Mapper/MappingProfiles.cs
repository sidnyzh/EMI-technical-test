using AutoMapper;
using EMI.Application.DTO.Employee.Request;
using EMI.Application.DTO.Employee.Response;
using EMI.Application.DTO.User.Request;
using EMI.Application.DTO.User.Response;
using EMI.Domain.Entity;

namespace EMI.Transversal.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<CreateEmployeeRequest, Employee>();
            CreateMap<Employee, GetEmployeeResponse>();
            CreateMap<User, UserResponse>();
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateEmployeeRequest, Employee>();
        }
    }
}

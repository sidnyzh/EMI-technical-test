using EMI.Application.DTO.User.Request;
using EMI.Application.DTO.User.Response;

namespace EMI.Application.Interface
{
    public interface IUserApplication
    {
        Task<UserResponse> LoginUser(AuthenticationRequest authentication);

        Task CreateUser(CreateUserRequest createUser);
    }
}

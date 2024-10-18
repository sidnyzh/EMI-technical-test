using EMI.Application.DTO.User.Response;

namespace EMI.Authentication.Authentication
{
    public interface IAuthenticationService
    {
        string GenerateJwtToken(UserResponse user);
    }
}

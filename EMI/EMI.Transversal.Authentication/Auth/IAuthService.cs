using EMI.Application.DTO.Response;

namespace EMI.Transversal.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserResponse user);
    }
}

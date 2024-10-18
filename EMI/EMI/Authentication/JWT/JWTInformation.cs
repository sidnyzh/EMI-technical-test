using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace EMI.Authentication.JWT
{
    public class JWTInformation : IJWTInformation
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JWTInformation(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            string result = String.Empty;
            if (_httpContextAccessor is not null)
            {
                return _httpContextAccessor.HttpContext.User.FindFirstValue("userId");
            }
            return result;
        }

        public string GetTokenId()
        {
            string result = String.Empty;
            if (_httpContextAccessor is not null)
            {
                return _httpContextAccessor.HttpContext.User.FindFirstValue("tokenId");
            }
            return result;
        }

        public string GetEmail()
        {
            string result = String.Empty;
            if (_httpContextAccessor is not null)
            {
                return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            }
            return result;
            
        }
    }
}

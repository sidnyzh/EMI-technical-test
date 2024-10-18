using EMI.Application.DTO.User.Request;
using EMI.Application.Interface;
using EMI.Application.Main;
using EMI.Authentication.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        private readonly IAuthenticationService _authService;

        public UserController(IUserApplication userApplication, IAuthenticationService authService)
        {
            _userApplication = userApplication;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] AuthenticationRequest authentication)
        {
            var user = await _userApplication.LoginUser(authentication);
            string token = _authService.GenerateJwtToken(user);

            return Ok(token);
        }

        [Authorize(Policy = "RolePolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUser)
        {
            await _userApplication.CreateUser(createUser);
            return Ok();
        }
    }

   
}

using AutoMapper;
using EMI.Application.DTO.User.Request;
using EMI.Application.DTO.User.Response;
using EMI.Application.Interface;
using EMI.Domain.Entity;
using EMI.Domain.Interface;
using EMI.Transversal.Exceptions;
using System.Security.Cryptography;

namespace EMI.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;

        public UserApplication(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }

        public async Task<UserResponse> LoginUser(AuthenticationRequest authentication)
        {

            var credentials = await _userDomain.GetUser(authentication.Email);

            bool isAValidPassword = BCrypt.Net.BCrypt.Verify(authentication.Password, credentials.Password ?? "");
            bool credentialsAreValid = credentials is not null && isAValidPassword;

            if (!credentialsAreValid)
            {
                throw new NotFoundException("invalid credentials");
            }

            return _mapper.Map<UserResponse>(credentials);
        }

        public async Task CreateUser(CreateUserRequest createUser)
        {
            createUser.Password = BCrypt.Net.BCrypt.HashPassword(createUser.Password);

            var createUserToUser = _mapper.Map<User>(createUser);
            await _userDomain.CreateUser(createUserToUser);
        }
    }
}

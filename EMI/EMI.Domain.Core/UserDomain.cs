using EMI.Domain.Entity;
using EMI.Domain.Interface;
using EMI.Repository.Pattern.Repository;
using EMI.Transversal.Exceptions;

namespace EMI.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IRepository<User> _userRepository;

        public UserDomain(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.InsertAsync(user);
        }

        public async Task<User> GetUser (string email)
        {
            return await _userRepository.FirstOrDefaultAsync(u => u.Email == email) 
                ?? throw new NotFoundException("User not found");
        }
    }
}

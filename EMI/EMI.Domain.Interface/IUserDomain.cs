using EMI.Domain.Entity;

namespace EMI.Domain.Interface
{
    public interface IUserDomain
    {
        Task CreateUser(User user);
        Task<User> GetUser(string email);
    }
}

using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IUserRepo
    {
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUser(User user);
        Task<User?> FindUserById(Guid id);
        Task<User?> FindUserByName(string name);
        Task<User?> FindUserByEmailAsync(string email);
        Task<User?> FindUserByPhoneAndEmailAsync(string phone, string email);
        Task<User?> FindUserByPhoneAsync(string phone);
    }
}

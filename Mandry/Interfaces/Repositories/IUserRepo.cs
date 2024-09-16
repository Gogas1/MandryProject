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
        Task<User?> FindUserByIdWithReviewsAsync(Guid id);
        Task<bool> IsExistingById(Guid id);
        Task<User?> GetUserByHousingIdAsync(Guid housingId);
        Task<int> GetUserReviewsCount(Guid userId);
        Task UpdateUserOwnerStatus(Guid id);
    }
}

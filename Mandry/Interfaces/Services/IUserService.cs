using Mandry.Models.DB;

namespace Mandry.Interfaces.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Returns user with base info by specified phone
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<User?> GetBasicUserByPhoneAsync(string phone);

        /// <summary>
        /// Returns user with base info by specified email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetBasicUserByEmailAsync(string email);

        /// <summary>
        /// Returns user with base info by specified email or phone
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetBasicUserByPhoneOrEmailAsync(string phone, string email);

        /// <summary>
        /// Creates user with provided credentials
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns>Created user</returns>
        Task<User> CreateUser(string firstName, string surname, string password, DateTime birthDate, string? email = null, string? phone = null);
        Task<User> CreateUserAsync(User user);
        Task<User?> GetBasicUserByIdAsync(string id);
        Task EvaluateUserRating(string id);
        Task<bool> IsUserExistAsync(string id);
        Task<int> GetUserReviewsCount(Guid userId);
        Task<User> UpdateUserAvatar(User user, Image image);
    }
}

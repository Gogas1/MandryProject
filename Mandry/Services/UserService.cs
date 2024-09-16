using Mandry.Data.DbContexts;
using Mandry.Extensions;
using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(MandryDbContext context, IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<User> CreateUser(string firstName, string surname, string password, DateTime birthDate, string? email = null, string? phone = null)
        {
            throw new NotImplementedException();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepo.CreateUserAsync(user);
        }

        public async Task EvaluateUserRating(string id)
        {
            User? user = await _userRepo.FindUserByIdWithReviewsAsync(Guid.Parse(id));
            if (user == null) return;

            user.AverageRating = user.ReviewsReceived.Average(r => r.Rating);
            await _userRepo.UpdateUser(user);
        }

        public async Task<User?> GetBasicUserByEmailAsync(string email)
        {
            return await _userRepo.FindUserByEmailAsync(email);
        }

        public async Task<User?> GetBasicUserByIdAsync(string id)
        {
            return await _userRepo.FindUserById(Guid.Parse(id));
        }

        public async Task<User?> GetBasicUserByPhoneAsync(string phone)
        {
            return await _userRepo.FindUserByPhoneAsync(phone);
        }

        public async Task<User?> GetBasicUserByPhoneOrEmailAsync(string phone, string email)
        {
            return await _userRepo.FindUserByPhoneAndEmailAsync(phone, email);
        }

        public async Task<bool> IsUserExistAsync(string id)
        {
            return await _userRepo.IsExistingById(Guid.Parse(id));
        }

        public async Task<UserDataDTO> GetOwnerData(string housingId)
        {
            var user = await _userRepo.GetUserByHousingIdAsync(Guid.Parse(housingId));
            if (user == null) throw new ArgumentNullException("");
            return user.ToDTO();
        }

        public async Task<int> GetUserReviewsCount(Guid userId)
        {
            return await _userRepo.GetUserReviewsCount(userId);
        }

        public async Task<User> UpdateUserAvatar(User user, Image image)
        {
            user.ProfileImage = image;
            return await _userRepo.UpdateUser(user);
        }

    }
}

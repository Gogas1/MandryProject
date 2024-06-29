using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
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

        public async Task<User?> GetBasicUserByEmailAsync(string email)
        {
            return await _userRepo.FindUserByEmailAsync(email);
        }

        public async Task<User?> GetBasicUserByPhoneAsync(string phone)
        {
            return await _userRepo.FindUserByPhoneAsync(phone);
        }

        public async Task<User?> GetBasicUserByPhoneOrEmailAsync(string phone, string email)
        {
            return await _userRepo.FindUserByPhoneAndEmailAsync(phone, email);
        }
    }
}

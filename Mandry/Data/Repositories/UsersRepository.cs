using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Data.Repositories
{
    public class UsersRepository : IUserRepo
    {
        private readonly AirbnbDbContext _context;

        public UsersRepository(AirbnbDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> FindUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> FindUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> FindUserByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User?> FindUserByPhoneAndEmailAsync(string phone, string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone && u.Email == email);
        }

        public async Task<User?> FindUserByPhoneAsync(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone);
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}

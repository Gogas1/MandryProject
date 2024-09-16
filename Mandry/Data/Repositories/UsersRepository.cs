using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Data.Repositories
{
    public class UsersRepository : IUserRepo
    {
        private readonly MandryDbContext _context;

        public UsersRepository(MandryDbContext context)
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
            return await _context.Users.Include(u => u.ProfileImage).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> FindUserById(Guid id)
        {
            return await _context.Users
                .Include(u => u.ProfileImage)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> FindUserByIdWithReviewsAsync(Guid id)
        {
            return await _context.Users
                .Include(u => u.ReviewsReceived)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> FindUserByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User?> FindUserByPhoneAndEmailAsync(string phone, string email)
        {
            return await _context.Users
                .Include(u => u.ProfileImage)
                .FirstOrDefaultAsync(u => u.Phone == phone && u.Email == email);
        }

        public async Task<User?> FindUserByPhoneAsync(string phone)
        {
            return await _context.Users
                .Include(u => u.ProfileImage)
                .FirstOrDefaultAsync(u => u.Phone == phone);
        }

        public async Task<bool> IsExistingById(Guid id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<User> UpdateUser(User user)
        {           
            _context.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUserByHousingIdAsync(Guid housingId)
        {
            return await _context.Users
                .Include(u => u.UserAbout)
                .Include(u => u.ProfileImage)
                .FirstOrDefaultAsync(u => u.Housings.Any(h => h.Id == housingId));
        }

        public async Task<int> GetUserReviewsCount(Guid userId)
        {
            return await _context.Reviews
                .Where(r => r.To.Id == userId)
                .CountAsync();
        }

        public async Task UpdateUserOwnerStatus(Guid id)
        {
            var targerUser = await FindUserById(id);
            if(targerUser != null)
            {
                targerUser.IsOwner = true;
                if(targerUser.OwnerFrom == DateTime.MinValue)
                {
                    targerUser.OwnerFrom = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }
            
        }
    }
}

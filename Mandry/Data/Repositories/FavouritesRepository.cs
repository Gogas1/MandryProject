using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Data.Repositories
{
    public class FavouritesRepository : IFavouritesRepository
    {
        private readonly MandryDbContext _context;

        public FavouritesRepository(MandryDbContext context)
        {
            _context = context;
        }

        public async Task CreateFavourite(User user, Guid housingId)
        {
            var housing = new Housing()
            {
                Id = housingId,
            };
            _context.Housings.Attach(housing);
            user.Favourites.Add(housing);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Housing>> GetFavourites(User user)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == user.Id)                
                .Select(u => u.Favourites)                
                .FirstOrDefaultAsync() ?? new List<Housing>();
        }

        public async Task<ICollection<Housing>> GetFavouritesEnriched(User user)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == user.Id)
                .SelectMany(u => u.Favourites)
                .Include(h => h.Images)
                .ToListAsync() ?? new List<Housing>();
        }

        public async Task RemoveFavourite(User user, Guid housingId)
        {
            if (_context.Entry(user).State == EntityState.Detached)
            {
                _context.Users.Attach(user);
            }

            var favouritesCollection = _context.Entry(user).Collection(u => u.Favourites);

            if (!favouritesCollection.IsLoaded)
            {
                await favouritesCollection.LoadAsync();
            }

            var housingToRemove = user.Favourites.FirstOrDefault(h => h.Id == housingId);

            if (housingToRemove != null)
            {
                user.Favourites.Remove(housingToRemove);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsFavourite(User user, Guid housingId)
        {
            if (_context.Entry(user).State == EntityState.Detached)
            {
                _context.Users.Attach(user);
            }

            bool isFavourite = await _context.Entry(user)
                .Collection(u => u.Favourites)
                .Query()
                .AnyAsync(h => h.Id == housingId);

            return isFavourite;
        }
    }
}

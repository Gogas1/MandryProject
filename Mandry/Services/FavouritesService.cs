using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;

namespace Mandry.Services
{
    public class FavouritesService : IFavouritesService
    {
        private readonly IFavouritesRepository _favouritesRepository;
        private readonly IHousingRepository _housingRepository;
        public FavouritesService(IFavouritesRepository favouritesRepository, IHousingRepository housingRepository)
        {
            _favouritesRepository = favouritesRepository;
            _housingRepository = housingRepository;
        }

        public async Task<List<Housing>> GetFavourites(User user)
        {
            var result = await _favouritesRepository.GetFavourites(user);
            return result.ToList();
        }

        public async Task<List<Housing>> GetFavouritesEnriched(User user)
        {
            var result = await _favouritesRepository.GetFavouritesEnriched(user);
            return result.ToList();
        }

        public async Task<bool> MakeFavourite(User user, string housingId)
        {
            if(!await _housingRepository.IsHousingExistingByIdAsync(Guid.Parse(housingId)))
            {
                throw new ArgumentException("Housing is not existing");
            }

            if(await _favouritesRepository.IsFavourite(user, Guid.Parse(housingId))) {
                await _favouritesRepository.RemoveFavourite(user, Guid.Parse(housingId));
                return false;
            }
            else
            {
                await _favouritesRepository.CreateFavourite(user, Guid.Parse(housingId));
                return true;
            }
        }
    }
}

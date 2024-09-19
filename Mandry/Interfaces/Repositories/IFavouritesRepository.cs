using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IFavouritesRepository
    {
        Task CreateFavourite(User user, Guid housingId);
        Task RemoveFavourite(User user, Guid housingId);
        Task<ICollection<Housing>> GetFavourites(User user);
        Task<ICollection<Housing>> GetFavouritesEnriched(User user);
        Task<bool> IsFavourite(User user, Guid housingId);
    }
}

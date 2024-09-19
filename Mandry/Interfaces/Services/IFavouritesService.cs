using Mandry.Models.DB;

namespace Mandry.Interfaces.Services
{
    public interface IFavouritesService
    {
        Task<bool> MakeFavourite(User user, string housingId);
        Task<List<Housing>> GetFavouritesEnriched(User user);
        Task<List<Housing>> GetFavourites(User user);
    }
}

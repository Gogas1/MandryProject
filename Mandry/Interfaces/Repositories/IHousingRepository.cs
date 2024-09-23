using Mandry.Models.DB;
using Mandry.Models.Requests.Housing;

namespace Mandry.Interfaces.Repositories
{
    public interface IHousingRepository
    {
        Task<Housing> CreateHousingAsync(Housing housing);
        Task<Housing?> GetHousingByIdAsync(Guid id);
        Task<List<Housing>> GetAll();
        Task<bool> IsHousingExistingByIdAsync(Guid id);
        Task UpdateHousing(Housing housing);
        Task<float> GetHousingAverageRating(Guid id);
        Task<int> GetReviewsCount(Guid id);
        Task<ICollection<Review>> GetLastReviews(Guid housingId, int count);
        Task<ICollection<Housing>> FilterAsync(HousingFilterModel filter);
        Task<decimal> GetMinPrice();
        Task<decimal> GetMaxPrice();
        Task DeleteAll();
        Task<bool> IsReservationAvailable(Guid housingId, DateTime DateFrom, DateTime DateTo);
    }
}

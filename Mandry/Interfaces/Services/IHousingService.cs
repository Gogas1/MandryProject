using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs.Reviews;
using Mandry.Models.Requests.Housing;

namespace Mandry.Interfaces.Services
{
    public interface IHousingService
    {
        Task<Housing> SaveHousingAsync(Housing housing);
        Task<Housing?> GetHousingByIdAsync(string id);
        Task<List<Housing>> GetHousingListAsync();
        Task<bool> IsHousingExistingAsync(string id);
        Task EvaluateRating(string id);
        Task<int> GetHousingReviewsCount(Guid housingId);
        Task<List<ReviewDTO>> GetHousingReviews(Guid housingId);
        Task<List<Housing>> GetFiltered(HousingFilterModel filters);
        Task<MinMaxPrices> GetPrices();
        Task<float> GetAverageRating(Housing housing);
        Task DeleteAll();
        Task<bool> IsReservationAvailable(string housingId, DateTime DateFrom, DateTime DateTo);
    }

    public struct MinMaxPrices
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}

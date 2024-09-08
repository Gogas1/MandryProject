using Mandry.Models.DB;

namespace Mandry.Interfaces.Services
{
    public interface IHousingService
    {
        Task<Housing> SaveHousingAsync(Housing housing);
        Task<Housing?> GetHousingByIdAsync(string id);
        Task<List<Housing>> GetHousingListAsync();
        Task<bool> IsHousingExistingAsync(string id);
        Task EvaluateRating(string id);
    }
}

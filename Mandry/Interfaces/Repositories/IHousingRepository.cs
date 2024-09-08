using Mandry.Models.DB;

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
    }
}

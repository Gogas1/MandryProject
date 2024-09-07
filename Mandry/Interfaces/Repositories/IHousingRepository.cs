using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IHousingRepository
    {
        Task<Housing> CreateHousingAsync(Housing housing);
        Task<Housing?> GetHousingByIdAsync(Guid id);
        Task<List<Housing>> GetAll();
    }
}

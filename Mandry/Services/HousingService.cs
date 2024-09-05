using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;

namespace Mandry.Services
{
    public class HousingService : IHousingService
    {
        private readonly IHousingRepository _housingRepository;

        public HousingService(IHousingRepository housingRepository)
        {
            _housingRepository = housingRepository;
        }

        public async Task<Housing?> GetHousingByIdAsync(string id)
        {
            return await _housingRepository.GetHousingByIdAsync(Guid.Parse(id));
        }

        public async Task<Housing> SaveHousingAsync(Housing housing)
        {
            return await _housingRepository.CreateHousingAsync(housing);
        }
    }
}

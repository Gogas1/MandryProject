using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;

namespace Mandry.Data.Repositories
{
    public class HousingRepository : IHousingRepository
    {
        private readonly MandryDbContext _dbContext;

        public HousingRepository(MandryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Housing> CreateHousingAsync(Housing housing)
        {
            _dbContext.Housings.Add(housing);
            await _dbContext.SaveChangesAsync();

            return housing;
        }

        public async Task<Housing?> GetHousingByIdAsync(Guid id)
        {
            return await _dbContext.Housings.FindAsync(id);
        }
    }
}

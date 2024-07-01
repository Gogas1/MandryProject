using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;

namespace Mandry.Data.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly MandryDbContext _context;

        public FeatureRepository(MandryDbContext dbContext)
        {
            _context = dbContext;
        }

        public Task<Feature> CreateFeatureAsync(Feature feature)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Feature>> GetAllFeaturesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

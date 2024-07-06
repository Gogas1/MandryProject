using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Data.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly MandryDbContext _context;

        public FeatureRepository(MandryDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Feature> CreateFeatureAsync(Feature feature)
        {
            _context.Add(feature);
            await _context.SaveChangesAsync();

            return feature;
        }

        public Task<ICollection<Feature>> GetAllFeaturesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Feature>> GetAllFeaturesWithTranslations()
        {
            return await _context.Features
                .Include(f => f.Translation)
                .ToListAsync();
        }
    }
}

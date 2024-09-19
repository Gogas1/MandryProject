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
            _context.Attach(feature.FeatureImage);
            _context.Add(feature);
            await _context.SaveChangesAsync();

            return feature;
        }

        public async Task DeleteFeature(Feature feature)
        {
            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeatures()
        {
            var features = await _context.Features.ToListAsync();
            _context.Features.RemoveRange(features);

            await _context.SaveChangesAsync();
        }

        public Task<ICollection<Feature>> GetAllFeaturesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Feature>> GetAllFeaturesWithTranslations()
        {
            return await _context.Features
                .Include(f => f.Translation)
                .Include(f => f.FeatureImage)
                .Include(f => f.Parameters)
                .ThenInclude(p => p.Translation)
                .ToListAsync();
        }

        public async Task<Feature?> GetFeatureById(Guid id)
        {
            return await _context.Features.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> IsFeatureExisting(Guid id)
        {
            return await _context.Features.AnyAsync(f => f.Id == id);
        }
    }
}

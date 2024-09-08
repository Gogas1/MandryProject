using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Attach(housing.Category);
            foreach(var image in housing.Images)
            {
                _dbContext.Attach(image);
            }
            foreach (var feat in housing.FeatureHousings)
            {
                _dbContext.Attach(feat.Feature);
                foreach (var param in feat.ParametersValues)
                {
                    _dbContext.Attach(param.Parameter);
                }
            }
            _dbContext.Housings.Add(housing);
            await _dbContext.SaveChangesAsync();

            return housing;
        }

        public async Task<Housing?> GetHousingByIdAsync(Guid id)
        {
            return await _dbContext.Housings  
                .Include(h => h.FeatureHousings)
                .ThenInclude(fh => fh.Feature)
                .ThenInclude(f => f.FeatureImage)

                .Include(h => h.FeatureHousings)
                .ThenInclude(fh => fh.Feature)
                .ThenInclude(f => f.Translation)
                .Include(h => h.FeatureHousings)
                .ThenInclude(fh => fh.ParametersValues)
                .ThenInclude(pv => pv.Parameter)

                .Include(h => h.Owner)

                .Include(h => h.Bedrooms)
                .ThenInclude(bh => bh.Beds)

                .Include(h => h.Images)
                .Include(h => h.Category)
                .ThenInclude(c => c.Translation)
                .AsSplitQuery()
                .FirstAsync(h => h.Id == id);
        }

        public async Task<List<Housing>> GetAll()
        {
            return await _dbContext.Housings
            .Select(h => new Housing()
            {
                    Id = h.Id,
                    Name = h.Name,
                    OneLineDescription = h.OneLineDescription,
                    CategoryProperty = h.CategoryProperty,
                    Images = h.Images,
                    Category = h.Category,
                    PricePerNight = h.PricePerNight,
                    Bedrooms = h.Bedrooms
            })
            .ToListAsync();
        }
    }
}

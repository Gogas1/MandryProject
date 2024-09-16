﻿using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Mandry.Models.Requests.Housing;
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
                .ThenInclude(o => o.ProfileImage)
                .Include(h => h.Owner)
                .ThenInclude(o => o.UserAbout)

                .Include(h => h.Bedrooms)
                .ThenInclude(bh => bh.Beds)

                .Include(h => h.Availabilities)

                .Include(h => h.Images)
                .Include(h => h.Category)
                .ThenInclude(c => c.Translation)
                .AsSplitQuery()
                .FirstAsync(h => h.Id == id);
        }

        public async Task<float> GetHousingAverageRating(Guid id)
        {
            var ratings = await _dbContext.Reviews
                .Where(r => r.HousingTo.Id == id)
                .Select(r => r.Rating)
                .ToListAsync();

            if (ratings.Any())
            {
                var averageRating = ratings.Average();                
                return averageRating;
            }
            else
            {
                return 0;
            }
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

        public async Task<bool> IsHousingExistingByIdAsync(Guid id)
        {
            return await _dbContext.Housings.AnyAsync(h => h.Id == id);
        }

        public async Task UpdateHousing(Housing housing)
        {
            _dbContext.Update(housing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetReviewsCount(Guid id)
        {
            return await _dbContext.Reviews.Where(r => r.HousingTo.Id == id).CountAsync();
        }

        public async Task<ICollection<Review>> GetLastReviews(Guid housingId, int count)
        {
            return await _dbContext.Reviews
                .Include(r => r.From)
                .Where(r => r.HousingTo.Id == housingId)
                .OrderByDescending(r => r.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<ICollection<Housing>> FilterAsync(HousingFilterModel filter)
        {
            var query = _dbContext.Housings.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Destination))
            {
                var splitted = filter.Destination.Split(',');
                query = query.Where(h => splitted.Contains(h.LocationCountry) || splitted.Contains(h.LocationPlace));
            }

            if(filter.FeatureIds != null && filter.FeatureIds.Any()) {
                query = query.Where(h => h.FeatureHousings.Any(fh => filter.FeatureIds.Select(fi => Guid.Parse(fi)).Contains(fh.Feature.Id)));
            }

            return await query.ToListAsync();
        }
    }
}

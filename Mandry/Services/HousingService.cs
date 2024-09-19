using Mandry.Extensions;
using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs;
using Mandry.Models.DTOs.ApiDTOs.Reviews;
using Mandry.Models.Requests.Housing;
using System.Text;

namespace Mandry.Services
{
    public class HousingService : IHousingService
    {
        private readonly IHousingRepository _housingRepository;
        private readonly IDestinationRepository _destinationRepository;
        private readonly IUserRepo _userRepo;

        public HousingService(IHousingRepository housingRepository, IUserRepo userRepo, IDestinationRepository destinationRepository)
        {
            _housingRepository = housingRepository;
            _userRepo = userRepo;
            _destinationRepository = destinationRepository;
        }

        public async Task EvaluateRating(string id)
        {
            Housing? housing = await _housingRepository.GetHousingByIdAsync(Guid.Parse(id));
            if (housing == null) return;

            housing.AverageRating = await _housingRepository.GetHousingAverageRating(housing.Id);
            await _housingRepository.UpdateHousing(housing);
        }

        public async Task<Housing?> GetHousingByIdAsync(string id)
        {
            return await _housingRepository.GetHousingByIdAsync(Guid.Parse(id));
        }

        public async Task<List<Housing>> GetHousingListAsync()
        {
            return await _housingRepository.GetAll();
        }

        public async Task<bool> IsHousingExistingAsync(string id)
        {
            return await _housingRepository.IsHousingExistingByIdAsync(Guid.Parse(id));
        }

        public async Task<Housing> SaveHousingAsync(Housing housing)
        {
            var sb = new StringBuilder();
            var result = await _housingRepository.CreateHousingAsync(housing);
            await _destinationRepository
                .CreateUniqueAsync(
                new Destination()
                {
                    Name = sb
                    .Append(housing.LocationCountry)
                    .Append(", ")
                    .Append(housing.LocationPlace)
                    .ToString()
                });
            await _userRepo.UpdateUserOwnerStatus(result.Owner.Id);

            return result;
        }

        public async Task<int> GetHousingReviewsCount(Guid housingId)
        {
            return await _housingRepository.GetReviewsCount(housingId);
        }

        public async Task<List<ReviewDTO>> GetHousingReviews(Guid housingId)
        {
            var reviews = await _housingRepository.GetLastReviews(housingId, 2);
            return reviews.Select(r => r.ToDTO()).ToList();
        }

        public async Task<List<Housing>> GetFiltered(HousingFilterModel filters)
        {
            var result = await _housingRepository.FilterAsync(filters);
            return result.ToList();
        }

        public async Task<MinMaxPrices> GetPrices()
        {
            decimal minPrice = await _housingRepository.GetMinPrice();
            decimal maxPrice = await _housingRepository.GetMaxPrice();

            return new MinMaxPrices { MinPrice = minPrice, MaxPrice = maxPrice };
        }

        public async Task DeleteAll()
        {
            await _housingRepository.DeleteAll();
        }
    }
}

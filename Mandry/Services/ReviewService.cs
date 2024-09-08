
using Mandry.Extensions;
using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs.Reviews;
using Mandry.Models.Requests.Reviews;

namespace Mandry.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUserService _userService;
        private readonly IHousingService _housingService;
        private readonly IReviewsRepository _reviewsRepository;

        public ReviewService(IUserService userService, IReviewsRepository reviewsRepository, IHousingService housingService)
        {
            _userService = userService;
            _reviewsRepository = reviewsRepository;
            _housingService = housingService;
        }

        public async Task<ReviewDTO> CreateReview(AddReviewModel model, User creator)
        {
            Review review = model.ToReview();
            review.From = creator;
          
            if(!string.IsNullOrEmpty(model.ToUserId))
            {
                if (!await _userService.IsUserExistAsync(model.ToUserId))
                {
                    throw new ArgumentException("User does not exist");
                }

                review.To = new User() { Id = Guid.Parse(model.ToUserId) };
                var reviewDto = await _reviewsRepository.CreateReview(review);
                await _userService.EvaluateUserRating(model.ToUserId);

                return reviewDto.ToDTO();
            }

            if (!string.IsNullOrEmpty(model.ToHousingId))
            {
                if (!await _housingService.IsHousingExistingAsync(model.ToHousingId))
                {
                    throw new ArgumentException("User does not exist");
                }

                review.HousingTo = new Housing() { Id = Guid.Parse(model.ToHousingId) };
                var reviewDto = await _reviewsRepository.CreateReview(review);
                await _housingService.EvaluateRating(model.ToHousingId);

                return reviewDto.ToDTO();
            }

            throw new ArgumentNullException("User nor Housing id are not specified");
        }
    }
}

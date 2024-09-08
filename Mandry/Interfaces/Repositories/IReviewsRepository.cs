using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IReviewsRepository
    {
        Task<Review> CreateReview(Review review);
        Task DeleteReview(Review review);       
    }
}

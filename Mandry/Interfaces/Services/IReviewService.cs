using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs.Reviews;
using Mandry.Models.Requests.Reviews;

namespace Mandry.Interfaces.Services
{
    public interface IReviewService
    {
        Task<ReviewDTO> CreateReview(AddReviewModel model, User creator);
        
    }
}

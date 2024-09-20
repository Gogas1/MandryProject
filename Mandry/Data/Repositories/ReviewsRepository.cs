using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Data.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly MandryDbContext _context;

        public ReviewsRepository(MandryDbContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateReview(Review review)
        {
            if(review.HousingTo != null)
            {
                var targetReview = await _context.Reviews.FirstOrDefaultAsync(r => r.From.Id == review.From.Id && r.HousingTo.Id == review.HousingTo.Id);
                if(targetReview != null)
                {
                    targetReview.From = review.From;
                    targetReview.HousingTo = review.HousingTo;
                    targetReview.To = review.To;
                    targetReview.Text = review.Text;
                    targetReview.Rating = review.Rating;

                    _context.Attach(targetReview.From);

                    if (targetReview.To != null) _context.Attach(review.To);
                    if (targetReview.HousingTo != null) _context.Attach(review.HousingTo);

                    targetReview.CreatedAt = DateTime.Now;
                    _context.Reviews.Update(targetReview);
                    await _context.SaveChangesAsync();

                    return review;
                }                
            }

            if (review.To != null)
            {
                var targetReview = await _context.Reviews.FirstOrDefaultAsync(r => r.From.Id == review.From.Id && r.To.Id == review.To.Id);
                if (targetReview != null)
                {
                    targetReview.From = review.From;
                    targetReview.To = review.To;
                    targetReview.Text = review.Text;
                    targetReview.Rating = review.Rating;

                    _context.Attach(targetReview.From);

                    if (targetReview.To != null) _context.Attach(review.To);

                    targetReview.CreatedAt = DateTime.Now;
                    _context.Reviews.Update(targetReview);
                    await _context.SaveChangesAsync();

                    return review;
                }
            }

            review.CreatedAt = DateTime.Now;
            _context.Reviews.Add(review);
            _context.Attach(review.From);

            if (review.To != null) _context.Attach(review.To);
            if (review.HousingTo != null) _context.Attach(review.HousingTo);

            await _context.SaveChangesAsync();

            return review;
        }

        public async Task DeleteReview(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}

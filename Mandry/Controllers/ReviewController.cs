using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.Requests.Reviews;
using Mandry.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mandry.Controllers
{
    [Route("reviews")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;

        public ReviewController(IReviewService reviewService, IUserService userService)
        {
            _reviewService = reviewService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> CreateReview([FromBody] AddReviewModel model)
        {
            try
            {
                var user = HttpContext.User;
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId != null)
                {
                    var targetUser = await _userService.GetBasicUserByIdAsync(userId);

                    if (targetUser == null)
                    {
                        return Unauthorized();
                    }
                    else
                    {
                        var review = await _reviewService.CreateReview(model, targetUser);

                        return Ok(review);
                    }
                }

                return Unauthorized();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

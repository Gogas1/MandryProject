using Mandry.ApiResponses.Account;
using Mandry.ApiResponses.Housings;
using Mandry.Extensions;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.Requests.Housing;
using Mandry.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Mandry.Controllers
{
    [Route("housing")]
    public class HousingController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHousingService _housingService;
        private readonly IFavouritesService _favouritesService;

        public HousingController(IUserService userService, IHousingService housingService, IFavouritesService favouritesService)
        {
            _userService = userService;
            _housingService = housingService;
            _favouritesService = favouritesService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateHousing([FromBody] AddHousingModel model)
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
                        Housing newHousing = model.ToHousing();
                        newHousing.Owner = targetUser;

                        Housing housing = await _housingService.SaveHousingAsync(newHousing);

                        return Ok(housing);
                    }
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var housing = await _housingService.GetHousingByIdAsync(id);
                if(housing == null)
                {
                    return NotFound();
                }

                GetByIdResponse response = new GetByIdResponse();
                response.Housing = housing.ToHousingDTO();
                response.OwnerData = housing.Owner.ToDTO(false, true);
                response.Housing.Reviews = await _housingService.GetHousingReviews(housing.Id);
                response.Housing.ReviewsCount = await _housingService.GetHousingReviewsCount(housing.Id);
                response.OwnerData.ReviewsCount = await _userService.GetUserReviewsCount(housing.Owner.Id);
                response.Housing.AverageRating = await _housingService.GetAverageRating(housing);                

                var user = HttpContext.User;
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId != null)
                {
                    var targetUser = await _userService.GetBasicUserByIdAsync(userId);

                    if (targetUser != null)
                    {
                        var favourites = await _favouritesService.GetFavourites(targetUser);
                        bool isFavourite = favourites.Any(f => f.Id == housing.Id);
                        response.Housing.IsFavourite = isFavourite;
                    }
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        } 

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var housings = await _housingService.GetHousingListAsync();
                var housingDTOs = housings.Select(h => h.ToHousingDTO()).ToList();

                var user = HttpContext.User;
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId != null)
                {
                    var targetUser = await _userService.GetBasicUserByIdAsync(userId);

                    if (targetUser != null)
                    {
                        var userFavourites = await _favouritesService.GetFavourites(targetUser);
                        housingDTOs.ForEach(dto =>
                        {
                            dto.IsFavourite = userFavourites.Any(f => f.Id == Guid.Parse(dto.Id));
                        });
                    }
                }

                var response = new GetAllResponse() { Housings = housingDTOs };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] HousingFilterModel filters)
        {
            try
            {
                if(filters.FeatureIds != null)
                {
                    filters.FeatureIds = JsonSerializer.Deserialize<List<string>>(filters.FeatureIds.FirstOrDefault(""));
                }

                var housings = await _housingService.GetFiltered(filters);
                var housingDTOs = housings.Select(h => h.ToHousingDTO()).ToList();

                double elementsCount = await _housingService.GetFilteredCount(filters);
                int pagesCount = (int)Math.Ceiling(elementsCount / filters.PageSize);

                var user = HttpContext.User;
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId != null)
                {
                    var targetUser = await _userService.GetBasicUserByIdAsync(userId);

                    if (targetUser != null)
                    {
                        var userFavourites = await _favouritesService.GetFavourites(targetUser);
                        housingDTOs.ForEach(dto =>
                        {
                            dto.IsFavourite = userFavourites.Any(f => f.Id == Guid.Parse(dto.Id));
                        });
                    }
                }

                var response = new GetAllResponse() { Housings = housingDTOs, TotalPages = pagesCount };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("prices")]
        public async Task<IActionResult> GetPrices()
        {
            try
            {
                var prices = await _housingService.GetPrices();
                var response = new GetPricesResponse()
                {
                    MinPrice = prices.MinPrice,
                    MaxPrice = prices.MaxPrice
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete/all")]
        public async Task<IActionResult> DeleteAll()
        {
            await _housingService.DeleteAll();
            return Ok();
        }
    }
}

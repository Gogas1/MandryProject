using Mandry.ApiResponses.Account;
using Mandry.ApiResponses.Favourites;
using Mandry.Extensions;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mandry.Controllers
{
    [Route("favourites")]
    public class FavouritesController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFavouritesService _favouritesService;

        public FavouritesController(IUserService userService, IFavouritesService favouritesService)
        {
            _userService = userService;
            _favouritesService = favouritesService;
        }

        [Authorize]
        [HttpPost("make")]
        public async Task<IActionResult> MakeFavourite(string housing)
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
                        bool result = await _favouritesService.MakeFavourite(targetUser, housing);

                        return Ok(new { isFavourite = result });
                    }
                }

                return Unauthorized();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> GetFavourites()
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
                        var favourites = await _favouritesService.GetFavouritesEnriched(targetUser);
                        var result = new GetFavouritesResponse()
                        {
                            Housings = favourites.Select(fa => fa.ToHousingDTO()).ToList()
                        };
                        return Ok(result);
                    }
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}

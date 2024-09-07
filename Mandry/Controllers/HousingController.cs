using Mandry.ApiResponses.Account;
using Mandry.ApiResponses.Housings;
using Mandry.Extensions;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.Requests.Housing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mandry.Controllers
{
    [Route("housing")]
    public class HousingController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHousingService _housingService;

        public HousingController(IUserService userService, IHousingService housingService)
        {
            _userService = userService;
            _housingService = housingService;
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

                return Ok(housing.ToHousingDTO());
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
                var response = new GetAllResponse() { Housings = housings.Select(h => h.ToHousingDTO()).ToList() };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }
    }
}

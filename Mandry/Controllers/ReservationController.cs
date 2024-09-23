using Mandry.ApiResponses.Account;
using Mandry.Extensions;
using Mandry.Interfaces.Services;
using Mandry.Models.Requests.Housing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mandry.Controllers
{
    [Route("reservation")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        private readonly IHousingService _housingService;

        public ReservationController(IReservationService reservationService, IUserService userService, IHousingService housingService)
        {
            _reservationService = reservationService;
            _userService = userService;
            _housingService = housingService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateReservation([FromBody] AddReservationModel model)
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
                        return NotFound();
                    }
                    else
                    {
                        model = model.ToNormal();
                        bool isReservationAvailable = await _housingService.IsReservationAvailable(model.HousingId, model.DateFrom, model.DateTo);
                        if(!isReservationAvailable)
                        {
                            return BadRequest();
                        }
                        model.UserId = targetUser.Id.ToString();
                        var reservation = await _reservationService.AddReservation(model, targetUser);

                        return Ok(reservation);
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
    }
}

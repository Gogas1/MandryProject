using Mandry.ApiResponses.Destination;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace Mandry.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet("destinations/get")]
        public async Task<IActionResult> GetDestinations(string name)
        {
            List<Destination> destinations = await _destinationService.FilterDestinationsByNameAsync(name);
            GetDestinationsResponse response = new GetDestinationsResponse();
            response.Destinations = destinations.Select(d => d.Name).ToList();

            return Ok(response);
        }
    }
}

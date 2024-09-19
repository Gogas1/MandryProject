using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.ApiResponses.Favourites
{
    public class GetFavouritesResponse
    {
        public List<HousingDTO> Housings { get; set; } = new List<HousingDTO>();
    }
}

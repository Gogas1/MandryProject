using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.ApiResponses.Housings
{
    public class GetAllResponse
    {
        public List<HousingDTO> Housings { get; set; } = new();
    }
}

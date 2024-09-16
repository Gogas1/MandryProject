using Mandry.Models.DTOs;
using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.ApiResponses.Housings
{
    public class GetByIdResponse
    {
        public HousingDTO Housing { get; set; }
        public UserDataDTO OwnerData { get; set; }
    }
}

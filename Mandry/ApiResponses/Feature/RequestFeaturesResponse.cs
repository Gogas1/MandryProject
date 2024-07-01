using Mandry.Models.DTOs.ApiDTOs.Features;

namespace Mandry.ApiResponses.Feature
{
    public class RequestFeaturesResponse
    {
        public ICollection<FeatureDataDTO> Features { get; set; } = new List<FeatureDataDTO>();
    }
}

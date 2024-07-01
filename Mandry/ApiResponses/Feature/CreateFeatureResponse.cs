using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs.ApiDTOs.Features;

namespace Mandry.ApiResponses.Feature
{
    public class CreateFeatureResponse
    {
        public bool Success { get; set; }
        public bool IsValidationFailed { get; set; }
        public ICollection<ValidationErrors> ValidationErrorsGroups { get; set; } = new List<ValidationErrors>();
        public FeatureDataDTO? FeatureData { get; set; }
    }
}

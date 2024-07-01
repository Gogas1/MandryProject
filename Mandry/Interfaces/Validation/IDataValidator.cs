using Mandry.Models.DTOs.ApiDTOs.Features;

namespace Mandry.Interfaces.Validation
{
    public interface IDataValidator
    {
        ValidationErrors ValidateFeatureData(FeatureDataDTO featureData);
    }
}

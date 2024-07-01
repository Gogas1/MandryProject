using Mandry.Models.DTOs.ApiDTOs.Features;

namespace Mandry.Interfaces.Services
{
    public interface IFeatureService
    {
        Task<FeatureDataDTO> CreateFeatureAsync(FeatureDataDTO featureData);
        Task<ICollection<FeatureDataDTO>> GetFeaturesAsync();
    }
}

using Mandry.Models.DTOs.ApiDTOs.Features;
using Mandry.Models.Requests.Feature;

namespace Mandry.Interfaces.Services
{
    public interface IFeatureService
    {
        Task<FeatureDataDTO> CreateFeatureAsync(AddFeatureModel featureData);
        Task<FeatureDataDTO> CreateFeatureAsync(FeatureDataDTO featureData);
        Task<ICollection<FeatureDataDTO>> GetFeaturesAsync();
        Task PurgeFeatures();
        Task DeleteFeature(string featureId);
        Task<bool> IsFeatureExisting(string id);
    }
}

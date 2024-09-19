using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IFeatureRepository
    {
        Task<Feature> CreateFeatureAsync(Feature feature);
        Task<ICollection<Feature>> GetAllFeaturesAsync();
        Task<ICollection<Feature>> GetAllFeaturesWithTranslations();
        Task DeleteFeatures();
        Task DeleteFeature(Feature feature);
        Task<Feature?> GetFeatureById(Guid id);
        Task<bool> IsFeatureExisting(Guid id);
    }
}

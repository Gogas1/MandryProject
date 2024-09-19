using Mandry.Extensions;
using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.DTOs.ApiDTOs.Features;
using Mandry.Models.Requests.Feature;

namespace Mandry.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<FeatureDataDTO> CreateFeatureAsync(FeatureDataDTO featureData)
        {
            Feature newFeature = new Feature();
            newFeature.NameKey = featureData.NameCode;
            newFeature.DescriptionKey = featureData.DescriptionCode;
            newFeature.IsAllowCustomDescription = featureData.IsAllowCustomDescription;
            newFeature.IsAllowCustomName = featureData.IsAllowCustomName;
            newFeature.IsAllowPinning = featureData.IsAllowPinning;
            newFeature.IsHouseRule = featureData.IsHouseRule;
            newFeature.IsRecomended = featureData.IsHouseRule;
            newFeature.IsCounterFeature = featureData.IsCounterFeature;
            newFeature.IsSafetyFeature = featureData.IsSafetyFeature;
            newFeature.TypeKey = featureData.TypeCode;
            newFeature.FeatureImage = new Image()
            {
                Id = Guid.Parse(featureData.FeatureIcon.Id),                
            };
            newFeature.Translation = featureData.Translations.Select(t => new Translation()
            {
                Language = t.LanguageCode,
                TranslationKey = t.Key,
                TranslationString = t.Text
            }).ToList();

            if(featureData.Parameters.Any())
            {
                newFeature.Parameters = featureData.Parameters.Select(p =>
                {
                    Parameter parameter = new Parameter();
                    parameter.NameKey = p.NameKey;
                    parameter.DefaultValue = p.DefaultValue;
                    parameter.Translation = p.Translations.Select(t => t.ToTranslation()).ToList();

                    return parameter;
                }).ToList();
            }

            newFeature = await _featureRepository.CreateFeatureAsync(newFeature);

            return newFeature.ToDTO();
        }

        public async Task<FeatureDataDTO> CreateFeatureAsync(AddFeatureModel featureData)
        {
            Feature newFeature = featureData.ToFeature();

            if (featureData.IsCounterFeature)
            {
                Feature? counterFeature = await _featureRepository.GetFeatureById(Guid.Parse(featureData.CounterFeatureTo));
                if(counterFeature != null)
                {
                    newFeature.CounterFeature = counterFeature;
                }
            }

            newFeature = await _featureRepository.CreateFeatureAsync(newFeature);

            return newFeature.ToDTO();
        }

        public async Task DeleteFeature(string featureId)
        {
            Feature? targetFeature = await _featureRepository.GetFeatureById(Guid.Parse(featureId));
            if(targetFeature != null) 
            { 
                await _featureRepository.DeleteFeature(targetFeature);
            }
        }

        public async Task<bool> IsFeatureExisting(string id)
        {
            return await _featureRepository.IsFeatureExisting(Guid.Parse(id));
        }

        public async Task<ICollection<FeatureDataDTO>> GetFeaturesAsync()
        {
            var features = await _featureRepository.GetAllFeaturesWithTranslations();
            var featuresDTO = features.Select(f => f.ToDTO()).ToList();

            return featuresDTO;
        }

        public async Task PurgeFeatures()
        {
            await _featureRepository.DeleteFeatures();
        }
    }
}

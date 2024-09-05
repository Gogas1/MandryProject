using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.DTOs.ApiDTOs.Features;

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
            newFeature.FeatureIcon = featureData.FeatureIcon;
            newFeature.Translation = featureData.Translations.Select(t => new Translation()
            {
                Language = t.LanguageCode,
                TranslationKey = t.Key,
                TranslationString = t.Text
            }).ToList();

            newFeature = await _featureRepository.CreateFeatureAsync(newFeature);
            return new FeatureDataDTO()
            {
                Id = newFeature.Id.ToString(),
                NameCode = newFeature.NameKey,
                DescriptionCode = newFeature.DescriptionKey,
                IsAllowCustomDescription = newFeature.IsAllowCustomDescription,
                IsAllowCustomName = newFeature.IsAllowCustomName,
                IsAllowPinning = newFeature.IsAllowPinning,
                IsHouseRule = newFeature.IsHouseRule,
                IsRecommended = newFeature.IsRecomended,
                FeatureIcon = newFeature.FeatureIcon,
                Translations = newFeature.Translation.Select(t =>
                {
                    TranslationDTO translationDTO = new TranslationDTO();
                    translationDTO.Key = t.TranslationKey;
                    translationDTO.LanguageCode = t.Language;
                    translationDTO.Text = t.TranslationString;

                    return translationDTO;
                }).ToList()
            };
        }

        public async Task<ICollection<FeatureDataDTO>> GetFeaturesAsync()
        {
            var features = await _featureRepository.GetAllFeaturesWithTranslations();
            var featuresDTO = features.Select(f =>
            {
                FeatureDataDTO featureDataDTO = new FeatureDataDTO();
                featureDataDTO.Id = f.Id.ToString();
                featureDataDTO.NameCode = f.NameKey;
                featureDataDTO.DescriptionCode = f.DescriptionKey;
                featureDataDTO.IsAllowCustomName = f.IsAllowCustomName;
                featureDataDTO.IsAllowCustomDescription = f.IsAllowCustomDescription;
                featureDataDTO.IsHouseRule = f.IsHouseRule;
                featureDataDTO.IsRecommended = f.IsRecomended;
                featureDataDTO.IsAllowPinning = f.IsAllowPinning;
                featureDataDTO.FeatureIcon = f.FeatureIcon;
                featureDataDTO.Translations = f.Translation.Select(t =>
                {
                    TranslationDTO translationDTO = new TranslationDTO();
                    translationDTO.Key = t.TranslationKey;
                    translationDTO.LanguageCode = t.Language;
                    translationDTO.Text = t.TranslationString;

                    return translationDTO;
                }).ToList();

                return featureDataDTO;
            }).ToList();

            return featuresDTO;
        }

        public async Task PurgeFeatures()
        {
            await _featureRepository.DeleteFeatures();
        }
    }
}

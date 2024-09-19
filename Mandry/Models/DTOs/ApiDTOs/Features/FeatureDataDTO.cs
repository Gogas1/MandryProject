namespace Mandry.Models.DTOs.ApiDTOs.Features
{
    public class FeatureDataDTO
    {
        public string Id { get; set; } = string.Empty;
        public string NameCode { get; set; } = string.Empty;
        public string DescriptionCode { get; set; } = string.Empty;
        public string TypeCode { get; set; } = string.Empty;
        public bool IsAllowPinning { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsAllowCustomName { get; set; }
        public bool IsAllowCustomDescription { get; set; }
        public bool IsHouseRule { get; set; }
        public bool IsCounterFeature { get; set; }
        public bool IsSafetyFeature { get; set; }
        public string CounterFeatureTo { get; set; } = string.Empty;

        public ImageDTO FeatureIcon { get; set; }
        public ICollection<TranslationDTO> Translations { get; set; } = new List<TranslationDTO>();
        public ICollection<ParameterDTO> Parameters { get; set; } = new List<ParameterDTO>();
    }
}

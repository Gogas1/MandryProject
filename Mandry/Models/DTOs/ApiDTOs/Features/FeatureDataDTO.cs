namespace Mandry.Models.DTOs.ApiDTOs.Features
{
    public class FeatureDataDTO
    {
        public string Id { get; set; } = string.Empty;
        public string NameCode { get; set; } = string.Empty;
        public string DescriptionCode { get; set; } = string.Empty;
        public bool IsAllowPinning { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsAllowCustomName { get; set; }
        public bool IsAllowCustomDescription { get; set; }
        public bool IsHouseRule { get; set; }

        public TranslationDTO Translations { get; set; } = new TranslationDTO();
    }
}

using Mandry.Models.DTOs.ApiDTOs.Features;
using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.Requests.Parameters;

namespace Mandry.Models.Requests.Feature
{
    public class AddFeatureModel
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

        public ImageDTO FeatureIcon { get; set; }
        public ICollection<TranslationDTO> Translations { get; set; } = new List<TranslationDTO>();
        public ICollection<AddParameterModel> Parameters { get; set; } = new List<AddParameterModel>();
    }
}

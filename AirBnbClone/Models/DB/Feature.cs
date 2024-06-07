using AirBnbClone.Models.Inheritance;

namespace AirBnbClone.Models.DB
{
    public class Feature : Translatable
    {
        public string NameKey { get; set; } = string.Empty;
        public string DescriptionKey { get; set; } = string.Empty;
        public bool IsAllowPinning { get; set; }
        public bool IsRecomended { get; set; }
        public bool IsAllowCustomName { get; set; }
        public bool IsAllowCustomDescription { get; set; }
        public bool IsHouseRule { get; set; }

        public ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
        public ICollection<FeatureHousing> FeatureHousing { get; set; } = new List<FeatureHousing>();
    }
}
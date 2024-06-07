using AirBnbClone.Models.Inheritance;

namespace AirBnbClone.Models.DB
{
    public class Parameter : Translatable
    {
        public string NameKey { get; set; } = string.Empty;
        public string DefaultValue { get; set; } = string.Empty;

        public Feature Feature { get; set; }
        public ICollection<ParameterFeatureHousing> ParameterValuesForHousing { get; set; }
    }
}

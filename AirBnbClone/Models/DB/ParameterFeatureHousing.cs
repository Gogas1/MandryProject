namespace AirBnbClone.Models.DB
{
    public class ParameterFeatureHousing
    {
        public Guid Id { get; set; }
        public string Value { get; set; } = string.Empty;

        public Parameter Parameter { get; set; }
        public FeatureHousing FeatureHousing { get; set; }
    }
}

namespace AirBnbClone.Models.DB
{
    public class FeatureHousing
    {
        public Guid Id { get; set; }
        public string CustomName { get; set; } = string.Empty;
        public string CustomDescription { get; set; } = string.Empty;

        public Feature Feature { get; set; }
        public Housing Housing { get; set; }
        public ICollection<ParameterFeatureHousing> ParametersValues { get; set; }
    }
}

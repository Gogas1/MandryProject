namespace Mandry.Models.DB
{
    public class AccessbilityFeature
    {
        public Guid Id { get; set; }
        public string NameKey { get; set; } = string.Empty;
        public string DescriptionKey { get; set; } = string.Empty;

        public ICollection<AccessbilityFeatureHousing> AccessbilityFeatureHousings { get; set; } = new List<AccessbilityFeatureHousing>();
    }
}

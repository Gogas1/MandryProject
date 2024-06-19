namespace Mandry.Models.DB
{
    public class AccessbilityFeatureHousing
    {
        public Guid Id { get; set; }
        public AccessbilityFeature AccessnilityFeature { get; set; }
        public Image? Image { get; set; }
        public Housing Housing { get; set; }
    }
}

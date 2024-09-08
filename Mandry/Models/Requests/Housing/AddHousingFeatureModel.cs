namespace Mandry.Models.Requests.Housing
{
    public class AddHousingFeatureModel
    {
        public string Id { get; set; } = string.Empty;
        public ICollection<AddHousingFeatureParameterModel> Parameters { get; set; } = new List<AddHousingFeatureParameterModel>();
    }
}

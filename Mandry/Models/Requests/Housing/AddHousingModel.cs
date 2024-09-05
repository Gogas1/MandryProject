namespace Mandry.Models.Requests.Housing
{
    public class AddHousingModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string Type { get; set; } = string.Empty;
        public string CategoryProperty { get; set; } = string.Empty;
        public string Location { get; set; }
        public int MaxGuests { get; set; }

        public string CategoryId { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new();


    }
}

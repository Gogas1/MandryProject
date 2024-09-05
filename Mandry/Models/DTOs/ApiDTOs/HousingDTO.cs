namespace Mandry.Models.DTOs.ApiDTOs
{
    public class HousingDTO
    {
        public string Id { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string CategoryProperty { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int MaxGuests { get; set; }
    }
}

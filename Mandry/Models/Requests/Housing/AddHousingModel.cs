using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.Models.Requests.Housing
{
    public class AddHousingModel
    {
        public string Id { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LocationPlace { get; set; } = string.Empty;
        public string LocationCountry { get; set; } = string.Empty;
        public int MaxGuests { get; set; }
        public int Bathrooms { get; set; }
        public string CategoryId { get; set; } = string.Empty;
        public ICollection<string> FeaturesId { get; set; } = new List<string>();
        public ICollection<DateTime> Availabilities = new List<DateTime>();
        public ICollection<BedroomDTO> Bedrooms { get; set; } = new List<BedroomDTO>();
        public ICollection<ImageDTO> Images { get; set; } = new List<ImageDTO>();
    }
}

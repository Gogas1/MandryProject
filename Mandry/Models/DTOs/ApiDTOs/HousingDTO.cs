using Mandry.Models.DTOs.ApiDTOs.Categories;
using Mandry.Models.DTOs.ApiDTOs.Features;

namespace Mandry.Models.DTOs.ApiDTOs
{
    public class HousingDTO
    {
        public string Id { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OneLineDescription { get; set; } = string.Empty;
        public string CategoryProperty { get; set; } = string.Empty;
        public string LocationPlace { get; set; } = string.Empty;
        public string LocationCountry { get; set; } = string.Empty;
        public string LocationCoords { get; set;} = string.Empty;
        public int MaxGuests { get; set; }
        public int Bathrooms { get; set; }
        public CategoryDTO Category { get; set; }
        public ICollection<FeatureDataDTO> Features { get; set; } = new List<FeatureDataDTO>();
        public ICollection<DateTime> Availabilities = new List<DateTime>();
        public ICollection<BedroomDTO> Bedrooms { get; set; } = new List<BedroomDTO>();
        public ICollection<ImageDTO> Images { get; set; } = new List<ImageDTO>();
    }

    public class BedroomDTO
    {
        public ICollection<BedDTO> Beds { get; set; } = new List<BedDTO>();
    }

    public class BedDTO
    {
        public string Type { set; get; } = string.Empty;
        public int Size { get; set; }
    }
}

﻿using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.Models.Requests.Housing
{
    public class AddHousingModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public decimal CleaningFee { get; set; }
        public string? CategoryProperty { get; set; } = string.Empty;
        public string OneLineDescription { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LocationPlace { get; set; } = string.Empty;
        public string LocationCountry { get; set; } = string.Empty;
        public string LocationCoords { get; set; } = string.Empty;
        public int MaxGuests { get; set; }
        public int Bathrooms { get; set; }
        public string CategoryId { get; set; } = string.Empty;
        public ICollection<AddHousingFeatureModel> Features { get; set; } = new List<AddHousingFeatureModel>();
        public ICollection<DateTime> Availabilities { get; set; } = new List<DateTime>();
        public ICollection<BedroomDTO> Bedrooms { get; set; } = new List<BedroomDTO>();
        public ICollection<ImageDTO> Images { get; set; } = new List<ImageDTO>();
    }
}

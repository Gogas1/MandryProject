using Mandry.Models.DB;
using Mandry.Models.DTOs.ApiDTOs;
using Mandry.Models.DTOs.ApiDTOs.Categories;
using Mandry.Models.Requests.Housing;
using Mandry.Models.DTOs.ApiDTOs.Features;

namespace Mandry.Extensions
{
    public static class MappingExtensions
    {
        #region Housing
        public static HousingDTO ToHousingDTO(this Housing housing)
        {           
            HousingDTO housingDTO = new HousingDTO();
            housingDTO.Id = housing.Id.ToString();
            housingDTO.PricePerNight = housing.PricePerNight;
            housingDTO.Name = housing.Name;
            housingDTO.OneLineDescription = housing.OneLineDescription;
            housingDTO.ShortDescription = housing.ShortDescription;
            housingDTO.Description = housing.Description;
            housingDTO.LocationPlace = housing.LocationPlace;
            housingDTO.LocationCountry = housing.LocationCountry;
            housingDTO.MaxGuests = housing.MaxGuests;
            housingDTO.Bathrooms = housing.Bathrooms;
            housingDTO.Category = new CategoryDTO()
            {
                Id = housing.Category.Id.ToString(),
                NameKey = housing.Category.NameKey,
                CategoryPropertyDescriptionKey = housing.Category.CategoryPropertyDescriptionKey,
                IsCategoryPropertyRequired = housing.Category.IsCategoryPropertyRequired,
                CategoryTranslations = housing.Category.Translation.Select(t => new TranslationDTO() { Key = t.TranslationKey, LanguageCode = t.Language, Text = t.TranslationString }).ToList(),               
            };
            housingDTO.Features = housing.FeatureHousings.Select(fh =>
            {
                var featureDTO = new FeatureDataDTO();
                featureDTO.Id = fh.Feature.Id.ToString();
                featureDTO.NameCode = fh.Feature.NameKey;
                featureDTO.DescriptionCode = fh.Feature.DescriptionKey;
                featureDTO.TypeCode = fh.Feature.TypeKey;
                featureDTO.IsAllowPinning = fh.Feature.IsAllowPinning;
                featureDTO.IsRecommended = fh.Feature.IsRecomended;
                featureDTO.IsAllowCustomName = fh.Feature.IsAllowCustomName;
                featureDTO.IsAllowCustomDescription = fh.Feature.IsAllowCustomDescription;
                featureDTO.IsHouseRule = fh.Feature.IsHouseRule;
                featureDTO.FeatureIcon = new ImageDTO() { Id = fh.Feature.FeatureImage.Id.ToString(), Src = fh.Feature.FeatureImage.Src };
                featureDTO.Translations = fh.Feature.Translation.Select(t => new TranslationDTO() { Key = t.TranslationKey, LanguageCode = t.Language, Text = t.TranslationString}).ToList();

                return featureDTO;
            }).ToList();
            housingDTO.Availabilities = housing.Availabilities.ToDays();
            housingDTO.Bedrooms = housing.Bedrooms.Select(b =>
            {
                BedroomDTO bedroom = new BedroomDTO();
                bedroom.Beds = b.Beds.Select(bed => new BedDTO() { Size = bed.NumberOfPeople }).ToList();

                return bedroom;
            }).ToList();
            housingDTO.Images = housing.Images.Select(i => new ImageDTO() { Id = i.Id.ToString(), Src = i.Src }).ToList();

            return housingDTO;
        }

        public static Housing ToHousing(this HousingDTO housingDTO)
        {
            Housing housing = new Housing();
            housing.Id = Guid.Parse(housingDTO.Id);
            housing.PricePerNight = housingDTO.PricePerNight;
            housing.Name = housingDTO.Name;
            housing.Description = housingDTO.Description;
            housing.ShortDescription = housingDTO.ShortDescription;
            housing.OneLineDescription = housingDTO.OneLineDescription;
            housing.CategoryProperty = housingDTO.CategoryProperty;
            housing.LocationPlace = housingDTO.LocationPlace;
            housing.LocationCountry = housingDTO.LocationCountry;
            housing.LocationCoords = housingDTO.LocationCoords;
            housing.MaxGuests = housingDTO.MaxGuests;
            housing.Bathrooms = housingDTO.Bathrooms;
            housing.Category = new Category() 
            { 
                Id = Guid.Parse(housingDTO.Category.Id), 
                NameKey = housingDTO.Category.NameKey,
                CategoryPropertyDescriptionKey = housingDTO.Category.CategoryPropertyDescriptionKey,
                IsCategoryPropertyRequired = housingDTO.Category.IsCategoryPropertyRequired
            };
            housing.Availabilities = housingDTO.Availabilities.ToAvailabilities();
            housing.FeatureHousings = housingDTO.Features.Select(feat =>
            {
                var newFeatureHousing = new FeatureHousing();
                newFeatureHousing.Feature = new Feature() { Id = Guid.Parse(feat.Id) };

                return newFeatureHousing;
            }).ToList();
            housing.Images = housingDTO.Images.Select(img =>
            {
                return new Image() { Id = Guid.Parse(img.Id) };
            }).ToList();
            housing.Bedrooms = housingDTO.Bedrooms.Select(b =>
            {
                var newBedroom = new Bedroom();
                newBedroom.Beds = b.Beds.Select(bed => new Bed() { NumberOfPeople = bed.Size }).ToList();

                return newBedroom;
            }).ToList();


            return housing;
        }

        public static Housing ToHousing(this AddHousingModel model)
        {
            Housing housing = new Housing();
            housing.ShortDescription = model.ShortDescription;
            housing.Description = model.Description;
            housing.Category = new Category() { Id = Guid.Parse(model.CategoryId) };
            housing.Name = model.Name;
            housing.LocationCountry = model.LocationCountry;
            housing.LocationPlace = model.LocationPlace;
            housing.Bathrooms = model.Bathrooms;
            housing.Bedrooms = model.Bedrooms.Select(b =>
            {
                var newBedroom = new Bedroom();
                newBedroom.Beds = b.Beds.Select(bed => new Bed() { NumberOfPeople = bed.Size }).ToList();

                return newBedroom;
            }).ToList();
            housing.FeatureHousings = model.FeaturesId.Select(feat =>
            {
                var newFeatureHousing = new FeatureHousing();
                newFeatureHousing.Feature = new Feature() { Id = Guid.Parse(feat) };

                return newFeatureHousing;
            }).ToList();
            housing.Images = model.Images.Select(img =>
            {
                return new Image() { Id = Guid.Parse(img.Id) };
            }).ToList();
            housing.PricePerNight = model.PricePerNight;
            housing.MaxGuests = model.MaxGuests;
            housing.Availabilities = model.Availabilities.ToAvailabilities();

            return housing;
        }

        #endregion Housing

        public static List<DateTime> ToDays(this ICollection<Availability> availabilities)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (var availability in availabilities)
            {
                for (DateTime date = availability.From.Date; date <= availability.To.Date; date = date.AddDays(1))
                {
                    days.Add(date);
                }
            }

            return days;
        }

        public static List<Availability> ToAvailabilities(this ICollection<DateTime> days)
        {
            var daysList = days.OrderBy(date => date).ToList();

            List<Availability> intervals = new List<Availability>();
            if (daysList.Count == 0) return intervals;

            DateTime intervalStart = daysList[0];
            DateTime intervalEnd = daysList[0];

            for (int i = 1; i < daysList.Count; i++)
            {
                if ((daysList[i] - intervalEnd).Days == 1)
                {
                    intervalEnd = daysList[i];
                }
                else
                {
                    intervals.Add(new Availability { From = intervalStart, To = intervalEnd });

                    intervalStart = daysList[i];
                    intervalEnd = daysList[i];
                }
            }

            intervals.Add(new Availability { From = intervalStart, To = intervalEnd });

            return intervals;
        }

    }
}
